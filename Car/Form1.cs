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

        public Form1()
        {
            InitializeComponent();
            _acc = new Vector(3);
            _mag = new Vector(3);
            _gyr = new Vector(3);
            _gps = new Vector(2);
            _sf = new SensorFusion();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            /*
            btnStop.Enabled = true;
            btnStart.Enabled = false;
            timer1.Enabled = true;
            */
            testUse();
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
        }

        private void testUse()
        {
            _accs = System.IO.File.ReadAllLines("Acc.txt");
            _mags = System.IO.File.ReadAllLines("Mag.txt");
            _gyrs = System.IO.File.ReadAllLines("Gyr.txt");
            if (_accs.Length != _mags.Length || _accs.Length != _gyrs.Length)
                throw new InvalidOperationException();
            for (int i = 0; i < _accs.Length; i++)
            {
                string[] acc = _accs[i].Split(new char[] { ',' });
                string[] mag = _mags[i].Split(new char[] { ',' });
                string[] gyr = _gyrs[i].Split(new char[] { ',' });
                for (int j = 0; j < 3; j++)
                { 
                    _acc[j] = double.Parse(acc[j + 1]);
                    _mag[j] = double.Parse(mag[j + 1]);
                    _gyr[j] = double.Parse(gyr[j + 1]);
                }
                Vector accE = _sf.Calculate(new Vector(_acc), new Vector(_gyr), new Vector(_mag), long.Parse(acc[0]));
                lbInfo.Items.Add(accE[0] + ", " + accE[1] + ", " + accE[2]);
            }
        }
    }
}
