using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GrafikaZadania.ColorSchemeConverter;

namespace GrafikaZadania
{
    public partial class UserControl3 : UserControl
    {
        RGB rgb;
        CMYK cmyk;

        public UserControl3()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            rTextBox.Text = "0";
            gTextBox.Text = "0";
            bTextBox.Text = "0";
            cTextBox.Text = "0";
            mTextBox.Text = "0";
            yTextBox.Text = "0";
            kTextBox.Text = "0";

            rTrack.Value = 0;
            gTrack.Value = 0;
            bTrack.Value = 0;
            cTrack.Value = 0;
            mTrack.Value = 0;
            yTrack.Value = 0;
            kTrack.Value = 0;

            rgb = new RGB(0,0,0);
            cmyk = new CMYK(0,0,0,0);
        }

        private void rgbTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            MaskedTextBox tb = (MaskedTextBox)sender;
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void rgbTextBox_TextChanged(object sender, EventArgs e)
        {
            MaskedTextBox tb = (MaskedTextBox)sender;

            switch (tb.Name)
            {
                case "rTextBox":SetRGBTrackBar(rTrack, tb.Text);
                    break;
                case "gTextBox":SetRGBTrackBar(gTrack, tb.Text);
                    break;
                case "bTextBox":SetRGBTrackBar(bTrack, tb.Text);
                    break;
                case "cTextBox":SetCMYKTrackBar(cTrack, tb.Text);
                    break;
                case "mTextBox":SetCMYKTrackBar(mTrack, tb.Text);
                    break;
                case "yTextBox":SetCMYKTrackBar(yTrack, tb.Text);
                    break;
                case "kTextBox":SetCMYKTrackBar(kTrack, tb.Text);
                    break;
            }
        }

        private void SetCMYKTrackBar(TrackBar tbar,string value)
        {
            int v = int.Parse(value);
            if (v >= 0 && v <= 100)
                tbar.Value = v;
        }

        private void SetRGBTrackBar(TrackBar tbar,string value)
        {
            int v = int.Parse(value);
            if (v >= 0 && v <= 255)
                tbar.Value = v;
        }

        private void rgbTrackBar_ValueChanged(object sender, EventArgs e)
        {
            TrackBar tb = (TrackBar)sender;
            switch (tb.Name)
            {
                case "rTrack":
                    rTextBox.Text = rTrack.Value.ToString();
                    rgb.R = (byte)rTrack.Value;
                    break;
                case "gTrack":
                    gTextBox.Text = gTrack.Value.ToString();
                    rgb.G = (byte)gTrack.Value;
                    break;
                case "bTrack":
                    bTextBox.Text = bTrack.Value.ToString();
                    rgb.B = (byte)bTrack.Value;
                    break;
                case "cTrack":
                    cTextBox.Text = cTrack.Value.ToString();
                    cmyk.C = cTrack.Value/100d;
                    break;
                case "mTrack":
                    mTextBox.Text = mTrack.Value.ToString();
                    cmyk.M = mTrack.Value/100d;
                    break;
                case "yTrack":
                    yTextBox.Text = yTrack.Value.ToString();
                    cmyk.Y = yTrack.Value/100d;
                    break;
                case "kTrack":
                    kTextBox.Text = kTrack.Value.ToString();
                    cmyk.K = kTrack.Value/100d;
                    break;
                default:break;
            }
        }

        private void UpdateCMYKSide()
        {   
            cTrack.Value = (int)(cmyk.C * 100);
            mTrack.Value = (int)(cmyk.M * 100);
            yTrack.Value = (int)(cmyk.Y * 100);
            kTrack.Value = (int)(cmyk.K * 100);
        }

        private void UpdateRGBSide()
        {
            rTrack.Value = rgb.R;
            gTrack.Value = rgb.G;
            bTrack.Value = rgb.B;
        }

        private void rgbToCmykButton_Click(object sender, EventArgs e)
        {
            cmyk = RGBToCMYK(rgb);
            try
            {
                UpdateCMYKSide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Coś poszło nie tak :|","Wiel-Błąd");
            }
            
        }

        private void cmykToRgbButton_Click(object sender, EventArgs e)
        {
            rgb = CMYKToRGB(cmyk);
            try
            {
                UpdateRGBSide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Coś poszło nie tak :|", "Wiel-Błąd");
            }
        }

        private void showFromRGBButton_Click(object sender, EventArgs e)
        {
            rgb.R = (byte)rTrack.Value;
            rgb.G = (byte)gTrack.Value;
            rgb.B = (byte)bTrack.Value;
            colorPanel.BackColor = Color.FromArgb(rgb.R,rgb.G,rgb.B);
        }

        private void showFromCMYKButton_Click(object sender, EventArgs e)
        {
            rgb = CMYKToRGB(cmyk);
            colorPanel.BackColor = Color.FromArgb(rgb.R, rgb.G, rgb.B);
        }

        private void rgbCubeButton_Click(object sender, EventArgs e)
        {

        }
    }
}
