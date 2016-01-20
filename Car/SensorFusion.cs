using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car
{
    class SensorFusion
    {
        public static Matrix GetRotationMatrix(Vector gravity, Vector geomanetic)
        {
            Vector A = new Vector(gravity);
            Vector E = new Vector(geomanetic);
            Vector H = Vector.Cross(E, A);
            double normH = H.NormalizeVector();
            if (normH < 0.1)
                return null;
            H.Normalization();
            A.Normalization();
            Vector M = Vector.Cross(A, H);
            Matrix ret = new Matrix(H, M, A);
            return ret;
        }

        public static Vector GetRotationVectorFromGyro(Vector gyro, double time)
        {
            Vector tmp = new Vector(gyro);
            double magnitude = tmp.NormalizeVector();
            if (magnitude > 0.00000001)
                tmp.Normalization();
            double thetaOverTwo = magnitude * time;
            double sinThetaOverTwo = Math.Sin(thetaOverTwo);
            double cosThetaOverTwo = Math.Cos(thetaOverTwo);
            Vector ret = new Vector(4);
            for (int i = 0; i < 3; i++)
                ret.Value[i] = sinThetaOverTwo * tmp.Value[i];
            ret.Value[3] = cosThetaOverTwo;
            return ret;
        }

        public static Matrix GetRotationMatrixFromOrientation(Vector a)
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
            return Matrix.Multiple(zM, Matrix.Multiple(xM, yM));
        }

        public static Matrix GetRotationMatrixFromVector(Vector v)
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

        public static Vector GetOrientation(Matrix r)
        {
            Vector ret = new Vector(3);
            ret.Value[0] = Math.Atan2(r.Value[0, 1], r.Value[1, 1]);
            ret.Value[1] = Math.Asin(-r.Value[2, 1]);
            ret.Value[2] = Math.Atan2(-r.Value[2, 0], r.Value[2, 2]);
            return ret;
        }
    }
}
