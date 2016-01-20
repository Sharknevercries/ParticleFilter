using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car
{
    class Vector
    {
        public int Length
        {
            get
            {
                return Value.Length;
            }
        }

        public double[] Value;

        public Vector(int n)
        {
            Value = new double[n];
        }

        public Vector(double x, double y, double z) : this(3)
        {
            Value[0] = x;
            Value[1] = y;
            Value[2] = z;
        }

        public Vector(Vector v) : this(v.Length)
        {
            v.Value.CopyTo(Value, 0);
        }

        public Vector(double[] vector) : this(vector.Length)
        {
            vector.CopyTo(Value, 0);
        }

        public double NormalizeVector()
        {
            double factor = 0;
            for (int i = 0; i < 3; i++)
            {
                factor += Math.Pow(Value[i], 2);
            }
            factor = Math.Sqrt(factor);
            return factor;
        }

        public void Normalization()
        {
            double factor = NormalizeVector();
            for (int i = 0; i < 3; i++)
            {
                Value[i] /= factor;
            }
        }

        public static Vector Cross(Vector a, Vector b)
        {
            return new Vector(
                a.Value[1] * b.Value[2] - a.Value[2] * b.Value[1],
                a.Value[2] * b.Value[0] - a.Value[0] * b.Value[2],
                a.Value[0] * b.Value[1] - a.Value[1] * b.Value[0]);
        }

    }
}
