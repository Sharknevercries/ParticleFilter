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
        private readonly string SENSOR_FILE_PARTH = "/storage/sdcard0/DataCollection/01_23-13:29:17/";
        private readonly string PC_FILE_PATH = @"C:\Users\Zheng-Yuan\Documents\Visual Studio 2015\Projects\ParticleFilter\Car\";
        private readonly string WEB_PATH = @"localhost/getcurve.php";
        private readonly string[] FILE_NAME = { "Acc.txt", "Gyr.txt", "Mag.txt", "GPS.txt" };
        private readonly int POSITION_MOVING_AVERAGE_COUNT = 9;
        private readonly double SPEED_THRESHOLD = 15.0;
        private readonly double CURVATURE_THRESHOLD = 0.02;
        private readonly long FUTURE_TIME = 25;
        private SensorFusion _sf;
        private ParticleFilter _pf;

        private string[] _accs;
        private string[] _mags;
        private string[] _gyrs;
        private string[] _gpss;
        //private string _accs;
        //private string _mags;
        //private string _gyrs;
        //private string _gpss;
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

        private int _counter = 0;
        private int _gpsCounter = 0;

        private Vector _accE;

        private List<Vector> _prevEstimatedPosition;
        private List<Vector> _prevAvgEstimatedPosition;
        private Vector _predictPosition;

        private List<Vector> _prevTwd97;
        private List<double> _prevVelocity;
        private double _speed;

        private List<double> _prevCurvature;
        private double _curvature;

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
            _prevEstimatedPosition = new List<Vector>();
            _prevAvgEstimatedPosition = new List<Vector>();
            _prevTwd97 = new List<Vector>();
            _prevVelocity = new List<double>();
            _prevCurvature = new List<double>();
            _prevCurvatureDf = new List<double>();
            _pf.SetLogger(lbInfo);
            // test use
            _accs = File.ReadAllLines("Acc.txt");
            _mags = File.ReadAllLines("Mag.txt");
            _gyrs = File.ReadAllLines("Gyr.txt");
            _gpss = File.ReadAllLines("GPS.txt");
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
            //DownloadData();
            //LoadData();
            string[] acc = _accs[_counter].Split(new char[] { ',' });
            string[] mag = _mags[_counter].Split(new char[] { ',' });
            string[] gyr = _gyrs[_counter].Split(new char[] { ',' });
            string[] gps = _gpss[_gpsCounter].Split(new char[] { ',' });
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
                ReadRoadCurvature(_gps[0], _gps[1]);
                _twd97.X = ret[0];
                _twd97.Y = ret[1];
                _prevTwd97.Add(new Vector(_twd97));
                if(_prevTwd97.Count >= 3)
                    CalculateVelocity();
                _gpsTimeStamp = _currentGPSTimeStamp;
            }
            if (_startTimeStamp == 0)
                _startTimeStamp = _IMUTimeStamp;
            if(_IMUTimeStamp == 0 || _IMUTimeStamp < _currentIMUTimeStamp)
            {                
                _accE = _sf.Calculate(new Vector(_acc), new Vector(_gyr), new Vector(_mag), _currentIMUTimeStamp);
                _pf.Update(_accE, _currentIMUTimeStamp, _twd97, _gpsTimeStamp);
                CalculateEstimatedPosition(_pf.GetCurrentPosition());
                _predictPosition = _pf.GetEstimatedPosition(FUTURE_TIME);
                CalculateCurvature();
                _IMUTimeStamp = _currentIMUTimeStamp;
            }
            if (_IMUTimeStamp > _gpsTimeStamp)
                _gpsCounter++;
            _counter++;
            ShowResult();
        }

        private void ReadRoadCurvature(double lat, double lon)
        {
            WebRequest ws = WebRequest.Create(WEB_PATH + "?lat=" + lat + "&lon=" + lon);
            Stream st = ws.GetResponse().GetResponseStream();
            StreamReader sr = new StreamReader(st, Encoding.GetEncoding("UTF-8"));
            _roadCurvature = double.Parse(sr.ReadLine());
        }

        private void CalculateEstimatedPosition(Vector predictEstimatedPosition)
        {
            Vector nextAvgEstimatedPosition = new Vector(2);
            if (_prevEstimatedPosition.Count >= POSITION_MOVING_AVERAGE_COUNT)
                _prevEstimatedPosition.RemoveAt(0);
            _prevEstimatedPosition.Add(predictEstimatedPosition);
            nextAvgEstimatedPosition.X = _prevEstimatedPosition.Average(p => p.X);
            nextAvgEstimatedPosition.Y = _prevEstimatedPosition.Average(p => p.Y);
            if (_prevAvgEstimatedPosition.Count >= POSITION_MOVING_AVERAGE_COUNT)
                _prevAvgEstimatedPosition.RemoveAt(0);
            _prevAvgEstimatedPosition.Add(nextAvgEstimatedPosition);
        }

        /// <summary>
        /// 取GPS第一和第三新的座標位置去計算速率，當前速率取前三筆速率的平均值
        /// </summary>
        private void CalculateVelocity()
        {
            if (_prevTwd97.Count >= 4)
                _prevTwd97.RemoveAt(0);
            double dx = _prevTwd97[2].X - _prevTwd97[0].X;
            double dy = _prevTwd97[2].Y - _prevTwd97[0].Y;
            double speed = Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2)) / 2.0 * 3600 / 1000.0;
            _prevVelocity.Add(speed);
            if (_prevVelocity.Count >= 4)
                _prevVelocity.RemoveAt(0);
            _speed = _prevVelocity.Average();
        }

        private void DownloadData()
        {
            AdbServer.StartServer(@"C:\adb\adb.exe", restartServerIfNewer: true);
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
            //_accs = File.ReadLines("Acc.txt").Last();
            //_mags = File.ReadLines("Mag.txt").Last();
            //_gyrs = File.ReadLines("Gyr.txt").Last();
            //_gpss = File.ReadLines("GPS.txt").Last();
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
                    lblResult.Text = "Turn Right";
                }
                else if (_curvatureDf <= - CURVATURE_THRESHOLD)
                {
                    lblResult.Text = "Turn Left";
                }
                else
                {
                    lblResult.Text = "Straight";
                }
            }
            else
            {
                lblResult.Text = "Straight";
            }
        }
        
        /// <summary>
        /// 以位置去計算當前曲率，算完後再與之前數筆曲率做一次平均
        /// </summary>
        /// <returns></returns>
        private void CalculateCurvature()
        {
            Vector avgPredictPosition = new Vector(2);
            int count = _prevAvgEstimatedPosition.Count;
            if (count < 2)
            {
                return ;
            }
            avgPredictPosition.X = _prevAvgEstimatedPosition.Last().X * count;
            avgPredictPosition.Y = _prevAvgEstimatedPosition.Last().Y * count;
            if(count >= POSITION_MOVING_AVERAGE_COUNT)
            {
                avgPredictPosition.X -= _prevAvgEstimatedPosition[0].X;
                avgPredictPosition.Y -= _prevAvgEstimatedPosition[0].Y;
                count--;
            }
            avgPredictPosition.X += _predictPosition.X;
            avgPredictPosition.Y += _predictPosition.Y;
            count++;
            avgPredictPosition.X /= count;
            avgPredictPosition.Y /= count;

            count = _prevAvgEstimatedPosition.Count - 1;
            double a = Math.Sqrt(Math.Pow(_prevAvgEstimatedPosition[count - 1].X - _prevAvgEstimatedPosition[count].X, 2) + Math.Pow(_prevAvgEstimatedPosition[count - 1].Y - _prevAvgEstimatedPosition[count].Y, 2));
            double b = Math.Sqrt(Math.Pow(_prevAvgEstimatedPosition[count].X - avgPredictPosition.X, 2) + Math.Pow(_prevAvgEstimatedPosition[count].Y - avgPredictPosition.Y, 2));
            double c = Math.Sqrt(Math.Pow(_prevAvgEstimatedPosition[count - 1].X - avgPredictPosition.X, 2) + Math.Pow(_prevAvgEstimatedPosition[count - 1].Y - avgPredictPosition.Y, 2));
            double theta = (a * a + b * b - c * c) / (2 * a * b);
            _curvature = 1.0 / (c / (2 * Math.Sqrt((1 - theta * theta))));
            double x1 = _prevAvgEstimatedPosition[count].X - _prevAvgEstimatedPosition[count - 1].X;
            double x2 = avgPredictPosition.X - _prevAvgEstimatedPosition[count].X;
            double y1 = _prevAvgEstimatedPosition[count].Y - _prevAvgEstimatedPosition[count - 1].Y;
            double y2 = avgPredictPosition.Y - _prevAvgEstimatedPosition[count].Y;
            if (x1 * y2 - x2 * y1 > 0)
                _curvature *= -1;

            if (_prevCurvatureDf.Count >= POSITION_MOVING_AVERAGE_COUNT)
                _prevCurvatureDf.RemoveAt(0);
            _prevCurvatureDf.Add(_curvature - _roadCurvature);
            _curvatureDf = _prevCurvatureDf.Average();
        }

    }
}
