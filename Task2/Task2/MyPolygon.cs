using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Task2
{
    public class MyPolygon
    {
        //public bool IsChosen;
        public static readonly double DefaultStrokeThickness = 1.5;
        public Polygon shape { get; set; }
        public MyPolygon()
        {
            //IsChosen = false;
            this.shape = new Polygon();
            this.shape.StrokeThickness = DefaultStrokeThickness;
        }
        public Point TopLeft { get; set; }
        public string Name { get; set; }
        public PointCollection Points;
        public Color Stroke
        {
            get
            {
                return FromBrush(this.shape.Stroke);
            }

            set
            {
                this.shape.Stroke = new SolidColorBrush(value);
            }
        }
        public Color Fill
        {
            get
            {
                return FromBrush(this.shape.Fill);
            }

            set
            {
                this.shape.Fill = new SolidColorBrush(value);
            }
        }
        public double Width
        {
            get
            {
                return this.shape.Width;
            }

            set
            {
                this.shape.Width = value;
            }
        }
        public double Height
        {
            get
            {
                return this.shape.Height;
            }

            set
            {
                this.shape.Height = value;
            }
        }
        public static Color FromBrush(Brush br)
        {
            byte a = ((Color)br.GetValue(SolidColorBrush.ColorProperty)).A;
            byte g = ((Color)br.GetValue(SolidColorBrush.ColorProperty)).G;
            byte r = ((Color)br.GetValue(SolidColorBrush.ColorProperty)).R;
            byte b = ((Color)br.GetValue(SolidColorBrush.ColorProperty)).B;
            return new Color { A = a, R = r, G = g, B = b };
        }
    }
}
