using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Task2
{
    /// <summary>
    /// Логика взаимодействия для Dialog.xaml
    /// </summary>
    public partial class Dialog : Window
    {
        int count = 0;
        Canvas c;
        public Dialog(string v)
        {
            InitializeComponent();
        }
        public Dialog(Canvas c)
        {
            InitializeComponent();
            this.c = c;
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            count++;
            string name = "Polygon" + count.ToString();
            PointCollection cl = new PointCollection();
            cl.Add(new Point(15/*int.Parse(textBox2.Text)*/, 200/*int.Parse(textBox3.Text)*/));
            cl.Add(new Point(68/*int.Parse(textBox4.Text)*/, 70/*int.Parse(textBox5.Text)*/));
            cl.Add(new Point(110/*int.Parse(textBox6.Text)*/, 200/*int.Parse(textBox7.Text)*/));
            cl.Add(new Point(0/*int.Parse(textBox8.Text)*/, 125/*int.Parse(textBox9.Text)*/));
            cl.Add(new Point(135/*int.Parse(textBox10.Text)*/, 125/*int.Parse(textBox11.Text)*/));
            Polygon a = new Polygon
            {
                Name = name,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Fill = Brushes.Yellow,
                Points = cl
            };

            this.Close();
        }
    }
}
