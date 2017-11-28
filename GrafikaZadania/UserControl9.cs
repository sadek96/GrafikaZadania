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

namespace GrafikaZadania
{
    public partial class UserControl9 : UserControl
    {
        private PixelMap.PixelMap pixelMap;
        private FileStream fileStream;
        private Bitmap loadedBitmap = null;
        private Bitmap processedBitmap = null;

        public UserControl9()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Filter = "Obrazy (*.ppm,*.jpg,*.jpeg)|*.ppm;*.jpg;*.jpeg";
            openFileDialog1.Title = "Wybierz plik obrazu";
        }

        private void loadImageButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string ext = Path.GetExtension(openFileDialog1.FileName);

                loadedBitmap = null;
                fileStream = new FileStream(openFileDialog1.FileName, FileMode.Open);

                try
                {
                    switch (ext)
                    {
                        case ".ppm":
                            pixelMap = new PixelMap.PixelMap(fileStream);
                            loadedBitmap = pixelMap.BitMap;
                            break;
                        case ".jpeg":
                        case ".jpg":
                            loadedBitmap = new Bitmap(fileStream);
                            break;
                        default: MessageBox.Show("Błąd", " Nie wspierane rozszerzenie pliku! " + ext); break;
                    }
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                    MessageBox.Show(msg, "Błąd wczytywania pliku");
                }

                picBox.Image = loadedBitmap;
                fileStream.Close();
            }
        }

        private void operationButton_Click(object sender, EventArgs e)
        {
            int r = int.Parse(rTBox.Text);
            int g = int.Parse(gTBox.Text);
            int b = int.Parse(bTBox.Text);
            int threshold = int.Parse(thresholdTBox.Text);
            if (r < 0 || r > 255)
            {
                MessageBox.Show("Wartość R nieprawidłowa");
                return;
            }
            if (g < 0 || g > 255)
            {
                MessageBox.Show("Wartość G nieprawidłowa");
                return;
            }
            if (b < 0 || b > 255)
            {
                MessageBox.Show("Wartość B nieprawidłowa");
                return;
            }
            if(threshold < 0 || threshold > 255)
            {
                MessageBox.Show("Wartość B nieprawidłowa");
                return;
            }
            if (loadedBitmap != null)
            {
                processedBitmap = new Bitmap(loadedBitmap);
                ColorPercent.FilterColor(processedBitmap,(byte)r, (byte)g, (byte)b, (byte)threshold);
                picBox.Image = processedBitmap;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (loadedBitmap != null)
            {
                picBox.Image = loadedBitmap;
            }
        }
    }
}
