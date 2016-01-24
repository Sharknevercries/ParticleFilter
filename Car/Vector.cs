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

        public double X
        {
            get
            {
                return Value[0];
            }
            set
            {
                Value[0] = value;
            }
        }

        public double Y
        {
            get
            {
                return Value[1];
            }
            set
            {
                Value[1] = value;
            }
        }

        public double Z
        {
            get
            {
                return Value[2];
            }
            set
            {
                Value[2] = value;
            }
        }

        public Vector(int n)
        {
            Value = new double[n];
            for (int i = 0; i < n; i++)
                Value[i] = 0;
        }

        public Vector(double x, double y, double z) : this(3)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector(Vector v) : this(v.Length)
        {
            v.Value.CopyTo(Value, 0);
        }

        public Vector(double[] vector) : this(vector.Length)
        {
            vector.CopyTo(Value, 0);
        }        

        public void Normalization()
        {
            double factor = 1;
            if(Length == 2)
                factor = GetXYMagnitude();
            if (Length == 3)
                factor = GetXYZMagnitude();
            X /= factor;
            Y /= factor;
            Z /= factor;
        }        

        public double GetXYZMagnitude()
        {
            return Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2));
        }

        public double GetXYMagnitude()
        {
            return Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
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
                a.Y * b.Z - a.Z * b.Y,
                a.Z * b.X - a.X * b.Z,
                a.X * b.Y - a.Y * b.X);
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
