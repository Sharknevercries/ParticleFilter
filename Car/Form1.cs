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

namespace Car
{
    public partial class Form1 : Form
    {
        private readonly string SENSOR_FILE_PARTH = "/storage/sdcard0/DataCollection/01_23-13:29:17/";
        private readonly string PC_FILE_PATH = @"C:\Users\Zheng-Yuan\Documents\Visual Studio 2015\Projects\ParticleFilter\Car\";
        private readonly string[] FILE_NAME = { "Acc.txt", "Gyr.txt", "Mag.txt", "GPS.txt" };
        private readonly int MOVING_AVERAGE_COUNT = 3;
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
        private long _IMUTimeStamp;
        private Vector _acc;
        private Vector _mag;
        private Vector _gyr;
        private long _gpsTimeStamp;
        private Vector _gps;
        private Vector _twd97;
        private double _speed;

        private int _counter = 0;
        private int _gpsCounter = 0;

        private Vector _accE;
        private Vector _estimatedPosition;
        private Vector _roadCurvature;

        private List<Vector> _prevEstimatedPosition;
        
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
            _speed = 0;
            _sf = new SensorFusion();
            _pf = new ParticleFilter();
            _prevEstimatedPosition = new List<Vector>();
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
            long currentIMUTimeStamp = long.Parse(acc[0]);
            long currentGPSTimeStamp = long.Parse(gps[0]);
            if(_gpsTimeStamp == 0 || _gpsTimeStamp < currentGPSTimeStamp)
            {
                double[] ret = GPSConverter.GetTWD97(_gps[0], _gps[1]);
                _twd97.X = ret[0];
                _twd97.Y = ret[1];
                _gpsTimeStamp = currentGPSTimeStamp;
            }
            if (_startTimeStamp == 0)
                _startTimeStamp = _IMUTimeStamp;
            if(_IMUTimeStamp == 0 || _IMUTimeStamp < currentIMUTimeStamp)
            {                
                _accE = _sf.Calculate(new Vector(_acc), new Vector(_gyr), new Vector(_mag), currentIMUTimeStamp);
                Vector nextEstimatedPosition = _pf.Calculate(_accE, currentIMUTimeStamp, _twd97, _gpsTimeStamp);
                if (_prevEstimatedPosition.Count >= MOVING_AVERAGE_COUNT)
                    _prevEstimatedPosition.RemoveAt(0);
                _prevEstimatedPosition.Add(nextEstimatedPosition);
                if(_estimatedPosition != null)
                {
                    _speed = (Math.Sqrt(Math.Pow(nextEstimatedPosition.X - _estimatedPosition.X, 2) + Math.Pow(nextEstimatedPosition.Y - _estimatedPosition.Y, 2)) / ((currentIMUTimeStamp - _IMUTimeStamp) / 1000.0)) * 3600.0 / 1000.0;
                }
                _estimatedPosition = nextEstimatedPosition;
                _IMUTimeStamp = currentIMUTimeStamp;
            }
            if (_IMUTimeStamp > _gpsTimeStamp)
                _gpsCounter++;
            _counter++;
            ShowResult();
        }

        private void SetGPSData()
        {

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
            if(_estimatedPosition!= null)
            {
                lblEstimatedX.Text = "" + _estimatedPosition.X;
                lblEstimatedY.Text = "" + _estimatedPosition.Y;
            }
            if(_twd97 != null)
            {
                lblGPSX.Text = "" + _twd97.X;
                lblGPSY.Text = "" + _twd97.Y;
            }
            lblV.Text = "" + _speed;
            lblEclipseTime.Text = "" + (_IMUTimeStamp - _startTimeStamp) / 1000.0;
          
        }

        public void Logger(string s)
        {
            lbInfo.Items.Add(s);
        }


    }
}
