using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Classes_and_interfaces
{
    public class ConverterToCurrencyName
    {
        public static CurrencyName Convert(string toConvert)
        {
            CurrencyName result = CurrencyName.None;
            if (toConvert == "грн")
            {
                result = CurrencyName.UAH;
            }
            else if (toConvert == "$")
            {
                result = CurrencyName.Dollar;
            }
            else if (toConvert == "Є")
            {
                result = CurrencyName.Euro;
            }
            return result;
        }
    }
}
