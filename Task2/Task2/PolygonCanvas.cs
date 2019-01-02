using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Task2
{
   public class PolygonCanvas
    {
        private Canvas canvas = new Canvas();

        private List<MyPolygon> polygons = new List<MyPolygon>();

        public MyPolygon currentPolygon;

        private Point a;

        private Point b;

        private MyPolygon PolTemp;

        private bool isDraw = false;

        public PolygonCanvas()
        {
            this.PolTemp = new MyPolygon();
            this.PolTemp.Stroke = MyPolygon.FromBrush(Brushes.Green);
            this.PolTemp.shape.StrokeThickness = MyPolygon.DefaultStrokeThickness;
        }

        public PolygonCanvas(Canvas canvas) : this()
        {
            Canvas = canvas;
        }

        public delegate void ListChangedEvent(object sender, PolygonListChangedEventArgs args);

        public event ListChangedEvent OnEllipseAdded;

        public event ListChangedEvent OnEllipseRemoved;

        public Canvas Canvas
        {
            get
            {
                return this.canvas;
            }

            set
            {
                this.canvas = value;
            }
        }


        public List<MyPolygon> Polygons
        {
            get
            {
                return this.Polygons;
            }
        }


        public MyPolygon CurrentPolygon
        {
            get
            {
                return this.currentPolygon;
            }

            set
            {
                if (this.currentPolygon != null)
                {
                    this.currentPolygon.shape.StrokeThickness = MyPolygon.DefaultStrokeThickness;
                    Canvas.SetZIndex(this.currentPolygon.shape, 0);
                    //this.currentPolygon.shape.MouseLeftButtonDown -= this.Shape_MouseLeftButtonDown;
                    /*this.currentPolygon.shape.MouseLeftButtonUp -= this.Shape_MouseLeftButtonUp*/
                    
                    this.currentPolygon.shape.MouseMove -= this.Shape_MouseMove;
                    this.currentPolygon.shape.Focusable = false;
                }
                else
                {
                    //this.canvas.MouseLeftButtonUp -= this.CanvasDrawingArea_MouseLeftButtonUp;
                    //this.canvas.MouseMove -= this.CanvasDrawingArea_MouseMove;
                }

                this.currentPolygon = value;
                if (this.currentPolygon != null)
                {
                    this.currentPolygon.shape.StrokeThickness = MyPolygon.DefaultStrokeThickness * 2;
                    //this.currentPolygon.shape.MouseLeftButtonDown += this.Shape_MouseLeftButtonDown;
                    //this.currentPolygon.shape.MouseLeftButtonUp += this.Shape_MouseLeftButtonUp;
                    this.currentPolygon.shape.MouseMove += this.Shape_MouseMove;
                    Canvas.SetZIndex(this.currentPolygon.shape, 1);
                    this.currentPolygon.shape.Focusable = true;
                    Keyboard.ClearFocus();
                    Keyboard.Focus(this.currentPolygon.shape);
                }
                else
                {
                    //this.canvas.MouseLeftButtonUp += this.CanvasDrawingArea_MouseLeftButtonUp;
                    //this.canvas.MouseMove += this.CanvasDrawingArea_MouseMove;
                }
            }
        }

        public void AddPolygon(MyPolygon pol)
        {
            this.polygons.Add(pol);
            Canvas.SetZIndex(pol.shape, 0);
            Canvas.SetLeft(pol.shape, pol.TopLeft.X);
            Canvas.SetTop(pol.shape, pol.TopLeft.Y);
            this.Canvas.Children.Add(pol.shape);
            this.OnEllipseAdded?.Invoke(this, new PolygonListChangedEventArgs(pol, this));
        }

        public void Clear()
        {
            foreach (MyPolygon pol in this.Polygons)
            {
                this.OnEllipseRemoved?.Invoke(this, new PolygonListChangedEventArgs(pol, this));
            }

            this.currentPolygon = null;
            this.polygons.Clear();
            Canvas.Children.Clear();
        }

        public void RemovePolygon(MyPolygon pol)
        {
            this.polygons.Remove(pol);
            if (ReferenceEquals(this.currentPolygon, pol))
            {
                this.currentPolygon = null;
            }

            Canvas.Children.Remove(pol.shape);
            this.OnEllipseRemoved?.Invoke(this, new PolygonListChangedEventArgs(pol, this));
        }

        public bool IsEmpty()
        {
            return this.Polygons.Count == 0;
        }

        public void MovePolygon(Point a)
        {
            RemovePolygon(currentPolygon);
            currentPolygon.TopLeft = new Point(currentPolygon.TopLeft.X + a.X, currentPolygon.TopLeft.Y + a.Y);
            Canvas.SetTop(currentPolygon.shape, currentPolygon.TopLeft.Y);
            Canvas.SetLeft(currentPolygon.shape, currentPolygon.TopLeft.X);
            Canvas.Children.Add(currentPolygon.shape);
            polygons.Add(currentPolygon);
            //currentPolygon.TopLeft = new Point(currentPolygon.TopLeft.X + shift.X, currentPolygon.TopLeft.Y + shift.Y);
            //Canvas.SetTop(currentPolygon.shape, currentPolygon.TopLeft.Y);
            //Canvas.SetLeft(currentPolygon.shape, currentPolygon.TopLeft.X);
        }

        //private void Shape_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    this.a = e.GetPosition(Canvas);
        //    this.isDraw = true;
        //}

        public void Polygon_KeyDown(object sender, KeyEventArgs e)
        {
            Keyboard.ClearFocus();
            Key k = e.Key;
            switch (k)
            {
                case Key.Down:
                    {
                        this.MovePolygon(new Point(0.0, 1));
                        break;
                    }

                case Key.Up:
                    {
                        this.MovePolygon(new Point(0.0, -1));
                        break;
                    }

                case Key.Left:
                    {
                        this.MovePolygon(new Point(-1, 0.0));
                        break;
                    }

                case Key.Right:
                    {
                        this.MovePolygon(new Point(1, 0.0));
                        break;
                    }

                default:
                    {
                        break;
                    }
            }

            e.Handled = true;
            Keyboard.Focus(this.currentPolygon.shape);
        }

        private void Shape_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.isDraw = false;
        }

        private void Shape_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.isDraw)
            {
                this.b = e.GetPosition(Canvas);
                this.currentPolygon.TopLeft += this.b - this.a;
                this.a = this.b;
                Canvas.SetTop(this.currentPolygon.shape, this.currentPolygon.TopLeft.Y);
                Canvas.SetLeft(this.currentPolygon.shape, this.currentPolygon.TopLeft.X);
            }
        }

        public void bind(MyPolygon a)
        {
            a = currentPolygon;
        }
    }
}
