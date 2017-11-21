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
    public partial class UserControl5 : UserControl
    {
        private PixelMap.PixelMap pixelMap;
        private FileStream fileStream;
        private Bitmap displayedBitmap = null;
        private Bitmap processedBitmap = null;

        public UserControl5()
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

                displayedBitmap = null;
                fileStream = new FileStream(openFileDialog1.FileName, FileMode.Open);

                try
                {
                    switch (ext)
                    {
                        case ".ppm":
                            pixelMap = new PixelMap.PixelMap(fileStream);
                            displayedBitmap = pixelMap.BitMap;
                            break;
                        case ".jpeg":
                        case ".jpg":
                            displayedBitmap = new Bitmap(fileStream);
                            break;
                        default: MessageBox.Show("Błąd", " Nie wspierane rozszerzenie pliku! " + ext); break;
                    }
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                    MessageBox.Show(msg, "Błąd wczytywania pliku");
                }

                picBox.Image = displayedBitmap;
            }
        }

        private void operationButton_Click(object sender, EventArgs e)
        {
            if (displayedBitmap != null)
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        processedBitmap = HistogramOperation.Stretch2(displayedBitmap);
                        picBox.Image = processedBitmap;
                        break;
                    case 1:
                        processedBitmap = HistogramOperation.histogramEqualization(displayedBitmap);
                        picBox.Image = processedBitmap;
                        break;
                    case 2:

                        processedBitmap = BinarizationOperation.PBinary(displayedBitmap,trackBar1.Value);
                        picBox.Image = processedBitmap;
                        break;
                    default: break;
                }
        }

        private void histogramButton_Click(object sender, EventArgs e)
        {
            if (displayedBitmap != null)
            {
                new HistogramForm(displayedBitmap).Show();
            }
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Text = trackBar1.Value.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 2)
            {
                textBox1.Visible = true;
                trackBar1.Visible = true;
            }
            else
            {
                textBox1.Visible = false;
                trackBar1.Visible = false;
            }
        }
    }
}
