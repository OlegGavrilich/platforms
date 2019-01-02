using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace Task2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool IsDraw = false;
        MyPolygon currentPolygon = new MyPolygon();
        public List<MyPolygon> collection = new List<MyPolygon>();
        private PolygonCanvas polygonCanvas = new PolygonCanvas();
        int z = 1;
        PointCollection pointCollection;
        public MainWindow()
        {
            IsDraw = false;
            polygonCanvas.Canvas.Children.Add(currentPolygon.shape);
            currentPolygon = new MyPolygon();
            this.InitializeComponent();
            this.DataContext = this;
            this.polygonCanvas.Canvas = this.DrawCanvs;
        }
        Polygon pol = new Polygon();

        /// <summary>
        /// Clear canvas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            DrawCanvs.Children.Clear();
            collection.Clear();
            Menu_it.Items.Clear();
            z = 1;
        }

        /// <summary>
        /// Save .jpg image
        /// </summary>
        /// <param name="surface"></param>
        public void ExportToPng(Canvas surface)
        {

            // Save current canvas transform
            Transform transform = surface.LayoutTransform;
            // reset current transform (in case it is scaled or rotated)
            surface.LayoutTransform = null;

            // Get the size of canvas
            Size size = new Size(surface.Width, surface.Height);
            // Measure and arrange the surface
            // VERY IMPORTANT
            surface.Measure(size);
            surface.Arrange(new Rect(size));

            // Create a render bitmap and push the surface to it
            RenderTargetBitmap renderBitmap =
              new RenderTargetBitmap(
                (int)size.Width,
                (int)size.Height,
                96d,
                96d,
                PixelFormats.Pbgra32);
            renderBitmap.Render(surface);

            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.ShowDialog();
            saveFileDialog.Filter = "Image documents (.jpg)|*.jpg";
            string fileName = saveFileDialog.FileName;
            // Create a file stream for saving image
            using (FileStream outStream = new FileStream(fileName, FileMode.CreateNew))
            {
                // Use png encoder for our data
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                // push the rendered bitmap to it
                encoder.Frames.Add(BitmapFrame.Create(renderBitmap));
                // save the data to the stream
                encoder.Save(outStream);
            }

            MessageBox.Show("Succesfully saved!");
            // Restore previously saved layout
            surface.LayoutTransform = transform;
        }


        //public void MainMenuAdd(string NameOfFigure)
        //{
        //    MenuItem menuShape = new MenuItem();
        //    menuShape.Header = NameOfFigure;
        //    this.Menu_it.Items.Add(menuShape);
        //}
        int count = 0;
        /// <summary>
        /// Shapes menu
        /// </summary>
        /// <param name="a"></param>
        public void MainMenuAdd(Polygon a)
        {
            count++;
            switch (count)
            {
                case 1: this.can1.Height = 80; this.can1.Children.Add(a); break;
                case 2: this.can2.Height = 80; this.can2.Children.Add(a); break;
                case 3: this.can3.Height = 80; this.can3.Children.Add(a); break;
                case 4: this.can4.Height = 80; this.can4.Children.Add(a); break;
                case 5: this.can5.Height = 80; this.can5.Children.Add(a); break;
                case 6: this.can6.Height = 80; this.can6.Children.Add(a); break;
                case 7: this.can7.Height = 80; this.can7.Children.Add(a); break;
                case 8: this.can8.Height = 80; this.can8.Children.Add(a); break;
                case 9: this.can9.Height = 80; this.can9.Children.Add(a); break;
                case 10: this.can10.Height = 80; this.can10.Children.Add(a); break;
                case 11: this.can11.Height = 80; this.can11.Children.Add(a); break;
                case 12: this.can12.Height = 80; this.can12.Children.Add(a); break;
                default:
                    break;
            }
        }


        PointCollection polcol = new PointCollection();
        PointCollection points = new PointCollection();

        /// <summary>
        /// Counts point
        /// </summary>
        int i = 0;
        /// <summary>
        /// Draws canvas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!IsDraw)
            {
                Point pp = new Point();
                pp = Mouse.GetPosition(this);
                polcol.Add(pp);
                double tempX = (Mouse.GetPosition(this).X) / 6;
                double tempY = (Mouse.GetPosition(this).Y) / 6;
                Point pt = new Point(tempX, tempY);
                points.Add(pt);
                ++i;
                if (i > 4)
                {
                    MyPolygon newP = new MyPolygon();
                    Polygon tt = new Polygon
                    {
                        Name = "",
                        Stroke = Brushes.Black,
                        Fill = Brushes.Yellow,
                        Points = polcol
                    };
                    Polygon temp = new Polygon
                    {
                        Name = "",
                        Stroke = Brushes.Black,
                        Fill = Brushes.Yellow,
                        Points = points
                    };
                    newP.shape = tt;
                    ColorDialog a = new ColorDialog(newP);
                    a.Owner = this;
                    a.Show();
                    polygonCanvas.AddPolygon(newP);
                    collection.Add(newP);
                    temp.Fill = newP.shape.Fill;
                    MainMenuAdd(temp);
                    polcol = new PointCollection();
                    points = new PointCollection();
                    i = 0;
                    z++;
                }
            }
        }

        /// <summary>
        /// Right mouse button action that  choses shape
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawCanvas_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            int count = 0;

            Point t = e.GetPosition((UIElement)sender);

            for (int i = 0; i < collection.Count; ++i)
            {
                HitTestResult result = VisualTreeHelper.HitTest(collection[i].shape, t);
                if (result != null)
                {
                    IsDraw = true;
                    count++;
                    MessageBox.Show("Found!");
                    //i.IsChosen = !i.IsChosen;
                    polygonCanvas.CurrentPolygon = collection[i];
                    polygonCanvas.CurrentPolygon.Stroke = MyPolygon.FromBrush(Brushes.Red); break;
                }
                else polygonCanvas.CurrentPolygon = new MyPolygon();
            }
            if (count == 0) IsDraw = false;
        }

        /// <summary>
        /// Keyboard buttons action that moves shapes down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Keyboard_down(object sender, KeyEventArgs e)
        {
            //Keyboard.ClearFocus();
            Key k = e.Key;
            switch (k)
            {
                case Key.Down:
                    {
                        polygonCanvas.CurrentPolygon.TopLeft = new Point(polygonCanvas.CurrentPolygon.TopLeft.X + 1, polygonCanvas.CurrentPolygon.TopLeft.Y);
                        Canvas.SetLeft(polygonCanvas.CurrentPolygon.shape, polygonCanvas.CurrentPolygon.TopLeft.Y);
                        Canvas.SetTop(polygonCanvas.CurrentPolygon.shape, polygonCanvas.CurrentPolygon.TopLeft.X + 1);
                        break;
                    }

                case Key.Up:
                    {
                        polygonCanvas.CurrentPolygon.TopLeft = new Point(polygonCanvas.CurrentPolygon.TopLeft.X - 1, polygonCanvas.CurrentPolygon.TopLeft.Y);
                        Canvas.SetLeft(polygonCanvas.CurrentPolygon.shape, polygonCanvas.CurrentPolygon.TopLeft.Y);
                        Canvas.SetTop(polygonCanvas.CurrentPolygon.shape, polygonCanvas.CurrentPolygon.TopLeft.X - 1);
                        break;
                    }

                case Key.Left:
                    {
                        polygonCanvas.CurrentPolygon.TopLeft = new Point(polygonCanvas.CurrentPolygon.TopLeft.X, polygonCanvas.CurrentPolygon.TopLeft.Y - 1);
                        Canvas.SetLeft(polygonCanvas.CurrentPolygon.shape, polygonCanvas.CurrentPolygon.TopLeft.Y - 1);
                        Canvas.SetTop(polygonCanvas.CurrentPolygon.shape, polygonCanvas.CurrentPolygon.TopLeft.X);
                        break;
                    }

                case Key.Right:
                    {
                        polygonCanvas.CurrentPolygon.TopLeft = new Point(polygonCanvas.CurrentPolygon.TopLeft.X, polygonCanvas.CurrentPolygon.TopLeft.Y + 1);
                        Canvas.SetLeft(polygonCanvas.CurrentPolygon.shape, polygonCanvas.CurrentPolygon.TopLeft.Y + 1);
                        Canvas.SetTop(polygonCanvas.CurrentPolygon.shape, polygonCanvas.CurrentPolygon.TopLeft.X);
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
        /// <summary>
        /// Moves shape
        /// </summary>
        /// <param name="pol"></param>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Move(MyPolygon pol, object sender, MouseButtonEventArgs e)
        {
            Point pt = e.GetPosition((UIElement)sender);
            pol.TopLeft = pt;
        }

        /// <summary>
        /// Writes in XML file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            if (polcol == null)
            {
                MessageBox.Show("Point collection is empty", "", MessageBoxButton.OK);
            }
            else
            {
                XmlSerializer formatter = new XmlSerializer(typeof(PointCollection));
                using (FileStream fs = new FileStream("../../Polygon.xml", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, polcol);
                }
                MessageBox.Show("Was written in xml file \"Polygon.xml\"", "", MessageBoxButton.OK);
            }
        }
        /// <summary>
        /// Opens file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Open_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Image documents (.jpg)|*.jpg";
            openFileDialog.ShowDialog();
            string fileName = openFileDialog.FileName;
            ImageBrush brush = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri(fileName, UriKind.Relative));
            DrawCanvs.Background = brush;
        }
        /// <summary>
        /// convert to .jpg
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            ExportToPng(DrawCanvs);
        }
    }
}
