using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
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

namespace Task3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Sushiarr.Read(@"C:\Users\gembi\Source\Repos\PlatformPMi-35\Team_Aaa\Task3\Task3\Text files\sushi_list.txt");
            Sushiarr.Read(@"..\..\Text files\sushi_list.txt");
            using (StreamReader reader = new StreamReader(@"..\..\Text files\NumberOfOrders.txt"))
            {
                numberoforders = Convert.ToInt32(reader.ReadToEnd());
            }
            butt1.DataContext = Sushiarr.list[0];
            butt2.DataContext = Sushiarr.list[1];
            butt3.DataContext = Sushiarr.list[2];
            butt4.DataContext = Sushiarr.list[3];
            butt5.DataContext = Sushiarr.list[4];
            butt6.DataContext = Sushiarr.list[5];
            buylist.DisplayMemberPath = "ForList";
        }
        public void Execute_ToList(object sender, ExecutedRoutedEventArgs e)
        {
            Button b = (Button)e.OriginalSource;
            Classes.Sushi sushi = (Classes.Sushi)b.DataContext;
            buylist.Items.Add(sushi);
            double s = Convert.ToDouble(Sum1.Content);
            s += sushi.price;
            Sum1.Content = s.ToString();
        }
        public void Execute_Delete(object sender, RoutedEventArgs e)
        {
            if (buylist.SelectedIndex == -1)
            {
                return;
            }
            Classes.Sushi sushi = (Classes.Sushi)buylist.Items.GetItemAt(buylist.SelectedIndex);
            double s = Convert.ToDouble(Sum1.Content);
            s -= sushi.price;
            Sum1.Content = s.ToString();
            buylist.Items.RemoveAt(buylist.SelectedIndex);

        }
        public void Executr_Order(object sender, RoutedEventArgs e)
        {
            Classes.CollectionOfShushi tmpsushi = new Classes.CollectionOfShushi();
            using (StreamWriter writer = new StreamWriter($@"..\..\Orders\Order_{numberoforders}.txt"))
            {
                DateTime dataTime = DateTime.Now;
                writer.WriteLine($"Order #{numberoforders} {dataTime.ToString()}");
                for (int i = 0; i < buylist.Items.Count; i++)
                {
                    writer.WriteLine(((Classes.Sushi)buylist.Items[i]).ToWrite());
                }
                writer.WriteLine($"Sum={Sum1.Content} uah");
            }
            numberoforders++;
            using (StreamWriter reader = new StreamWriter(@"..\..\Text files\NumberOfOrders.txt"))
            {
                reader.WriteLine(numberoforders);
            }
            buylist.Items.Clear();
            Sum1.Content = "0";
        }
        Classes.CollectionOfShushi Sushiarr = new Classes.CollectionOfShushi();
        static int numberoforders = 0;


    }
}
