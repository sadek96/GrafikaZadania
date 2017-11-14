using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafikaZadania
{
    class ColorSchemeConverter
    {
        public struct CMYK
        {
            private double _c;
            private double _m;
            private double _y;
            private double _k;

            public CMYK(double c, double m, double y, double k)
            {
                this._c = c;
                this._m = m;
                this._y = y;
                this._k = k;
            }

            public double C
            {
                get { return this._c; }
                set { this._c = value; }
            }

            public double M
            {
                get { return this._m; }
                set { this._m = value; }
            }

            public double Y
            {
                get { return this._y; }
                set { this._y = value; }
            }

            public double K
            {
                get { return this._k; }
                set { this._k = value; }
            }

            public bool Equals(CMYK cmyk)
            {
                return (this.C == cmyk.C) && (this.M == cmyk.M) && (this.Y == cmyk.Y) && (this.K == cmyk.K);
            }
        }

        public struct RGB
        {
            private byte _r;
            private byte _g;
            private byte _b;

            public RGB(byte r, byte g, byte b)
            {
                this._r = r;
                this._g = g;
                this._b = b;
            }

            public byte R
            {
                get { return this._r; }
                set { this._r = value; }
            }

            public byte G
            {
                get { return this._g; }
                set { this._g = value; }
            }

            public byte B
            {
                get { return this._b; }
                set { this._b = value; }
            }

            public bool Equals(RGB rgb)
            {
                return (this.R == rgb.R) && (this.G == rgb.G) && (this.B == rgb.B);
            }
        }

        public static CMYK RGBToCMYK(RGB rgb)
        {
            double dr = (double)rgb.R / 255;
            double dg = (double)rgb.G / 255;
            double db = (double)rgb.B / 255;
            double k = Math.Min(Math.Min(1 - dr, 1 - dg), 1 - db);
            double c = 0;
            double m = 0;
            double y = 0;
            if (k != 1)
            {
                c = (1 - dr - k) / (1 - k);
                m = (1 - dg - k) / (1 - k);
                y = (1 - db - k) / (1 - k);
            }

            return new CMYK(c, m, y, k);
        }

        public static RGB CMYKToRGB(CMYK cmyk)
        {
            double dr = 1 - Math.Min(1, cmyk.C * (1 - cmyk.K) + cmyk.K);
            double dg = 1 - Math.Min(1, cmyk.M * (1 - cmyk.K) + cmyk.K);
            double db = 1 - Math.Min(1, cmyk.Y * (1 - cmyk.K) + cmyk.K);

            Console.WriteLine("Konwersja C:" + cmyk.C + " M:" + cmyk.M + " Y:" + cmyk.Y + " K:" + cmyk.K);
            Console.WriteLine("Do R:" + Math.Round(dr * 255) + " G:" + Math.Round(dg * 255) + " B:" + Math.Round(db * 255));

            byte r = (byte)(Math.Round(dr * 255));
            byte g = (byte)(Math.Round(dg * 255));
            byte b = (byte)(Math.Round(db * 255));

            return new RGB(r, g, b);
        }
    }
}
