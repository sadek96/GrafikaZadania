using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Reflection;

namespace GrafikaZadania
{
    public partial class UserControl6 : UserControl
    {
        [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
        private static extern bool BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, System.Int32 dwRop);

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern IntPtr ReleaseDC(IntPtr hwnd, IntPtr hdc);

        public UserControl6()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            this.DoubleBuffered = true;

            typeof(Panel).InvokeMember("DoubleBuffered",
BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
null, picCanvas, new object[] { true });
        }

        private PointF[] Points = new PointF[4];

        private Rectangle[] PointsBounds = new Rectangle[4];

        private int NextPoint = 0;

        private bool drag = false;
        private int dragIndex = -1;
        private PointF oldPoint = new PointF();

        private void picCanvas_MouseClick(object sender, MouseEventArgs e)
        {

            if (NextPoint < 4)
            {

                Points[NextPoint].X = e.X;
                Points[NextPoint].Y = e.Y;
                PointsBounds[NextPoint] = new Rectangle(e.X - 3, e.Y - 3, 6, 6);

                NextPoint++;

                picCanvas.Refresh();
            }
        }

        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(Control.DefaultBackColor);
            if (NextPoint >= 4)
            {
                Bezier.DrawBezier(e.Graphics, Pens.Black, 0.01f,
                    Points[0], Points[1], Points[2], Points[3]);
            }

            // Draw the control points.
            for (int i = 0; i < NextPoint; i++)
            {
                e.Graphics.FillRectangle(Brushes.White, PointsBounds[i]);
                e.Graphics.DrawRectangle(Pens.Black, PointsBounds[i]);
            }
        }

        public void Reset()
        {
            this.NextPoint = 0;
            picCanvas.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void picCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            Point mp = new Point(e.X, e.Y);
            if (!drag)
                for (int i = 0; i < PointsBounds.Length; i++)
                {
                    if (PointsBounds[i].Contains(mp))
                    {
                        drag = true;
                        dragIndex = i;
                        oldPoint.X = Points[i].X;
                        oldPoint.Y = Points[i].Y;
                    }
                }
        }

        private void picCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Points[dragIndex].X = e.X;
                Points[dragIndex].Y = e.Y;
                PointsBounds[dragIndex].X = e.X - 3;
                PointsBounds[dragIndex].Y = e.Y - 3;
                picCanvas.Refresh();
            }
        }

        private void picCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Points[dragIndex].X = e.X;
                Points[dragIndex].Y = e.Y;
                PointsBounds[dragIndex].X = e.X - 3;
                PointsBounds[dragIndex].Y = e.Y - 3;
                picCanvas.Refresh();
                drag = false;
            }
        }
    }
}
