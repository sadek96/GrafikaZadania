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
    class MorphologicOperation
    {
        private static byte[,] kernel
        {
            get
            {
                return new byte[,]
                {
                    { 0, 1, 0 },
                    { 1, 1, 1 },
                    { 0, 1, 0 }
                };
            }
        }

        private static List<int[,]> thickeningList = new List<int[,]>()
        {
            new int[,]{{1, 1, -1}, {1, 0, -1}, {1, -1, 0}},
            new int[,]{{-1, 1, 1}, {-1, 0, 1}, {0, -1, 1}},
            new int[,]{{1, 1, 1}, {1, 0, -1}, {-1, -1, 0}},
            new int[,]{{-1, -1, 0}, {1, 0, -1}, {1, 1, 1}},
            new int[,]{{1, -1, 0}, {1, 0, -1}, {1, 1, -1}},
            new int[,]{{0, -1, 1}, {-1, 0, 1}, {-1, 1, 1}},
            new int[,]{{1, 1, 1}, {-1, 0, 1}, {0, -1, -1}},
            new int[,]{{0, -1, -1}, {-1, 0, 1}, {1, 1, 1}}
        };

        private static List<int[,]> thinningList = new List<int[,]>()
        {
            new int[,]{{0, 0, 0}, {-1, 1, -1}, {1, 1, 1}},
            new int[,]{{1, 1, 1}, {-1, 1, -1}, {0, 0, 0}},
            new int[,]{{1, -1, 0}, {1, 1, 0}, {1, -1, 0}},
            new int[,]{{0, -1, 1}, {0, 1, 1}, {0, -1, 1}}
        };

        public static Bitmap Dilate(Bitmap srcImg)
        {
            //Create image dimension variables for convenience
            int width = srcImg.Width;
            int height = srcImg.Height;

            //Lock bits to system memory for fast processing
            Rectangle canvas = new Rectangle(0, 0, width, height);
            BitmapData srcData = srcImg.LockBits(canvas, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            int stride = srcData.Stride;
            int bytes = stride * srcData.Height;

            //Create byte arrays that will hold all pixel data, one for processing, one for output
            byte[] pixelBuffer = new byte[bytes];
            byte[] resultBuffer = new byte[bytes];

            //Write pixel data to array meant for processing
            Marshal.Copy(srcData.Scan0, pixelBuffer, 0, bytes);
            srcImg.UnlockBits(srcData);

            //Convert to grayscale
            float rgb = 0;
            for (int i = 0; i < bytes; i += 4)
            {
                rgb = pixelBuffer[i] * .071f;
                rgb += pixelBuffer[i + 1] * .71f;
                rgb += pixelBuffer[i + 2] * .21f;
                pixelBuffer[i] = (byte)rgb;
                pixelBuffer[i + 1] = pixelBuffer[i];
                pixelBuffer[i + 2] = pixelBuffer[i];
                pixelBuffer[i + 3] = 255;
            }

            int kernelDim = 3;

            //This is the offset of center pixel from border of the kernel
            int kernelOffset = (kernelDim - 1) / 2;
            int calcOffset = 0;
            int byteOffset = 0;
            for (int y = kernelOffset; y < height - kernelOffset; y++)
            {
                for (int x = kernelOffset; x < width - kernelOffset; x++)
                {
                    byte value = 0;
                    byteOffset = y * stride + x * 4;

                    //Apply dilation
                    for (int ykernel = -kernelOffset; ykernel <= kernelOffset; ykernel++)
                    {
                        for (int xkernel = -kernelOffset; xkernel <= kernelOffset; xkernel++)
                        {
                            if (kernel[ykernel + kernelOffset, xkernel + kernelOffset] == 1)
                            {
                                calcOffset = byteOffset + ykernel * stride + xkernel * 4;
                                value = Math.Max(value, pixelBuffer[calcOffset]);
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                    //Write processed data into the second array
                    resultBuffer[byteOffset] = value;
                    resultBuffer[byteOffset + 1] = value;
                    resultBuffer[byteOffset + 2] = value;
                    resultBuffer[byteOffset + 3] = 255;
                }
            }

            //Create output bitmap of this function
            Bitmap rsltImg = new Bitmap(width, height);
            BitmapData rsltData = rsltImg.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            //Write processed data into bitmap form
            Marshal.Copy(resultBuffer, 0, rsltData.Scan0, bytes);
            rsltImg.UnlockBits(rsltData);
            return rsltImg;
        }


        public static Bitmap Erode(Bitmap srcImage)
        {
            int width = srcImage.Width;
            int height = srcImage.Height;

            Rectangle canvas = new Rectangle(0, 0, width, height);
            BitmapData srcData = srcImage.LockBits(canvas, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            int bytes = srcData.Stride * srcData.Height;
            byte[] pixelBuffer = new byte[bytes];
            byte[] resultBuffer = new byte[bytes];

            Marshal.Copy(srcData.Scan0, pixelBuffer, 0, bytes);
            srcImage.UnlockBits(srcData);

            float rgb;
            for (int i = 0; i < bytes; i += 4)
            {
                rgb = pixelBuffer[i] * .071f;
                rgb += pixelBuffer[i + 1] * .71f;
                rgb += pixelBuffer[i + 2] * .21f;
                pixelBuffer[i] = (byte)rgb;
                pixelBuffer[i + 1] = pixelBuffer[i];
                pixelBuffer[i + 2] = pixelBuffer[i];
                pixelBuffer[i + 3] = 255;
            }

            int kernelSize = 3;
            int kernelOffset = (kernelSize - 1) / 2;
            int calcOffset = 0;
            int byteOffset = 0;

            for (int y = kernelOffset; y < height - kernelOffset; y++)
            {
                for (int x = kernelOffset; x < width - kernelOffset; x++)
                {
                    byte value = 255;
                    byteOffset = y * srcData.Stride + x * 4;
                    for (int ykernel = -kernelOffset; ykernel <= kernelOffset; ykernel++)
                    {
                        for (int xkernel = -kernelOffset; xkernel <= kernelOffset; xkernel++)
                        {
                            if (kernel[ykernel + kernelOffset, xkernel + kernelOffset] == 1)
                            {
                                calcOffset = byteOffset + ykernel * srcData.Stride + xkernel * 4;
                                value = Math.Min(value, pixelBuffer[calcOffset]);
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                    resultBuffer[byteOffset] = value;
                    resultBuffer[byteOffset + 1] = value;
                    resultBuffer[byteOffset + 2] = value;
                    resultBuffer[byteOffset + 3] = 255;
                }
            }

            Bitmap result = new Bitmap(width, height);
            BitmapData resultData = result.LockBits(canvas, ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            Marshal.Copy(resultBuffer, 0, resultData.Scan0, bytes);
            result.UnlockBits(resultData);
            return result;
        }

        public static Bitmap Thickening(Bitmap srcImage)
        {
            int width = srcImage.Width;
            int height = srcImage.Height;

            Rectangle canvas = new Rectangle(0, 0, width, height);
            BitmapData srcData = srcImage.LockBits(canvas, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            int bytes = srcData.Stride * srcData.Height;
            byte[] pixelBuffer = new byte[bytes];
            byte[] resultBuffer = new byte[bytes];

            Marshal.Copy(srcData.Scan0, pixelBuffer, 0, bytes);
            srcImage.UnlockBits(srcData);

            int kernelSize = 3;
            int kernelOffset = (kernelSize - 1) / 2;
            int byteOffset = 0;


            for (int y = kernelOffset; y < height - kernelOffset; y++)
            {
                for (int x = kernelOffset; x < width - kernelOffset; x++)
                {

                    byteOffset = y * srcData.Stride + x * 4;
                    byte value = pixelBuffer[byteOffset];
                    if (pixelBuffer[byteOffset] == 0)
                    {
                        value = (checkIfSame(kernelOffset, byteOffset, srcData.Stride, pixelBuffer)) ? Color.Black.R : Color.White.R;
                    }
                    resultBuffer[byteOffset] = resultBuffer[byteOffset + 1] = resultBuffer[byteOffset + 2] = value;
                    resultBuffer[byteOffset + 3] = 255;
                }
            }

            Bitmap result = new Bitmap(width, height);
            BitmapData resultData = result.LockBits(canvas, ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            Marshal.Copy(resultBuffer, 0, resultData.Scan0, bytes);
            result.UnlockBits(resultData);
            return result;
        }

        public static Bitmap Thinning(Bitmap srcImage)
        {
            int width = srcImage.Width;
            int height = srcImage.Height;

            Rectangle canvas = new Rectangle(0, 0, width, height);
            BitmapData srcData = srcImage.LockBits(canvas, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            int bytes = srcData.Stride * srcData.Height;
            byte[] pixelBuffer = new byte[bytes];
            byte[] resultBuffer = new byte[bytes];
            byte[] finalBuffer = new byte[bytes];

            Marshal.Copy(srcData.Scan0, pixelBuffer, 0, bytes);
            srcImage.UnlockBits(srcData);

            int kernelSize = 3;
            int kernelOffset = (kernelSize - 1) / 2;
            int byteOffset = 0;


            for (int y = kernelOffset; y < height - kernelOffset; y++)
            {
                for (int x = kernelOffset; x < width - kernelOffset; x++)
                {

                    byteOffset = y * srcData.Stride + x * 4;
                    byte value = pixelBuffer[byteOffset];
                    if (pixelBuffer[byteOffset] == 0)
                    {
                        value = checkIfSame(kernelOffset, byteOffset, srcData.Stride, pixelBuffer) ? Color.White.R : Color.Black.R;
                    }
                    resultBuffer[byteOffset] = resultBuffer[byteOffset + 1] = resultBuffer[byteOffset + 2] = value;
                    resultBuffer[byteOffset + 3] = 255;
                }
            }

            for (int y = kernelOffset; y < height - kernelOffset; y++)
            {
                for (int x = kernelOffset; x < width - kernelOffset; x++)
                {

                    byteOffset = y * srcData.Stride + x * 4;
                    byte value = resultBuffer[byteOffset];
                    if (resultBuffer[byteOffset] == 0)
                    {
                        value = checkIfSame2(kernelOffset, byteOffset, srcData.Stride, resultBuffer) ? Color.White.R : Color.Black.R;
                    }
                    finalBuffer[byteOffset] = finalBuffer[byteOffset + 1] = finalBuffer[byteOffset + 2] = value;
                    finalBuffer[byteOffset + 3] = 255;
                }
            }

            Bitmap result = new Bitmap(width, height);
            BitmapData resultData = result.LockBits(canvas, ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            Marshal.Copy(finalBuffer, 0, resultData.Scan0, bytes);
            result.UnlockBits(resultData);
            return result;
        }


        private static bool checkIfSame(int kernelOffset, int byteOffset, int stride, byte[] pixelBuffer)
        {
            foreach (int[,] table in thickeningList)
            {
                if (checkIfSameTable(table, kernelOffset, byteOffset, stride, pixelBuffer))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool checkIfSame2(int kernelOffset, int byteOffset, int stride, byte[] pixelBuffer)
        {
            foreach (int[,] table in thinningList)
            {
                if (checkIfSameTable(table, kernelOffset, byteOffset, stride, pixelBuffer))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool checkIfSameTable(int[,] table, int kernelOffset, int byteOffset, int stride, byte[] pixelBuffer)
        {
            int calcOffset = 0;

            for (int ykernel = -kernelOffset; ykernel <= kernelOffset; ykernel++)
            {
                for (int xkernel = -kernelOffset; xkernel <= kernelOffset; xkernel++)
                {
                    calcOffset = byteOffset + ykernel * stride + xkernel * 4;
                    if (table[ykernel + kernelOffset, xkernel + kernelOffset] != -1)
                    {
                        if (!checkIfSamePixel(table[ykernel + kernelOffset, xkernel + kernelOffset], pixelBuffer[calcOffset]))
                        {
                            return false;
                        }
                    }

                }

            }
            return true;
        }

        private static bool checkIfSamePixel(int tableValue, byte pixel)
        {
            if (tableValue == 0)
            {
                return pixel == Color.White.R;
            }
            else if (tableValue == 1)
            {
                return pixel == Color.Black.R;
            }
            return false;
        }



    }
}
