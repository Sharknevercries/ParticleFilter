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
        public const int MAX_SIZE = 3000;
        public const double ANG_EPS = Math.PI / 3;
        public const double ACC_EPS = 0.30;
        public const double GPS_EPS = 5;

        private long _prevTimeStamp;
        private List<Particle> _particles;

        ParticleFilter()
        {
            _particles = new List<Particle>();
            for (int i = 0; i < MAX_SIZE; i++)
                _particles.Add(new Particle());
            _prevTimeStamp = 0;
        }

        public Vector Calculate(Vector accE, long curTimeStamp)
        {
            if(_prevTimeStamp == 0)
            {
                _prevTimeStamp = curTimeStamp;
                return new Vector(2);
            }

            foreach(var particle in _particles)
            {
                particle.Acc = accE;
                particle.Move((curTimeStamp - _prevTimeStamp) / 1000.0);
            }

            Resample();
            _prevTimeStamp = curTimeStamp;

            Vector ret = new Vector(2);
            ret[0] = _particles.Average(p => p.X);
            ret[1] = _particles.Average(p => p.Y);
            return ret;
        }

        /// <summary>
        /// Use gps observation to fix particles.
        /// </summary>
        /// <param name="gps">x, y</param>
        public void TrimParticle(Vector gps)
        {

        }

        private void Resample()
        {
            List<Particle> newParticles = new List<Particle>(MAX_SIZE);
            double[] cdf = new double[MAX_SIZE];
            cdf[0] = 0.0;
            for(int i = 1;i<= MAX_SIZE; i++)
            {
                cdf[i] = cdf[i - 1] + _particles[i - 1].Weight;
            }
            double u = ContinuousUniform.Sample(0, 1.0 / MAX_SIZE);
            int k = 1;
            for(int i = 0; i < MAX_SIZE; i++)
            {
                double v = u + i * (1 / MAX_SIZE);
                while (v > cdf[k])
                    k++;
                newParticles.Add(_particles[k - 1]);
            }
            _particles = newParticles;
        }

    }

    class Particle
    {
        public double X;
        public double Y;
        public double Vx;
        public double Vy;
        public double Weight;
        public Vector Acc;

        public Particle() : this(0, 0, 0, 0, 1.0 / ParticleFilter.MAX_SIZE) { }

        public Particle(double x, double y, double vx, double vy, double weight)
        {
            X = x;
            Y = y;
            Vx = vx;
            Vy = vy;
            Weight = weight;
        }

        public Particle(Vector gps) : this(0, 0, 0, 0, 0)
        {
            double theta = ContinuousUniform.Sample(0, 2 * Math.PI);
            double magnitude = Math.Sqrt(ContinuousUniform.Sample(0, 1)) * ParticleFilter.GPS_EPS;
            X = gps.X + magnitude * Math.Cos(theta);
            Y = gps.Y + magnitude * Math.Sin(theta);
        }

        /// <summary>
        /// Move the particle.
        /// </summary>
        /// <param name="timeEclipse">ms</param>
        public void Move(double timeEclipse)
        {
            double magnitude = Acc.GetXYMagnitude();
            double theta = ParseAzimuth(Acc[3]) / 180.0 * Math.PI + ContinuousUniform.Sample(-ParticleFilter.ANG_EPS, ParticleFilter.ANG_EPS);
            double rand_magitude = magnitude + magnitude * ContinuousUniform.Sample(-ParticleFilter.ACC_EPS, ParticleFilter.ACC_EPS);
            double ax = Math.Cos(theta) * rand_magitude;
            double ay = Math.Sin(theta) * rand_magitude;
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
