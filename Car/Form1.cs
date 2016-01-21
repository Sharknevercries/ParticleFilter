using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car
{
    public partial class Form1 : Form
    {
        private SensorFusion _sf;
        private string[] _accs;
        private string[] _mags;
        private string[] _gyrs;
        private string[] _gpss;
        private Vector _acc;
        private Vector _mag;
        private Vector _gyr;
        private Vector _gps;

        private int _counter = 0;

        public Form1()
        {
            InitializeComponent();
            _acc = new Vector(3);
            _mag = new Vector(3);
            _gyr = new Vector(3);
            _gps = new Vector(2);
            _sf = new SensorFusion();
            // test use
            _accs = System.IO.File.ReadAllLines("Acc.txt");
            _mags = System.IO.File.ReadAllLines("Mag.txt");
            _gyrs = System.IO.File.ReadAllLines("Gyr.txt");

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
            // TODO: Load data from ADB.
            // Calculate accE
            // convert GPS into grid position
            // 
            string[] acc = _accs[_counter].Split(new char[] { ',' });
            string[] mag = _mags[_counter].Split(new char[] { ',' });
            string[] gyr = _gyrs[_counter].Split(new char[] { ',' });
            for (int j = 0; j < 3; j++)
            {
                _acc[j] = double.Parse(acc[j + 1]);
                _mag[j] = double.Parse(mag[j + 1]);
                _gyr[j] = double.Parse(gyr[j + 1]);
            }
            lblAccelerometerX.Text = "" + _acc[0];
            lblAccelerometerY.Text = "" + _acc[1];
            lblAccelerometerZ.Text = "" + _acc[2];
            lblGyroscopeX.Text = "" + _gyr[0];
            lblGyroscopeY.Text = "" + _gyr[1];
            lblGyroscopeZ.Text = "" + _gyr[2];
            lblMagnetometerX.Text = "" + _mag[0];
            lblMagnetometerY.Text = "" + _mag[1];
            lblMagnetometerZ.Text = "" + _mag[2];
            _counter++;
            lblLongtitude.Text = "" + _counter;
            //Vector accE = _sf.Calculate(new Vector(_acc), new Vector(_gyr), new Vector(_mag), long.Parse(acc[0]));
            //lbInfo.Items.Add(accE[0] + ", " + accE[1] + ", " + accE[2]);
        }

        private void testUse()
        {            
            
        }      
    }
}
