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
    public partial class UserControl8 : UserControl
    {
        private PixelMap.PixelMap pixelMap;
        private FileStream fileStream;
        private Bitmap loadedBitmap = null;
        private Bitmap processedBitmap = null;

        public UserControl8()
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
                loadedBitmap = BinarizationOperation.MeanThreshold(loadedBitmap);

                picBox.Image = loadedBitmap;
                fileStream.Close();
            }
        }

        private void operationButton_Click(object sender, EventArgs e)
        {
            if (loadedBitmap != null)
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        processedBitmap = MorphologicOperation.Erode(loadedBitmap);
                        picBox.Image = processedBitmap;
                        break;
                    case 1:
                        processedBitmap = MorphologicOperation.Dilate(loadedBitmap);
                        picBox.Image = processedBitmap;
                        break;
                    case 2:
                        processedBitmap = MorphologicOperation.Erode(loadedBitmap);
                        picBox.Image = MorphologicOperation.Dilate(processedBitmap);
                        break;
                    case 3:
                        processedBitmap = MorphologicOperation.Dilate(loadedBitmap);
                        picBox.Image = MorphologicOperation.Erode(processedBitmap);
                        break;
                    case 4:
                        processedBitmap = MorphologicOperation.Thickening(loadedBitmap);
                        picBox.Image = processedBitmap;
                        break;
                    case 5:
                        processedBitmap = MorphologicOperation.Thinning(loadedBitmap);
                        picBox.Image = processedBitmap;
                        break;
                    default: break;
                }
        }
    }
}
