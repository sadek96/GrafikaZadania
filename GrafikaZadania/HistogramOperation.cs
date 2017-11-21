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

        public static Bitmap Stretch(Bitmap srcImage,
             double blackPointPercent = 0.1, double whitePointPercent = 0.1)
        {
            //Lock bits for your source image into system memory
            Rectangle rect = new Rectangle(0, 0, srcImage.Width, srcImage.Height);
            BitmapData srcData = srcImage.LockBits(rect, ImageLockMode.ReadOnly,
                PixelFormat.Format32bppArgb);

            //Create a bitmap to which you will write new pixel data
            Bitmap destImage = new Bitmap(srcImage.Width, srcImage.Height);

            //Lock bits for your writable bitmap into system memory
            Rectangle rect2 = new Rectangle(0, 0, destImage.Width, destImage.Height);
            BitmapData destData = destImage.LockBits(rect2, ImageLockMode.WriteOnly,
                PixelFormat.Format32bppArgb);

            //Get the width of a single row of pixels in the bitmap
            int stride = srcData.Stride;

            //Scan for the first pixel data in bitmaps
            IntPtr srcScan0 = srcData.Scan0;
            IntPtr destScan0 = destData.Scan0;

            var freq = new int[256];

            unsafe
            {
                //Create an array of pixel data from source image
                byte* src = (byte*)srcScan0;

                //Get the number of pixels for each intensity value
                for (int y = 0; y < srcImage.Height; ++y)
                {
                    for (int x = 0; x < srcImage.Width; ++x)
                    {
                        freq[src[y * stride + x * 4]]++;
                    }
                }

                //Get the total number of pixels in the image
                int numPixels = srcImage.Width * srcImage.Height;

                //Set the minimum intensity value of an image (0 = black)
                int minI = 0;

                //Get the total number of black pixels
                var blackPixels = numPixels * blackPointPercent;

                //Set a variable for summing up the pixels that will turn black
                int accum = 0;

                //Sum up the darkest shades until you reach the total of black pixels
                while (minI < 255)
                {
                    accum += freq[minI];
                    if (accum > blackPixels) break;
                    minI++;
                }

                //Set the maximum intensity of an image (255 = white)
                int maxI = 255;

                //Set the total number of white pixels
                var whitePixels = numPixels * whitePointPercent;

                //Reset the summing variable back to 0
                accum = 0;

                //Sum up the pixels that are the lightest which will turn white
                while (maxI > 0)
                {
                    accum += freq[maxI];
                    if (accum > whitePixels) break;
                    maxI--;
                }

                //Part of a normalization equation that doesn't vary with each pixel
                double spread = 255d / (maxI - minI);

                //Create an array of pixel data from created image
                byte* dst = (byte*)destScan0;

                //Write new pixel data to the image
                for (int y = 0; y < srcImage.Height; ++y)
                {
                    for (int x = 0; x < srcImage.Width; ++x)
                    {
                        int i = y * stride + x * 4;

                        //Part of equation that varies with each pixel
                        double value = Math.Round((src[i] - minI) * spread);
                        byte val = (byte)(Math.Min(Math.Max(value, 0), 255));
                        dst[i] = val;

                        value = Math.Round((src[i+1] - minI) * spread);
                         val = (byte)(Math.Min(Math.Max(value, 0), 255));
                        dst[i + 1] = val;

                        value = Math.Round((src[i+2] - minI) * spread);
                        val = (byte)(Math.Min(Math.Max(value, 0), 255));
                        dst[i + 2] = val;
                        dst[i + 3] = 255;
                    }
                }
            }

            //Unlock bits from system memory
            srcImage.UnlockBits(srcData);
            destImage.UnlockBits(destData);

            return destImage;
        }

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
            //Bitmap gray = MakeGrayscale3(src);

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
