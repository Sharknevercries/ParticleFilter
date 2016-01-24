using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car
{
    class SensorFusion
    {
        private long _prevTimeStamp;
        private bool _initState;

        private Matrix _gyroMatrix;
        private Vector _gyroOrientation;
        private List<Vector> _prevAcceleration;

        private System.Windows.Forms.ListBox _logger;
        
        public SensorFusion()
        {
            Initialize();
        }

        public void Initialize()
        {
            _gyroMatrix = Matrix.GetDiagonalMatrix();
            _prevAcceleration = new List<Vector>();
            _prevTimeStamp = 0;
            _initState = true;
        }
        
        /// <summary>
        /// Calculate the acceleration of e-frame
        /// </summary>
        /// <param name="acc"></param>
        /// <param name="gyr"></param>
        /// <param name="mag"></param>
        /// <param name="time_diff"></param>
        /// <param name="filter_coef">Fusion coefficient</param>
        /// <param name="shift_num">Find gravity from the mininmal of past acc data</param>
        /// <returns></returns>
        public Vector Calculate(Vector acc, Vector gyr, Vector mag, long curTimeStamp, double filter_coef = 0.99, int shift_num = 500)
        {
            _prevAcceleration.Add(acc);
            if (_prevAcceleration.Count > shift_num)
                _prevAcceleration.RemoveAt(0);
            double minAcc = _prevAcceleration.Select(t => t.GetXYZMagnitude()).Min();
            Vector gravity = _prevAcceleration.Find(t => t.GetXYZMagnitude() == minAcc);
            Matrix rotationMatrix = GetRotationMatrix(gravity, mag);
            Vector accMagOrientation = GetOrientation(rotationMatrix);
            
            if (_initState)
            {
                Matrix initMatrix = GetRotationMatrixFromOrientation(accMagOrientation);
                _gyroMatrix = _gyroMatrix % initMatrix;
                _gyroOrientation = GetOrientation(_gyroMatrix);
                _initState = false;
            }

            Vector ret = ComputeAccelerationEarth(acc, gravity);
            Vector deltaVector = new Vector(4);
            if (_prevTimeStamp != 0)
            {
                double dt = (curTimeStamp - _prevTimeStamp) / 1000000000.0;
                deltaVector = GetRotationVectorFromGyro(gyr, dt / 2.0);
            }
            Matrix deltaMatrix = GetRotationMatrixFromVector(deltaVector);
            _gyroMatrix = _gyroMatrix % deltaMatrix;
            _gyroOrientation = GetOrientation(_gyroMatrix);
            _prevTimeStamp = curTimeStamp;

            Vector fusedOrientation = new Vector(3);
            for (int i = 0; i < 3; i++)
            {
                if(_gyroOrientation[i] < -0.5 * Math.PI && accMagOrientation[i] > 0)
                {
                    fusedOrientation[i] = filter_coef * (_gyroOrientation[i] + 2 * Math.PI) + (1 - filter_coef) * accMagOrientation[i];
                    if (fusedOrientation[i] > Math.PI)
                        fusedOrientation[i] -= 2 * Math.PI;
                }
                else if(accMagOrientation[i] < -0.5 * Math.PI && _gyroOrientation[i] > 0)
                {
                    fusedOrientation[i] = filter_coef * _gyroOrientation[i] + (1 - filter_coef) * (accMagOrientation[i] + 2 * Math.PI);
                    if (fusedOrientation[i] > Math.PI)
                        fusedOrientation[i] -= 2 * Math.PI;
                }
                else
                {
                    fusedOrientation[i] = filter_coef * _gyroOrientation[i] + (1 - filter_coef) * accMagOrientation[i];
                }
            }
            _gyroMatrix = GetRotationMatrixFromOrientation(fusedOrientation);
            fusedOrientation.Value.CopyTo(_gyroOrientation.Value, 0);

            return ret;
        }

        private Vector ComputeAccelerationEarth(Vector v, Vector gravity)
        {
            Vector ret = new Vector(4);
            Vector tmp = _gyroMatrix % (v - gravity);
            tmp.Value.CopyTo(ret.Value, 0);
            ret.Value[3] = _gyroOrientation.Value[0] * 180.0 / Math.PI;
            return ret;
        }

        private static Matrix GetRotationMatrix(Vector gravity, Vector geomanetic)
        {
            Vector A = new Vector(gravity);
            Vector E = new Vector(geomanetic);
            Vector H = E % A;
            double normH = H.GetXYZMagnitude();
            if (normH < 0.1)
                return null;
            H.Normalization();
            A.Normalization();
            Vector M = A % H;
            Matrix ret = new Matrix(H, M, A);
            return ret;
        }

        private static Vector GetRotationVectorFromGyro(Vector gyro, double time)
        {
            Vector tmp = new Vector(gyro);
            double magnitude = tmp.GetXYZMagnitude();
            if (magnitude > 0.00000001)
                tmp.Normalization();
            double thetaOverTwo = magnitude * time;
            double sinThetaOverTwo = Math.Sin(thetaOverTwo);
            double cosThetaOverTwo = Math.Cos(thetaOverTwo);
            Vector ret = new Vector(4);
            for (int i = 0; i < 3; i++)
                ret[i] = sinThetaOverTwo * tmp[i];
            ret[3] = cosThetaOverTwo;
            return ret;
        }

        private static Matrix GetRotationMatrixFromOrientation(Vector a)
        {
            double sinX = Math.Sin(a.Value[1]);
            double cosX = Math.Cos(a.Value[1]);
            double sinY = Math.Sin(a.Value[2]);
            double cosY = Math.Cos(a.Value[2]);
            double sinZ = Math.Sin(a.Value[0]);
            double cosZ = Math.Cos(a.Value[0]);
            Matrix xM = new Matrix(
                new Vector(1, 0, 0),
                new Vector(0, cosX, sinX),
                new Vector(0, -sinX, cosX));
            Matrix yM = new Matrix(
                new Vector(cosY, 0, sinY),
                new Vector(0, 1, 0),
                new Vector(-sinY, 0, cosY));
            Matrix zM = new Matrix(
                new Vector(cosZ, sinZ, 0),
                new Vector(-sinZ, cosZ, 0),
                new Vector(0, 0, 1));
            return zM % (xM % yM);
        }

        private static Matrix GetRotationMatrixFromVector(Vector v)
        {
            double q0 = 0;
            double q1 = v.Value[0];
            double q2 = v.Value[1];
            double q3 = v.Value[2];
            if (v.Length == 4)
                q0 = v.Value[3];
            else
            {
                q0 = 1 - (q1 * q1 + q2 * q2 + q3 * q3);
                if (q0 > 0)
                    q0 = Math.Sqrt(q0);
                else
                    q0 = 0;
            }
            double sq_q1 = 2 * q1 * q1;
            double sq_q2 = 2 * q2 * q2;
            double sq_q3 = 2 * q3 * q3;
            double q1_q2 = 2 * q1 * q2;
            double q3_q0 = 2 * q3 * q0;
            double q1_q3 = 2 * q1 * q3;
            double q2_q0 = 2 * q2 * q0;
            double q2_q3 = 2 * q2 * q3;
            double q1_q0 = 2 * q1 * q0;
            return new Matrix(
                new Vector(1 - sq_q2 - sq_q3, q1_q2 - q3_q0, q1_q3 + q2_q0),
                new Vector(q1_q2 + q3_q0, 1 - sq_q1 - sq_q3, q2_q3 - q1_q0),
                new Vector(q1_q3 - q2_q0, q2_q3 + q1_q0, 1 - sq_q1 - sq_q2));
        }

        private static Vector GetOrientation(Matrix r)
        {
            Vector ret = new Vector(3);
            ret.Value[0] = Math.Atan2(r.Value[0, 1], r.Value[1, 1]);
            ret.Value[1] = Math.Asin(-r.Value[2, 1]);
            ret.Value[2] = Math.Atan2(-r.Value[2, 0], r.Value[2, 2]);
            return ret;
        }

        public void SetLogger(System.Windows.Forms.ListBox logger)
        {
            _logger = logger;
        }
    }
}
