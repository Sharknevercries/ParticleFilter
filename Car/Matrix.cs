using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car
{
    class Matrix
    {
        public double[,] Value = new double[4, 4];

        public Matrix()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    Value[i, j] = 0;
        }

        public Matrix(Vector a, Vector b, Vector c) :this()
        {
            for(int i = 0; i < 3; i++)
            {
                Value[0, i] = a[i];
            }
            for (int i = 0; i < 3; i++)
            {
                Value[1, i] = b[i];
            }
            for (int i = 0; i < 3; i++)
            {
                Value[2, i] = c[i];
            }
        }

        public static Matrix operator % (Matrix a, Matrix b)
        {
            Matrix ret = new Matrix();
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    for (int k = 0; k < 4; k++)
                        ret[i, j] += a[i, k] * b[k, j];
            return ret;
        }

        public static Vector operator % (Matrix a, Vector b)
        {
            Vector ret = new Vector(3);
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    ret[i] += a[i, j] * b[j];
            return ret;
        }
        
        public static Matrix GetDiagonalMatrix()
        {
            Matrix ret = new Matrix();
            for (int i = 0; i < 4; i++)
                ret[i, i] = 1;
            return ret;
        }

        public double this[int index1, int index2]
        {
            get
            {
                return Value[index1, index2];
            }
            set
            {
                Value[index1, index2] = value;
            }
        }
    }
}
