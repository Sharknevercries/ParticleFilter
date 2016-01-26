using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpAdbClient;
using System.IO;
using System.Threading;
using System.Net;

namespace Car
{
    public partial class Form1 : Form
    {
        private readonly string ADB_SERVER_PATH = @"C:\adb\adb.exe";
        private readonly string SENSOR_FILE_PARTH = "/sdcard/DataCollection/shark/";
        private readonly string PC_FILE_PATH = @"E:\";
        private readonly string WEB_PATH = @"localhost/getcurve.php";
        private readonly string[] FILE_NAME = { "Acc.txt", "Gyr.txt", "Mag.txt", "GPS.txt" };
        private readonly int POSITION_MOVING_AVERAGE_COUNT = 5;
        private readonly double SPEED_THRESHOLD = 14.0;
        private readonly double CURVATURE_THRESHOLD = 0.02;
        private readonly long FUTURE_TIME = 200;
        private SensorFusion _sf;
        private ParticleFilter _pf;

        //private string[] _accs;
        //private string[] _mags;
        //private string[] _gyrs;
        //private string[] _gpss;
        //private string[] _roadCurvatures;
        private string _accs;
        private string _mags;
        private string _gyrs;
        private string _gpss;
        private long _startTimeStamp;
        private long _currentIMUTimeStamp;
        private long _currentGPSTimeStamp;
        private long _IMUTimeStamp;
        private Vector _acc;
        private Vector _mag;
        private Vector _gyr;
        private long _gpsTimeStamp;
        private Vector _gps;
        private Vector _twd97;

        private Vector _accE;
        
        private Vector _predictPosition;

        private List<Vector> _prevTwd97;
        private List<Vector> _prevAvgTwd97;
        private double _speed;

        private double _curvature;

        private List<Tuple<double, double, double>> _roadData;
        private double _roadCurvature;

        private List<double> _prevCurvatureDf;
        private double _curvatureDf;

        public Form1() 
        {
            InitializeComponent();
            _acc = new Vector(3);
            _mag = new Vector(3);
            _gyr = new Vector(3);
            _gps = new Vector(3);
            _twd97 = new Vector(2);
            _IMUTimeStamp = 0;
            _gpsTimeStamp = 0;
            _sf = new SensorFusion();
            _pf = new ParticleFilter();
            _prevTwd97 = new List<Vector>();
            _prevAvgTwd97 = new List<Vector>();
            _prevCurvatureDf = new List<double>();
            _pf.SetLogger(lbInfo);
            ReadRoadData();
            // test use
            //_accs = File.ReadAllLines(PC_FILE_PATH + "Acc.txt");
            //_mags = File.ReadAllLines(PC_FILE_PATH + "Mag.txt");
            //_gyrs = File.ReadAllLines(PC_FILE_PATH + "Gyr.txt");
            //_gpss = File.ReadAllLines(PC_FILE_PATH + "GPS.txt");
            //_roadCurvatures = File.ReadAllLines(PC_FILE_PATH + "GPS3_cur.txt");
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStop.Enabled = true;
            btnStart.Enabled = false;
            timer1.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStop.Enabled = false;
            btnStart.Enabled = true;
            timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DownloadData();
            LoadData();
            //string[] acc = _accs[_counter].Split(",".ToCharArray());
            //string[] mag = _mags[_counter].Split(",".ToCharArray());
            //string[] gyr = _gyrs[_counter].Split(",".ToCharArray());
            //string[] gps = _gpss[_gpsCounter].Split(",".ToCharArray());
            //string[] road = _roadCurvatures[_gpsCounter].Split(",".ToCharArray());
            string[] acc = _accs.Split(",".ToCharArray());
            string[] mag = _mags.Split(",".ToCharArray());
            string[] gyr = _gyrs.Split(",".ToCharArray());
            string[] gps = _gpss.Split(",".ToCharArray());
            
            for (int j = 0; j < 3; j++)
            {
                _acc[j] = double.Parse(acc[j + 1]);
                _mag[j] = double.Parse(mag[j + 1]);
                _gyr[j] = double.Parse(gyr[j + 1]);
            }
            _gps[0] = double.Parse(gps[1]);
            _gps[1] = double.Parse(gps[2]);
            _gps[2] = double.Parse(gps[4]);
            _currentIMUTimeStamp = long.Parse(acc[0]);
            _currentGPSTimeStamp = long.Parse(gps[0]);
            if(_gpsTimeStamp == 0 || _gpsTimeStamp < _currentGPSTimeStamp)
            {
                double[] ret = GPSConverter.GetTWD97(_gps[0], _gps[1]);
                _twd97.X = ret[0];
                _twd97.Y = ret[1];
                _roadCurvature = QueryRoadData(_twd97.X, _twd97.Y);
                AddTwd97(_twd97);
                CalculateVelocity();
                lbInfo.Items.Add(_twd97[0] + ", " + _twd97[1]);
                _gpsTimeStamp = _currentGPSTimeStamp;
            }
            if (_startTimeStamp == 0)
                _startTimeStamp = _IMUTimeStamp;
            if(_IMUTimeStamp == 0 || _IMUTimeStamp < _currentIMUTimeStamp)
            {                
                //_accE = _sf.Calculate(new Vector(_acc), new Vector(_gyr), new Vector(_mag), _currentIMUTimeStamp);
                //_pf.Update(_accE, _currentIMUTimeStamp, _twd97, _gpsTimeStamp);
                //_predictPosition = _pf.GetCurrentPosition();
                CalculateEstimatedCurvature();
                _IMUTimeStamp = _currentIMUTimeStamp;
            }
            ShowResult();
        }

        private void ReadRoadData()
        {
            string[] lines = File.ReadAllLines(PC_FILE_PATH + "GPSRoad.txt");
            foreach(var s in lines)
            {
                string[] line = s.Split(",".ToCharArray());
                double lat = double.Parse(line[0]);
                double lon = double.Parse(line[1]);
                double curvature = double.Parse(line[2]);
                double[] xy = GPSConverter.GetTWD97(lat, lon);
                _roadData.Add(new Tuple<double, double, double>(xy[0], xy[1], curvature));
            }
        }

        private double QueryRoadData(double x, double y)
        {
            double min = _roadData.Min(r => Math.Pow(r.Item1 - x, 2) + Math.Pow(r.Item2 - y, 2));
            return _roadData.Find(r => Math.Pow(r.Item1 - x, 2) + Math.Pow(r.Item2 - y, 2) == min).Item3;
        }
        
        private void AddTwd97(Vector twd97)
        {
            if (_prevTwd97.Count >= POSITION_MOVING_AVERAGE_COUNT)
                _prevTwd97.RemoveAt(0);
            _prevTwd97.Add(new Vector(twd97));
            if (_prevAvgTwd97.Count >= 3)
                _prevAvgTwd97.RemoveAt(0);
            Vector avgTwd97 = new Vector(2);
            avgTwd97.X = _prevTwd97.Average(twd => twd.X);
            avgTwd97.Y = _prevTwd97.Average(twd => twd.Y);
            _prevAvgTwd97.Add(avgTwd97);
        }

        /// <summary>
        /// 取GPS第一和第三新的座標位置去計算平均速率
        /// </summary>
        private void CalculateVelocity()
        {
            if (_prevAvgTwd97.Count < 3)
                return;
            double dx = _prevAvgTwd97[2].X - _prevAvgTwd97[0].X;
            double dy = _prevAvgTwd97[2].Y - _prevAvgTwd97[0].Y;
            _speed = Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2)) / 2.0 * 3600 / 1000.0;
        }        

        private void DownloadData()
        {
            AdbServer.StartServer(ADB_SERVER_PATH, restartServerIfNewer: true);
            var device = AdbClient.Instance.GetDevices().First();
            foreach (var filename in FILE_NAME)
            {
                using (SyncService service = new SyncService(new AdbSocket(AdbServer.EndPoint), device))
                {
                    using (Stream stream = File.OpenWrite(PC_FILE_PATH + filename))
                    {
                        service.Pull(SENSOR_FILE_PARTH + filename, stream, null, CancellationToken.None);
                    }
                }
            }
        }

        private void LoadData()
        {
            _accs = File.ReadLines(PC_FILE_PATH + "Acc.txt").Last();
            _mags = File.ReadLines(PC_FILE_PATH + "Mag.txt").Last();
            _gyrs = File.ReadLines(PC_FILE_PATH + "Gyr.txt").Last();
            _gpss = File.ReadLines(PC_FILE_PATH + "GPS.txt").Last();
        }

        private void ShowResult()
        {
            if (_gps != null)
            {
                lblLatitude.Text = "" + _gps[0];
                lblLongtitude.Text = "" + _gps[1];
                lblV.Text = "" + _gps[2];
            }
            if (_acc != null)
            {
                lblAccelerometerX.Text = "" + _acc[0];
                lblAccelerometerY.Text = "" + _acc[1];
                lblAccelerometerZ.Text = "" + _acc[2];
            }
            if (_gyr != null)
            {
                lblGyroscopeX.Text = "" + _gyr[0];
                lblGyroscopeY.Text = "" + _gyr[1];
                lblGyroscopeZ.Text = "" + _gyr[2];
            }
            if (_mag != null)
            {
                lblMagnetometerX.Text = "" + _mag[0];
                lblMagnetometerY.Text = "" + _mag[1];
                lblMagnetometerZ.Text = "" + _mag[2];
            }
            if (_accE != null)
            {
                lblEarthAccelerationX.Text = "" + _accE[0];
                lblEarthAccelerationY.Text = "" + _accE[1];
                lblEarthAccelerationZ.Text = "" + _accE[2];
                lblAzimuth.Text = "" + _accE[3];
            }
            if (_predictPosition != null)
            {
                lblEstimatedX.Text = "" + _predictPosition.X;
                lblEstimatedY.Text = "" + _predictPosition.Y;
            }
            if(_twd97 != null)
            {
                lblGPSX.Text = "" + _twd97.X;
                lblGPSY.Text = "" + _twd97.Y;
            }
            lblCarCurvature.Text = "" + _curvature;
            lblRoadCurvature.Text = "" + _roadCurvature;
            lblCurvatureDf.Text = "" + _curvatureDf;
            lblV.Text = "" + _speed;
            lblEclipseTime.Text = "" + (_IMUTimeStamp - _startTimeStamp) / 1000.0;
            if(_speed <= SPEED_THRESHOLD)
            {
                if (_curvatureDf >= CURVATURE_THRESHOLD)
                {
                    lblResult.Text = "Right Turn";
                }
                else if (_curvatureDf <= - CURVATURE_THRESHOLD)
                {
                    lblResult.Text = "Left Turn";
                }
                else
                {
                    lblResult.Text = "Go Straight";
                }
            }
            else
            {
                lblResult.Text = "Go Straight";
            }
        }

        private double CalculateCurvature(Vector t0, Vector t1, Vector t2)
        {
            double a = Math.Sqrt(Math.Pow(t0.X - t1.X, 2) + Math.Pow(t0.Y - t1.Y, 2));
            double b = Math.Sqrt(Math.Pow(t1.X - t2.X, 2) + Math.Pow(t1.Y - t2.Y, 2));
            double c = Math.Sqrt(Math.Pow(t0.X - t2.X, 2) + Math.Pow(t0.Y - t2.Y, 2));
            double theta = (a * a + b * b - c * c) / (2 * a * b);
            double curvature = 1.0 / (c / (2 * Math.Sqrt((1 - theta * theta))));
            double x1 = t1.X - t0.X;
            double x2 = t2.X - t1.X;
            double y1 = t1.Y - t0.Y;
            double y2 = t2.Y - t1.Y;
            if (x1 * y2 - x2 * y1 > 0)
                curvature *= -1;
            return curvature;
        }

        private void AddCurvatureDf(double curvatureDf)
        {
            if (_prevCurvatureDf.Count >= POSITION_MOVING_AVERAGE_COUNT)
                _prevCurvatureDf.RemoveAt(0);
            _prevCurvatureDf.Add(curvatureDf);
            _curvatureDf = _prevCurvatureDf.Average();
        }

        private void CalculateEstimatedCurvature()
        {
            if (_prevAvgTwd97.Count < 3)
                return ;

            List<Vector> futureTwd97 = new List<Vector>(_prevTwd97);
            int lastIndex = _prevAvgTwd97.Count - 1;
            Vector prev = _prevAvgTwd97[lastIndex - 2];
            Vector cur = _prevAvgTwd97[lastIndex - 1];
            Vector future = _twd97;
            /*
            if (futureTwd97.Count >= POSITION_MOVING_AVERAGE_COUNT)
                futureTwd97.RemoveAt(0);
            futureTwd97.Add(_predictPosition);
            future.X = futureTwd97.Average(twd => twd.X);
            future.Y = futureTwd97.Average(twd => twd.Y);
            */
            _curvature = CalculateCurvature(prev, cur, future);
            AddCurvatureDf(_curvature - _roadCurvature);
        }
    }
}
