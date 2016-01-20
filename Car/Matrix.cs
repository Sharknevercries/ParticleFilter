using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car
{
    class Matrix
    {
        public double[,] Value = new double[3, 3];

        public Matrix()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    Value[i, j] = 0;
        }

        public Matrix(Vector a, Vector b, Vector c)
        {
            for(int i = 0; i < 3; i++)
            {
                Value[0, i] = a.Value[i];
            }
            for (int i = 0; i < 3; i++)
            {
                Value[1,i] = b.Value[i];
            }
            for (int i = 0; i < 3; i++)
            {
                Value[2, i] = c.Value[i];
            }
        }

        public static Matrix Multiple(Matrix a, Matrix b)
        {
            Matrix ret = new Matrix();
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    for (int k = 0; k < 3; k++)
                        ret.Value[i, j] += a.Value[i, k] * b.Value[k, j];
            return ret;
        }

    }
}
