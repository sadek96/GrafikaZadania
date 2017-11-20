using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

using SysColor = System.Drawing.Color;
using SysRectangle = System.Drawing.Rectangle;

namespace PixelMap
{

    public class PixelMap
    {

        public static readonly int CHUNK_SIZE = 1024;
        private PixelMapHeader header;

        public PixelMapHeader Header
        {
            get { return header; }
            set { header = value; }
        }

        private byte[] imageData;

        public byte[] ImageData
        {
            get { return imageData; }
            set { imageData = value; }
        }

        private PixelFormat pixelFormat;

        public PixelFormat PixelFormat
        {
            get { return pixelFormat; }
        }

        private int bytesPerPixel;

        public int BytesPerPixel
        {
            get { return bytesPerPixel; }
        }

        private int stride;

        public int Stride
        {
            get { return stride; }
            set { stride = value; }
        }

        private Bitmap bitmap;

        public Bitmap BitMap
        {
            get { return bitmap; }
        }

        public PixelMap(string filename)
        {
            if (File.Exists(filename))
            {
                FileStream stream = new FileStream(filename, FileMode.Open);
                this.FromStream(stream);
                stream.Close();
            }
            else
            {
                throw new FileNotFoundException("Plik " + filename + " nie istnieje", filename);
            }
        }

        public PixelMap(Stream stream)
        {
            this.FromStream(stream);
            stream.Close();
        }

        private void FromStream(Stream stream)
        {
            int index;
            this.header = new PixelMapHeader();
            int headerItemCount = 0;

            using (BinaryReader binReader = new BinaryReader(stream, new ASCIIEncoding()))
            {

                try
                {
                    while (headerItemCount < 4)
                    {
                        char nextChar = (char)binReader.PeekChar();
                        if (nextChar == '#')
                        {
                            while (binReader.ReadChar() != '\n') ;
                        }
                        else if (Char.IsWhiteSpace(nextChar))
                        {
                            binReader.ReadChar();
                        }
                        else
                        {
                            switch (headerItemCount)
                            {
                                case 0:
                                    char[] chars = binReader.ReadChars(2);
                                    this.header.MagicNumber = chars[0].ToString() + chars[1].ToString();
                                    headerItemCount++;
                                    break;
                                case 1:
                                    this.header.Width = ReadValue(binReader);
                                    headerItemCount++;
                                    break;
                                case 2:
                                    this.header.Height = ReadValue(binReader);
                                    headerItemCount++;
                                    break;
                                case 3:
                                    this.header.Depth = ReadValue(binReader);
                                    headerItemCount++;
                                    break;
                                default:
                                    throw new Exception("B³¹d parsowania nag³ówka.");
                            }
                        }
                    }

                    switch (this.header.MagicNumber)
                    {

                        case "P3":
                        case "P6":  // 3 bytes per pixel
                            this.pixelFormat = PixelFormat.Format24bppRgb;
                            this.bytesPerPixel = 3;
                            break;
                        default:
                            throw new Exception("Nieznany numer: " + this.header.MagicNumber);
                    }

                    this.imageData = new byte[this.header.Width * this.header.Height * this.bytesPerPixel];
                    this.stride = this.header.Width * this.bytesPerPixel;

                    if (this.header.MagicNumber == "P3")
                    {//tekstowo
                        int charsLeft = (int)(binReader.BaseStream.Length - binReader.BaseStream.Position);
                        char[] charData = binReader.ReadChars(CHUNK_SIZE);
                        string valueString = string.Empty;
                        index = 0;
                        while (charData.Length > 0)
                        {


                            for (int i = 0; i < charData.Length; i++)
                            {
                                if (Char.IsWhiteSpace(charData[i]))
                                {
                                    if (valueString != string.Empty)
                                    {
                                        this.imageData[index] = (byte)((int.Parse(valueString) * 255) / this.header.Depth);
                                        valueString = string.Empty;
                                        index++;
                                    }
                                }
                                else
                                {
                                    valueString += charData[i];
                                }
                            }
                            charData = binReader.ReadChars(CHUNK_SIZE);
                        }

                    }
                    else//binarnie
                    {
                        int bytesLeft = (int)(binReader.BaseStream.Length - binReader.BaseStream.Position);
                        if (this.header.Depth > 256)
                        {
                            byte[] byteData = binReader.ReadBytes(CHUNK_SIZE);
                            int idx = 0;
                            while (byteData.Length > 0)
                            {
                                byte[] parsedData;

                                parsedData = new byte[byteData.Length / 2];
                                
                                for (int i = 0; i < byteData.Length; i += 2)
                                {
                                    int value = (byteData[i] << 8) | byteData[i + 1];
                                    this.imageData[idx] = (byte)((value * 255) / this.header.Depth);
                                    idx++;
                                }

                                byteData = binReader.ReadBytes(CHUNK_SIZE);
                            }
                        }
                        else
                        {
                            //byte[] byteData = binReader.ReadBytes(CHUNK_SIZE);
                            //int idx = 0;
                            //while (byteData.Length > 0)
                            //{
                            //    for (int i = 0; i < byteData.Length; i++)
                            //    {
                            //        this.imageData[idx] = (byte)((byteData[i] * 255) / this.header.Depth);
                            //        idx++;
                            //    }

                            //    byteData = binReader.ReadBytes(CHUNK_SIZE);
                            //}
                            this.imageData = binReader.ReadBytes(bytesLeft);
                        }
                    }
                    ReorderBGRtoRGB();

                    if (stride % 4 == 0)
                    {
                        this.bitmap = CreateBitMap();
                    }
                    else
                        this.bitmap = CreateBitmapOffSize();

                    this.bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                }

                // If the end of the stream is reached before reading all of the expected values raise an exception.
                catch (EndOfStreamException e)
                {
                    Console.WriteLine(e.Message);
                    throw new Exception("B³¹d czytania strumienia! Koniec strumienia! SprawdŸ czy dane obrazu s¹ w odpowiednim formacie!", e);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw new Exception("B³¹d czytania strumienia! SprawdŸ czy dane obrazu s¹ w odpowiednim formacie!", ex);
                }
            }
        }

        private void ReorderBGRtoRGB()
        {
            byte[] tempData = new byte[this.imageData.Length];
            for (int i = 0; i < this.imageData.Length; i++)
            {
                tempData[i] = this.imageData[this.imageData.Length - 1 - i];
            }
            this.imageData = tempData;
        }

        private int ReadValue(BinaryReader binReader)
        {
            string value = string.Empty;
            while (!Char.IsWhiteSpace((char)binReader.PeekChar()))
            {
                value += binReader.ReadChar().ToString();
            }
            binReader.ReadByte();
            return int.Parse(value);
        }

        private Bitmap CreateBitMap()
        {
            IntPtr pImageData = Marshal.AllocHGlobal(this.imageData.Length);
            Marshal.Copy(this.imageData, 0, pImageData, this.imageData.Length);
            Bitmap bitmap = new Bitmap(this.header.Width, this.header.Height, this.stride, this.pixelFormat, pImageData);
            return bitmap;
        }

        private Bitmap CreateBitmapOffSize()
        {
            Bitmap bitmap = new Bitmap(this.header.Width, this.header.Height, PixelFormat.Format24bppRgb);
            SysColor sysColor = new SysColor();
            int red, green, blue;
            int index;

            for (int x = 0; x < this.header.Width; x++)
            {
                for (int y = 0; y < this.header.Height; y++)
                {
                    index = x + y * this.header.Width;

                    switch (this.header.MagicNumber)
                    {

                        case "P3":
                            index = 3 * index;
                            blue = (int)this.imageData[index];
                            green = (int)this.imageData[index + 1];
                            red = (int)this.imageData[index + 2];
                            sysColor = SysColor.FromArgb(red, green, blue);
                            break;
                        case "P6":
                            index = 3 * index;
                            blue = (int)this.imageData[index];
                            green = (int)this.imageData[index + 1];
                            red = (int)this.imageData[index + 2];
                            sysColor = SysColor.FromArgb(red, green, blue);
                            break;
                        default:
                            break;
                    }
                    bitmap.SetPixel(x, y, sysColor);
                }
            }
            return bitmap;
        }

        [Serializable]
        public struct PixelMapHeader
        {
            private string magicNumber;

            public string MagicNumber
            {
                get { return magicNumber; }
                set { magicNumber = value; }
            }

            private int width;

            public int Width
            {
                get { return width; }
                set { width = value; }
            }

            private int height;

            public int Height
            {
                get { return height; }
                set { height = value; }
            }

            private int depth;

            public int Depth
            {
                get { return depth; }
                set { depth = value; }
            }
        }
    }
}
