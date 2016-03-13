using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car
{
    public class GPSConverter
    {
        /// <summary>
        /// Ref: http://wangshifuola.blogspot.tw/2010/08/twd97wgs84-wgs84twd97.html
        /// </summary>

        public static double[] GetTWD97(double lat, double lon)
        {
            const double a = 6378137.0;
            const double b = 6356752.34245;
            const double long0 = 121.0 / 180.0 * Math.PI;
            const double k0 = 0.9999;
            const double dx = 250000;

            lat = lat / 180.0 * Math.PI;
            lon = lon / 180.0 * Math.PI;

            double e = Math.Pow((1 - Math.Pow(b, 2) / Math.Pow(a, 2)), 0.5);
            double e2 = Math.Pow(e, 2) / (1 - Math.Pow(e, 2));
            double n = (a - b) / (a + b);
            double nu = a / Math.Pow((1 - (Math.Pow(e, 2)) * (Math.Pow(Math.Sin(lat), 2))), 0.5);
            double p = lon - long0;

            double A = a * (1 - n + (5 / 4) * (Math.Pow(n, 2) - Math.Pow(n, 3)) + (81 / 64) * (Math.Pow(n, 4) - Math.Pow(n, 5)));
            double B = (3 * a * n / 2.0) * (1 - n + (7 / 8.0) * (Math.Pow(n, 2) - Math.Pow(n, 3)) + (55 / 64.0) * (Math.Pow(n, 4) - Math.Pow(n, 5)));
            double C = (15 * a * (Math.Pow(n, 2)) / 16.0) * (1 - n + (3 / 4.0) * (Math.Pow(n, 2) - Math.Pow(n, 3)));
            double D = (35 * a * (Math.Pow(n, 3)) / 48.0) * (1 - n + (11 / 16.0) * (Math.Pow(n, 2) - Math.Pow(n, 3)));
            double E = (315 * a * (Math.Pow(n, 4)) / 51.0) * (1 - n);

            double S = A * lat - B * Math.Sin(2 * lat) + C * Math.Sin(4 * lat) - D * Math.Sin(6 * lat) + E * Math.Sin(8 * lat);

            //計算Y值
            double K1 = S * k0;
            double K2 = k0 * nu * Math.Sin(2 * lat) / 4.0;
            double K3 = (k0 * nu * Math.Sin(lat) * (Math.Pow(Math.Cos(lat), 3)) / 24.0) * (5 - Math.Pow(Math.Tan(lat), 2) + 9 * e2 * Math.Pow((Math.Cos(lat)), 2) + 4 * (Math.Pow(e2, 2)) * (Math.Pow(Math.Cos(lat), 4)));
            double y = K1 + K2 * (Math.Pow(p, 2)) + K3 * (Math.Pow(p, 4));

            //計算X值
            double K4 = k0 * nu * Math.Cos(lat);
            double K5 = (k0 * nu * (Math.Pow(Math.Cos(lat), 3)) / 6.0) * (1 - Math.Pow(Math.Tan(lat), 2) + e2 * (Math.Pow(Math.Cos(lat), 2)));
            double x = K4 * p + K5 * (Math.Pow(p, 3)) + dx;
            
            return new double[] { x, y };
        }
    }
}
