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
            for (int i = 0; i < n; i++)
                Value[i] = 0;
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

        public double GetMagnitude()
        {
            double ret = 0;
            for (int i = 0; i < Length; i++)
                ret += Math.Pow(Value[i], 2);
            return Math.Sqrt(ret);
        }

        /// <summary>
        /// Cross product.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Vector operator % (Vector a, Vector b)
        {
            if (a.Length != 3 && b.Length != 3)
                throw new NotSupportedException();
            return new Vector(
                a[1] * b[2] - a[2] * b[1],
                a[2] * b[0] - a[0] * b[2],
                a[0] * b[1] - a[1] * b[0]);
        }

        public static Vector operator + (Vector a, Vector b)
        {
            if (a.Length != b.Length)
                throw new InvalidOperationException();
            Vector ret = new Vector(a.Length);
            for (int i = 0; i < ret.Length; i++)
                ret[i] = a[i] + b[i];
            return ret;
        }

        public static Vector operator - (Vector a, Vector b)
        {
            if (a.Length != b.Length)
                throw new InvalidOperationException();
            Vector ret = new Vector(a.Length);
            for (int i = 0; i < ret.Length; i++)
                ret[i] = a[i] - b[i];
            return ret;
        }

        public double this[int index]
        {
            get
            {
                return Value[index];
            }
            set
            {
                Value[index] = value;
            }
        }
    }
}
