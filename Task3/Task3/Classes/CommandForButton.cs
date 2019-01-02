using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Task3.Classes
{
    class CommandForButton
    {
        /// <summary>
        /// Button delete for get value
        /// </summary>
        public static RoutedCommand Delete { get; set; }
        /// <summary>
        /// Button tolist for get list
        /// </summary>
        public static RoutedCommand ToList { get; set; }
        /// <summary>
        /// Some method what can with commands
        /// </summary>
        static CommandForButton()
        {
            Delete = new RoutedCommand("Delete", typeof(MainWindow));
            ToList = new RoutedCommand("ToList", typeof(MainWindow));
        }
    }
}
