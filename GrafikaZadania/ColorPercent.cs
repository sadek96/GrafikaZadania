using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GrafikaZadania
{
    class ColorPercent
    {
        public static double FilterColor(Bitmap image, byte R, byte G, byte B, byte threshold)
        {

            Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);
            BitmapData imageData = image.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            IntPtr ptr = imageData.Scan0;
            int bytes = Math.Abs(imageData.Stride) * image.Height;
            byte[] rgb = new byte[bytes];

            var count = 0;

            Marshal.Copy(ptr, rgb, 0, bytes);

            for (var i = 0; i < rgb.Length; i += 3)
            {



                var b = Math.Abs(rgb[i] - B);
                var g = Math.Abs(rgb[i + 1] - G);
                var r = Math.Abs(rgb[i + 2] - R);

                if (r + g + b > threshold)
                { rgb[i] = rgb[i + 1] = rgb[i + 2] = 0; }
                else
                    count++;

            }

            Marshal.Copy(rgb, 0, ptr, bytes);

            image.UnlockBits(imageData);

            return (double)((double)count / (double)rgb.Length / 3.0) * 1000.0;

        }
    }
}
