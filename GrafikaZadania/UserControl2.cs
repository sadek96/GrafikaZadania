using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace GrafikaZadania
{
    public partial class UserControl2 : UserControl
    {
        private PixelMap.PixelMap pixelMap;
        private FileStream fileStream;
        private Bitmap displayedBitmap = null;
        private long compression = 0;

        public UserControl2()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Filter = "Obrazy (*.ppm,*.jpg)|*.ppm;*.jpg";
            openFileDialog1.Title = "Wybierz plik obrazu";
            openFileDialog1.RestoreDirectory = true;
            maskedTextBox1.Mask = "000";
            maskedTextBox1.Text = "0";
            trackBar1.Value = 0;
        }

        private void UserControl2_Load(object sender, EventArgs e)
        {

        }

        private void loadImageButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string ext = Path.GetExtension(openFileDialog1.FileName);
                
                displayedBitmap = null;
                fileStream = new FileStream(openFileDialog1.FileName, FileMode.Open);
                
                //try
               // {
                    switch (ext)
                    {
                        case ".ppm":
                            pixelMap = new PixelMap.PixelMap(fileStream);
                            displayedBitmap = pixelMap.BitMap;
                            break;
                        case ".jpeg":
                        displayedBitmap = new Bitmap(fileStream);
                            break;
                        default: MessageBox.Show("Błąd", " Nie wspierane rozszerzenie pliku! " + ext); break;
                    }
                //}
                //catch(Exception ex)
                //{
                    //string msg = ex.Message;
                    //MessageBox.Show(msg,"Błąd wczytywania pliku");
                //}

                picBox.Image = displayedBitmap;
            }
        }

        private void SaveBitmapToJpegWithCompression(Bitmap bmp,string path,long compression)
        {
            var encoder = ImageCodecInfo.GetImageEncoders().First(c => c.FormatID == ImageFormat.Jpeg.Guid);
            var encParams = new EncoderParameters() { Param = new[] { new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, compression) } };
            bmp.Save(path, encoder, encParams);
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            maskedTextBox1.Text = trackBar1.Value.ToString();
            compression = 100L - (long)trackBar1.Value;
        }

        private void saveImageButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Obraz .jpeg|*.jpeg";
            dialog.DefaultExt = ".jpeg";
            
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SaveBitmapToJpegWithCompression(displayedBitmap, dialog.FileName, compression);
            }
        }
    }
}
