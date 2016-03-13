using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.Distributions;

namespace Car
{
    class ParticleFilter
    {
        public const int MAX_SIZE = 1000;
        public const double ANG_EPS = Math.PI / 3;
        public const double V_EPS = 0.15;
        public const double ACC_EPS = 0.3;
        public const double GPS_EPS = 10;
        public const double ATTENUATION = 0.75;

        private long _prevTimeStamp;
        private List<Particle> _particles;
        private System.Windows.Forms.ListBox _logger;
        private Vector _prevAccE;

        public ParticleFilter()
        {
            _particles = new List<Particle>();
            for (int i = 0; i < MAX_SIZE; i++)
                _particles.Add(new Particle());
            _prevTimeStamp = 0;
        }

        public void Update(Vector accE, long IMUTimeStamp, Vector gps = null, long gpsTimeStamp = 0)
        {
            if (_prevTimeStamp == 0)
            {
                _prevTimeStamp = IMUTimeStamp;
                return;
            }

            if(gps != null && gpsTimeStamp < IMUTimeStamp)
            {
                MoveParticles(accE, gpsTimeStamp - _prevTimeStamp);
                TrimParticles(gps);
                _prevTimeStamp = gpsTimeStamp;
            }

            MoveParticles(accE, IMUTimeStamp - _prevTimeStamp);
            //Resample();
            _prevTimeStamp = IMUTimeStamp;
            _prevAccE = new Vector(accE);
        }      

        public Vector GetCurrentPosition()
        {
            Vector ret = new Vector(2);
            ret.X = _particles.Average(p => p.X);
            ret.Y = _particles.Average(p => p.Y);
            return ret;
        }

        public Vector GetEstimatedPosition(long timeEclipse)
        {
            Vector ret = new Vector(2);
            if (_prevAccE == null)
            {
                return ret;
            }
            List<Particle> futureParticles = new List<Particle>();
            foreach(var p in _particles)
            {
                futureParticles.Add(new Particle(p));
            }
            foreach(var p in futureParticles)
            {
                p.Move(_prevAccE, timeEclipse / 1000.0);
            }
            ret.X = futureParticles.Average(p => p.X);
            ret.Y = futureParticles.Average(p => p.Y);
            return ret;
        }

        /// <summary>
        /// Remove particles which are outside gps eps and supply particles up to MAX_SIZE.
        /// </summary>
        /// <param name="gps"></param>
        private void TrimParticles(Vector gps)
        {
            _particles.RemoveAll(t => Math.Pow((t.X - gps.X), 2) + Math.Pow((t.Y - gps.Y), 2) > Math.Pow(GPS_EPS, 2));
            _logger.Items.Add(_particles.Count);
            if(_particles.Count == 0)
            {
                while (_particles.Count < MAX_SIZE)
                {
                    _particles.Add(new Particle(gps));
                }
            }
            else
            {
                int remain = _particles.Count;
                while(_particles.Count < MAX_SIZE)
                {
                    int idx = (int)Math.Floor(ContinuousUniform.Sample(0, remain - 1e-9));
                    _particles.Add(new Particle(_particles[idx]));
                }
            }
        }
        
        private void MoveParticles(Vector accE, long timeEclipse)
        {
            foreach (var particle in _particles)
            {
                particle.Move(accE, timeEclipse / 1000.0);
            }
        }  

        private void Resample()
        {
            List<Particle> newParticles = new List<Particle>(MAX_SIZE);
            double[] cdf = new double[MAX_SIZE + 1];
            cdf[0] = 0.0;
            for (int i = 1; i <= MAX_SIZE; i++)
            {
                cdf[i] = cdf[i - 1] + _particles[i - 1].Weight;
            }
            double u = ContinuousUniform.Sample(0, 1.0 / MAX_SIZE);
            int k = 1;
            for(int i = 0; i < MAX_SIZE; i++)
            {
                double v = u + i * (1.0 / MAX_SIZE);
                while (v > cdf[k])
                    k++;
                newParticles.Add(new Particle(_particles[k - 1]));
            }
            _particles = newParticles;
        }

        public void SetLogger(System.Windows.Forms.ListBox logger)
        {
            _logger = logger;
        }

    }

    class Particle
    {
        public double X;
        public double Y;

        /// <summary>
        /// m/s
        /// </summary>
        public double Vx;

        /// <summary>
        /// m/s
        /// </summary>
        public double Vy;

        /// <summary>
        /// This value dosen't do anything. For the use of future edition.
        /// </summary>
        public double Weight;

        public Particle() : this(0, 0, 0, 0, 1.0 / ParticleFilter.MAX_SIZE) { }

        public Particle(double x, double y, double vx, double vy, double weight)
        {
            X = x;
            Y = y;
            Vx = vx;
            Vy = vy;
            Weight = weight;
        }

        public Particle(Vector gps) : this(0, 0, 0, 0, 1.0 / ParticleFilter.MAX_SIZE)
        {
            double theta = ContinuousUniform.Sample(0, 2 * Math.PI);
            double magnitude = Math.Sqrt(ContinuousUniform.Sample(0, 1)) * ParticleFilter.GPS_EPS;
            X = gps.X + magnitude * Math.Cos(theta);
            Y = gps.Y + magnitude * Math.Sin(theta);
        }

        public Particle(Particle particle) : this(particle.X, particle.Y, particle.Vx, particle.Vy, particle.Weight)
        {
        }

        /// <summary>
        /// Move the particle.
        /// </summary>
        /// <param name="timeEclipse">ms</param>
        public void Move(Vector acc, double timeEclipse)
        {
            double magnitude = acc.GetXYMagnitude();
            double theta = ParseAzimuth(acc[3]) / 180.0 * Math.PI + ContinuousUniform.Sample(-ParticleFilter.ANG_EPS, ParticleFilter.ANG_EPS);
            double rand_magitude = magnitude + magnitude * ContinuousUniform.Sample(-ParticleFilter.ACC_EPS, ParticleFilter.ACC_EPS);
            double ax = Math.Cos(theta) * rand_magitude;
            double ay = Math.Sin(theta) * rand_magitude;
            //double ax = acc.X;
            //double ay = acc.Y;
            X += (2 * Vx + ax) * timeEclipse / 2.0;
            Y += (2 * Vy + ay) * timeEclipse / 2.0;
            Vx += ax * timeEclipse;
            Vy += ay * timeEclipse;
        }

        private static double ParseAzimuth(double azimuth)
        {
            if (azimuth <= 0)
                return -azimuth + 90;
            else if (azimuth <= 90)
                return 90 - azimuth;
            else
                return azimuth - 90;
        }

    }
}
