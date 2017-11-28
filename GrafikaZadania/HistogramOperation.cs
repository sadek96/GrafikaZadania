using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafikaZadania
{
    class HistogramOperation
    {

        public static Bitmap histogramEqualization(Bitmap sourceImage)
        {
            Bitmap renderedImage = sourceImage;

            uint pixels = (uint)renderedImage.Height * (uint)renderedImage.Width;
            decimal Const = 255 / (decimal)pixels;

            int x, y, R, G, B;

            int[][] bmpHist = GetHistogram(renderedImage);

            int[] cdfR = bmpHist[1];
            int[] cdfG = bmpHist[2];
            int[] cdfB = bmpHist[3];


            //Convert arrays to cumulative distribution frequency data
            for (int r = 1; r <= 255; r++)
            {
                cdfR[r] = cdfR[r] + cdfR[r - 1];
                cdfG[r] = cdfG[r] + cdfG[r - 1];
                cdfB[r] = cdfB[r] + cdfB[r - 1];
            }
            Console.WriteLine((decimal)pixels);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    Console.Write(" " + bmpHist[i][j] + " ");
                }
                Console.Write("\r\n");
            }
            for (y = 0; y < renderedImage.Height; y++)
            {
                for (x = 0; x < renderedImage.Width; x++)
                {
                    Color pixelColor = renderedImage.GetPixel(x, y);

                    R = (int)((decimal)cdfR[pixelColor.R] * Const);
                    G = (int)((decimal)cdfG[pixelColor.G] * Const);
                    B = (int)((decimal)cdfB[pixelColor.B] * Const);

                    Color newColor = Color.FromArgb(R, G, B);
                    renderedImage.SetPixel(x, y, newColor);
                }
            }
            return renderedImage;
        }


        public static Bitmap MakeGrayscale3(Bitmap original)
        {
            //create a blank bitmap the same size as original
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            //get a graphics object from the new image
            Graphics g = Graphics.FromImage(newBitmap);

            //create the grayscale ColorMatrix
            ColorMatrix colorMatrix = new ColorMatrix(
               new float[][]
               {
         new float[] {.3f, .3f, .3f, 0, 0},
         new float[] {.59f, .59f, .59f, 0, 0},
         new float[] {.11f, .11f, .11f, 0, 0},
         new float[] {0, 0, 0, 1, 0},
         new float[] {0, 0, 0, 0, 1}
               });

            //create some image attributes
            ImageAttributes attributes = new ImageAttributes();

            //set the color matrix attribute
            attributes.SetColorMatrix(colorMatrix);

            //draw the original image on the new image
            //using the grayscale color matrix
            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
               0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);

            //dispose the Graphics object
            g.Dispose();
            return newBitmap;
        }


        public static Bitmap Stretch2(Bitmap src)
        {

            int min = 255;
            int max = 0;
            Bitmap bmp = new Bitmap(src.Width,src.Height);
            Bitmap gray = MakeGrayscale3(src);
            for (int y = 0; y < src.Height; y++)
            {
                for (int x = 0; x < src.Width; x++)
                {
                    Color rgb = gray.GetPixel(x, y);
                    byte r = rgb.R;
                    byte g = rgb.G;
                    byte b = rgb.B;
                    if (min > r) min = r;
                    if (min > g) min = g;
                    if (min > b) min = b;
                    if (max < r) max = r;
                    if (max < g) max = g;
                    if (max < b) max = b;
                }
            }
            Console.WriteLine("min ="+min+" max="+max);

            for (int y = 0; y < src.Height; y++)
            {
                for (int x = 0; x < src.Width; x++)
                {
                    Color rgb = src.GetPixel(x, y);
                    byte r = (byte)((rgb.R - min) * 255 / (max - min));
                    byte g = (byte)((rgb.G - min) * 255 / (max - min));
                    byte b = (byte)((rgb.B - min) * 255 / (max - min));
                    bmp.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }

            return bmp;
        }

        public static int[][] GetHistogram(Bitmap SourceImage)
        {
            int[][] RGBColor = { new int[256], new int[256], new int[256], new int[256] };
            // [Luminosity, Red, Green, Blue]
            int width = SourceImage.Width, height = SourceImage.Height;
            bool imagGrayscale = (SourceImage.PixelFormat == PixelFormat.Format8bppIndexed);
            BitmapData srcData = SourceImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly,
                (imagGrayscale ? PixelFormat.Format8bppIndexed : PixelFormat.Format24bppRgb));    // lock bitmap data


            unsafe
            {
                byte* ptr = (byte*)srcData.Scan0.ToPointer();
                int pointrInc = imagGrayscale ? 1 : 3;
                int remain = srcData.Stride - width * pointrInc;


                for (int i = 0, j; i < height; ++i, ptr += remain)
                    for (j = 0; j < width; j++, ptr += pointrInc)
                    {
                        if (imagGrayscale == false)
                        {
                            ++RGBColor[0][(int)(0.114 * ptr[0] + 0.587 * ptr[1] + 0.299 * ptr[2])];
                            ++RGBColor[1][ptr[2]];                        // R
                            ++RGBColor[2][ptr[1]];                       // G
                            ++RGBColor[3][ptr[0]];                       // B
                        }
                        else ++RGBColor[0][ptr[0]];                   // L
                    }
            }
            SourceImage.UnlockBits(srcData);
            return RGBColor;
        }
    }
}
