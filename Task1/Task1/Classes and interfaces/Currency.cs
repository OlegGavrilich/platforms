using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Classes_and_interfaces
{
    class Currency
    {
        public void Read(List<Currency> ls)
        {
            StreamReader Reader = new StreamReader("File.txt", System.Text.Encoding.Default);
            string sLine = string.Empty;
            while (!Reader.EndOfStream)
            {
                Currency tmp = new Currency();

                for (int i = 0; i < 2; i++)
                {
                    sLine = Reader.ReadLine();
                    if (sLine == null)
                    {
                        throw new ArgumentNullException("Wrong name of currency!");
                    }

                    if (i == 0 && sLine != null)
                    {
                        CurrencyName toCheck = ConverterToCurrencyName.Convert(sLine);
                        if (toCheck != CurrencyName.None)
                        {
                            tmp.CurrencyName = toCheck;
                        }
                        else throw new ArgumentNullException("Wrong name of currency!");

                    }
                    else if (i == 1 && sLine != null)
                    {
                        tmp.Amount = double.Parse(sLine);
                    }
                }
                ls.Add(tmp);
            }
            Reader.Close();
        }

        /// <summary>
        /// Saves name of curency.
        /// </summary>
        public CurrencyName CurrencyName { get; set; }

        /// <summary>
        /// Saves amout of currency.
        /// </summary>
        public double Amount { get; set; }

        /// <summary>  
        ///  Constructors without parametrs of class Currency.
        /// </summary> 
        public Currency()
        {
            CurrencyName = CurrencyName.None;
            Amount = 0.0;
        }

        /// <summary>
        /// Constructor with paramets.
        /// </summary>
        /// <param name="currencyName">Name of currency.</param>
        /// <param name="Amount">Amount of currency.</param>
        public Currency(CurrencyName currencyName, double Amount)
        {
            this.CurrencyName = currencyName;
            this.Amount = Amount;
        }

        /// <summary>  
        ///  Method ShowUAN, for showing UAN only from list.
        /// </summary> 
        public void ShowUAN(List<Currency> ls)
        {
            foreach (Currency cur in ls)
            {
                if (cur.CurrencyName == CurrencyName.UAH)
                {
                    Console.WriteLine(cur.ToString());
                }
            }
        }
        /// <summary>  
        ///  Method ShowALL, for showing all list elements.
        /// </summary> 
        public void ShowALL(List<Currency> ls)
        {
            foreach (Currency cur in ls)
            {
                Console.WriteLine(cur.ToString());
            }
        }
        /// <summary>  
        /// Ovverided method ToString(), for methods ShowUAN and ShowALL.
        /// </summary> 
        public override string ToString() => "CurrencyName - " + this.CurrencyName + "\nAmount - " + this.Amount;
    }
}
