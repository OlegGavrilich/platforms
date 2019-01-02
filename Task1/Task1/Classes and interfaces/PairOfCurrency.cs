using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Classes_and_interfaces
{
    public class PairOfCurrency
    {
        public static Dictionary<CurrencyName, double> DoPair(IEnumerable<Currency> List)
        {
            Dictionary<CurrencyName, double> currencies = new Dictionary<CurrencyName, double>();
            foreach (var i in List)
            {
                if (currencies.ContainsKey(i.CurrencyName))
                {
                    currencies[(i.CurrencyName)] += i.Amount;
                }
                else
                {
                    currencies.Add(i.CurrencyName, i.Amount);
                }
            }
            if (currencies.Count == 0)
            {
                throw new ArgumentNullException("Dictionary is empty!");
            }
            return currencies;
        }
    }
}
