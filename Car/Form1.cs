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

        public Form1()
        {
            InitializeComponent();
            _sf = new SensorFusion();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            /*
            btnStop.Enabled = true;
            btnStart.Enabled = false;
            timer1.Enabled = true;
            */
            double[] ret = GPSConverter.GetTWD97(24.82831645, 121.01274986);
            lbInfo.Items.Add(ret[0]);
            lbInfo.Items.Add(ret[1]);
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
    }
}
