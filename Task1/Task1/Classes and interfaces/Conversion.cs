using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Classes_and_interfaces
{
    public class Conversion
    {
        public static Dictionary<CurrencyName, double> To(Dictionary<CurrencyName, double> List, CurrencyName Name)
        {
            Dictionary<CurrencyName, double> Result = new Dictionary<CurrencyName, double>();
            double ExchangeValue = 0;
            if (CurrencyName.Euro == Name)
            {
                ExchangeValue += Calculate(List[CurrencyName.Dollar], Program.DOLLAR_VALUE, Program.EURO_VALUE);
                ExchangeValue += Calculate(List[CurrencyName.UAH], Program.UAH_VALUE, Program.EURO_VALUE);
                ExchangeValue += (List[CurrencyName.Euro]);

            }
            else if (CurrencyName.Dollar == Name)
            {
                ExchangeValue += Calculate(List[CurrencyName.Euro], Program.EURO_VALUE, Program.DOLLAR_VALUE);
                ExchangeValue += Calculate(List[CurrencyName.UAH], Program.UAH_VALUE, Program.DOLLAR_VALUE);
                ExchangeValue += (List[CurrencyName.Dollar]);
            }
            else if (CurrencyName.UAH == Name)
            {
                ExchangeValue += Calculate(List[CurrencyName.Dollar], Program.DOLLAR_VALUE, Program.UAH_VALUE);
                ExchangeValue += Calculate(List[CurrencyName.Euro], Program.EURO_VALUE, Program.UAH_VALUE);
                ExchangeValue += (List[CurrencyName.UAH]);
            }
            else throw new ArgumentNullException("None type of currency name!");

            Result.Add(Name, ExchangeValue);

            return Result;
        }

        public static double Calculate(double amount, double firstCurrencyCourse, double secondCurrencyCourse)
        {
            return amount * firstCurrencyCourse / secondCurrencyCourse;
        }
    }
}
