using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Classes_and_interfaces
{
    class File_manager
    {
        public static bool Save(string filePath, Dictionary<CurrencyName, double> List)
        {
            if (filePath == null)
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            using (var writer = new StreamWriter(filePath))
            {
                foreach (var i in List)
                {
                    writer.WriteLine("CurrencyName - " + i.Key + " Amount - " + Math.Round(i.Value, 2));
                }
            }
            return true;
        }
    }
}
