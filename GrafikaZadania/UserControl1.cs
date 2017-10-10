using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrafikaZadania
{
    public partial class UserControl1 : UserControl
    {

        private Shape shapeToDraw;
        private Point startPoint;
        private Point endPoint;
        private bool isDrawing;
        private bool isFocused;
        private bool isDragged;
        int dragHandle;
        Point dragPoint;
        Point dragLinePoint;
        Rectangle rectangle;
        Rectangle oldRect;
        Point oldStartPoint;
        Point oldEndPoint;

        public UserControl1()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            shapeToDraw = Shape.Empty;
            dragPoint = Point.Empty;
            startPoint = Point.Empty;
            endPoint = Point.Empty;

            isDrawing = false;
            isFocused = false;
            isDragged = false;
            dragHandle = -1;
            oldRect = Rectangle.Empty;
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void ShapeButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            SetButtonsColorDefault();

            switch (button.Name)
            {
                case "circleButton":
                    {
                        shapeToDraw = Shape.Circle;
                        circleButton.BackColor = Color.Red;
                    }
                    break;
                case "rectangleButton":
                    {
                        shapeToDraw = Shape.Rectangle;
                        rectangleButton.BackColor = Color.Red;
                    }
                    break;
                case "lineButton":
                    {
                        shapeToDraw = Shape.Line;
                        lineButton.BackColor = Color.Red;
                    }
                    break;
            }
        }

        private void ShapePanel_Paint(object sender, PaintEventArgs e)
        {
            switch (shapeToDraw)
            {
                case Shape.Circle:
                    {
                        e.Graphics.FillEllipse(Brushes.Red, rectangle);

                        e.Graphics.FillRectangle(Brushes.DarkBlue, GetHandleRect(1));
                        e.Graphics.FillRectangle(Brushes.DarkBlue, GetHandleRect(3));
                        e.Graphics.FillRectangle(Brushes.DarkBlue, GetHandleRect(6));
                        e.Graphics.FillRectangle(Brushes.DarkBlue, GetHandleRect(8));
                    }
                    break;
                case Shape.Rectangle:
                    {
                        e.Graphics.FillRectangle(Brushes.Red, rectangle);
                        for (int i = 1; i < 9; i++)
                        {
                            e.Graphics.FillRectangle(Brushes.DarkBlue, GetHandleRect(i));
                        }
                    }
                    break;
                case Shape.Line:
                    {
                        e.Graphics.DrawLine(new Pen(Color.Red), startPoint, endPoint);

                        e.Graphics.FillRectangle(Brushes.DarkBlue, GetLineHandleRect(1));
                        e.Graphics.FillRectangle(Brushes.DarkBlue, GetLineHandleRect(2));


                    }
                    break;
                default: break;
            }
        }

        private void ShapePanel_MouseDown(object sender, MouseEventArgs e)
        {


            for (int i = 1; i < 9; i++)
            {
                if (GetHandleRect(i).Contains(e.Location)&&shapeToDraw!=Shape.Line)
                {
                    dragHandle = i;

                    dragPoint = GetHandlePoint(i);
                    

                    oldRect = rectangle;
                    isDragged = true;
                }
                else if (GetLineHandleRect(i).Contains(e.Location))
                {
                    dragHandle = i;
                    dragLinePoint = GetLineHandlePoint(i);
                    oldRect = rectangle;
                    isDragged = true;
                }
            }

            if (rectangle.Contains(e.Location))
            {
                isFocused = true;
                dragPoint = e.Location;
                if (shapeToDraw == Shape.Line)
                {
                    oldStartPoint = startPoint;
                    oldEndPoint = endPoint;
                }
                oldRect = rectangle;
            }
            else if (!isDragged)
            {
                isDrawing = true;
                startPoint.X = e.X;
                startPoint.Y = e.Y;
                oldRect = rectangle;
            }
        }

        private void ShapePanel_MouseMove(object sender, MouseEventArgs e)
        {

            int diffX = 0;
            int diffY = 0;

            if (isDrawing)
            {
                endPoint.X = e.X;
                endPoint.Y = e.Y;
                DrawShape();
                ShapePanel.Invalidate();
            }
            else if (isFocused)
            {
                diffX = dragPoint.X - e.Location.X;
                diffY = dragPoint.Y - e.Location.Y;
                if (shapeToDraw != Shape.Line)
                {
                    rectangle.X = oldRect.X - diffX;
                    rectangle.Y = oldRect.Y - diffY;
                }
                else if (shapeToDraw == Shape.Line)
                {
                    startPoint.X = oldStartPoint.X - diffX;
                    startPoint.Y = oldStartPoint.Y - diffY;
                    endPoint.X = oldEndPoint.X - diffX;
                    endPoint.Y = oldEndPoint.Y - diffY;
                }

                ShapePanel.Invalidate();
            }
            else if (isDragged)
            {
                diffX = dragPoint.X - e.Location.X;
                diffY = dragPoint.Y - e.Location.Y;

                if (shapeToDraw == Shape.Rectangle)
                    switch (dragHandle)
                    {
                        case 1://lewy gorny
                            rectangle = new Rectangle(oldRect.Left - diffX, oldRect.Top - diffY, oldRect.Width + diffX, oldRect.Height + diffY);
                            break;
                        case 2://lewa
                            rectangle = new Rectangle(oldRect.Left - diffX, oldRect.Top, oldRect.Width + diffX, oldRect.Height);
                            break;
                        case 3://lewy dolny
                            rectangle = new Rectangle(oldRect.Left - diffX, oldRect.Top, oldRect.Width + diffX, oldRect.Height - diffY);
                            break;
                        case 4://góra
                            rectangle = new Rectangle(oldRect.Left, oldRect.Top - diffY, oldRect.Width, oldRect.Height + diffY);
                            break;
                        case 5://dól
                            rectangle = new Rectangle(oldRect.Left, oldRect.Top, oldRect.Width, oldRect.Height - diffY);
                            break;
                        case 6://prawy gorny
                            rectangle = new Rectangle(oldRect.Left, oldRect.Top - diffY, oldRect.Width - diffX, oldRect.Height + diffY);
                            break;
                        case 7://prawa
                            rectangle = new Rectangle(oldRect.Left, oldRect.Top, oldRect.Width - diffX, oldRect.Height);
                            break;
                        case 8://prawy dolny
                            rectangle = new Rectangle(oldRect.Left, oldRect.Top, oldRect.Width - diffX, oldRect.Height - diffY);
                            break;
                        default: break;
                    }
                else if (shapeToDraw == Shape.Circle)
                {
                    int diff = 0;
                    /*if (Math.Abs(diffX) <= Math.Abs(diffY))*/
                    diff = diffX;
                    //else diff = diffY;
                    switch (dragHandle)
                    {
                        case 1://lewy gorny
                            rectangle = new Rectangle(oldRect.Left - diff, oldRect.Top - diff, oldRect.Width + diff, oldRect.Height + diff);
                            break;
                        case 3://lewy dolny
                            rectangle = new Rectangle(oldRect.Left - diff, oldRect.Top, oldRect.Width + diff, oldRect.Height + diff);
                            break;
                        case 6://prawy gorny
                            rectangle = new Rectangle(oldRect.Left, oldRect.Top + diff, oldRect.Width - diff, oldRect.Height - diff);
                            break;
                        case 8://prawy dolny
                            rectangle = new Rectangle(oldRect.Left, oldRect.Top, oldRect.Width - diff, oldRect.Height - diff);
                            break;
                    }
                }
                else if (shapeToDraw == Shape.Line)//TODO: do poprawy
                {
                    diffX = dragLinePoint.X - e.Location.X;
                    diffY = dragLinePoint.Y - e.Location.Y;
                    switch (dragHandle)
                    {
                        case 1://lewy gorny
                            startPoint.X = dragLinePoint.X - diffX ;
                            startPoint.Y = dragLinePoint.Y - diffY;
                            rectangle = new Rectangle(oldRect.Left - diffX, oldRect.Top - diffY, oldRect.Width + diffX, oldRect.Height + diffY);
                            break;
                        case 2://lewy dolny
                            endPoint.X = dragLinePoint.X - diffX;
                            endPoint.Y = dragLinePoint.Y - diffY;
                            rectangle = new Rectangle(oldRect.Left - diffX, oldRect.Top, oldRect.Width + diffX, oldRect.Height - diffY);
                            break;
                        case 6://prawy gorny
                            rectangle = new Rectangle(oldRect.Left, oldRect.Top - diffY, oldRect.Width - diffX, oldRect.Height + diffY);
                            break;
                        case 8://prawy dolny
                            rectangle = new Rectangle(oldRect.Left, oldRect.Top, oldRect.Width - diffX, oldRect.Height - diffY);
                            break;
                    }
                }

                ShapePanel.Invalidate();
            }
        }

        private void ShapePanel_MouseUp(object sender, MouseEventArgs e)
        {
            isDragged = false;
            isFocused = false;
            isDrawing = false;
        }

        private void DrawShape()
        {
            rectangle = CreateRectangleFromPoints(startPoint, endPoint);
            int diffX = startPoint.X - endPoint.X;
            int diffY = startPoint.Y - endPoint.Y;
            if (shapeToDraw == Shape.Circle)
            {
                if (Math.Abs(diffX) < Math.Abs(diffY))
                {
                    rectangle.Width = Math.Abs(diffX); rectangle.Height = Math.Abs(diffX);
                }
                else
                {
                    rectangle.Width = Math.Abs(diffY); rectangle.Height = Math.Abs(diffY);
                }
            }
        }

        private Rectangle CreateRectangleFromPoints(Point start, Point end)
        {
            Point point = startPoint;
            Size size = new Size(endPoint.X - startPoint.X, endPoint.Y - startPoint.Y);

            if (endPoint.X - startPoint.X < 0)
            {
                point.X = endPoint.X;
                size.Width = startPoint.X - endPoint.X;
            }

            if (endPoint.Y - startPoint.Y < 0)
            {
                point.Y = endPoint.Y;
                size.Height = startPoint.Y - endPoint.Y;
            }

            return new Rectangle(point, size);
        }

        private void SetButtonsColorDefault()
        {
            circleButton.BackColor = Button.DefaultBackColor;
            rectangleButton.BackColor = Button.DefaultBackColor;
            lineButton.BackColor = Button.DefaultBackColor;
        }

        private Rectangle GetLineHandleRect(int value)
        {
            Point p = GetLineHandlePoint(value);

            return new Rectangle(p, new Size(5, 5));

        }

        private Point GetLineHandlePoint(int value)
        {
            switch (value)
            {
                case 1:
                    return startPoint;

                case 2:
                    return endPoint;
                default: return Point.Empty;
            }
        }

        private Point GetHandlePoint(int value)
        {
            switch (value)
            {
                case 1: return new Point(rectangle.Left, rectangle.Top); //lewy górny
                case 2: return new Point(rectangle.Left, rectangle.Top + (rectangle.Height / 2)); //środek lewego boku
                case 3: return new Point(rectangle.Left, rectangle.Bottom); //lewy dolny
                case 4: return new Point(rectangle.Left + (rectangle.Width / 2), rectangle.Top); //środek górnego boku
                case 5: return new Point(rectangle.Left + (rectangle.Width / 2), rectangle.Bottom); //środek dolnego boku
                case 6: return new Point(rectangle.Right, rectangle.Top); //prawy górny
                case 7: return new Point(rectangle.Right, rectangle.Top + (rectangle.Height / 2)); //środek prawego boku
                case 8: return new Point(rectangle.Right, rectangle.Bottom); //prawy dolny
                default: return Point.Empty;
            }
        }

        private Rectangle GetHandleRect(int value)
        {
            Point p = GetHandlePoint(value);
            p.Offset(-2, -2);
            return new Rectangle(p, new Size(5, 5));
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (shapeToDraw == Shape.Rectangle)
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
                {
                    rectangle.X = int.Parse(textBox1.Text);
                    rectangle.Y = int.Parse(textBox2.Text);
                    rectangle.Width = int.Parse(textBox3.Text);
                    rectangle.Height = int.Parse(textBox4.Text);
                }
            }
            else if (shapeToDraw == Shape.Circle)
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
                {
                    rectangle.Width = int.Parse(textBox3.Text) * 2;
                    rectangle.Height = int.Parse(textBox3.Text) * 2;
                    rectangle.X = int.Parse(textBox1.Text) - int.Parse(textBox3.Text);
                    rectangle.Y = int.Parse(textBox2.Text) - int.Parse(textBox3.Text);
                }
            }
            else if (shapeToDraw == Shape.Line)
            {
                if (textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "")
                {
                    startPoint.X = int.Parse(textBox5.Text);
                    startPoint.Y = int.Parse(textBox6.Text);
                    endPoint.X = int.Parse(textBox7.Text);
                    endPoint.Y = int.Parse(textBox8.Text);
                }
            }
            ShapePanel.Invalidate();
        }
    }
}
