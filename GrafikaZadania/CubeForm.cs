using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace GrafikaZadania
{
    public partial class CubeForm : Form
    {
        [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
        private static extern bool BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, System.Int32 dwRop);

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern IntPtr ReleaseDC(IntPtr hwnd, IntPtr hdc);

        public CubeForm()
        {
            InitializeComponent();
        }

        Math3D.Cube mainCube;
        Point drawOrigin;

        private void FrmRender_Load(object sender, EventArgs e)
        {
            mainCube = new Math3D.Cube(100, 100, 100);
            drawOrigin = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);
        }

        private void Render()
        {
            mainCube.RotateX = (float)tX.Value;
            mainCube.RotateY = (float)tY.Value;
            mainCube.RotateZ = (float)tZ.Value;

            pictureBox1.Image = mainCube.DrawCube(drawOrigin);
        }

        private void tX_Scroll(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void tY_Scroll(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void tZ_Scroll(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            tX.Value = 0;
            tY.Value = 0;
            tZ.Value = 0;

            mainCube = new Math3D.Cube(100, 100, 100); //Start over
            this.Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Render();
        }
    }
}