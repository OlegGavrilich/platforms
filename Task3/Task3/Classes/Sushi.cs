using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Classes
{
    public class Sushi
    {
        /// <summary>
        /// to save name of sushi
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// to save price of sushi
        /// </summary>
        public double price { get; set; }
        /// <summary>
        /// to save weight of sushi
        /// </summary>
        public double weight { get; set; }
        /// <summary>
        /// to save all ingredients of sushi
        /// </summary>
        public string ingredients { get; set; }
        /// <summary>
        /// COnstructor without parameters
        /// </summary>
        public Sushi()
        {
            ingredients = string.Empty;
            price = double.NaN;
            name = string.Empty;
            weight = double.NaN;
        }
        /// <summary>
        /// Constructor with parametrs
        /// </summary>
        /// <param name="nm">
        /// parametr for name
        /// </param>
        /// <param name="pr">
        /// parametr for price
        /// </param>
        /// <param name="wght">
        /// parametr for weight
        /// </param>
        /// <param name="ing">
        /// parametr for ingredients
        /// </param>
        public Sushi(string nm, double pr, double wght, string ing)
        {
            ingredients = ing;
            price = pr;
            name = nm;
            weight = wght;
        }
        /// <summary>
        /// Mothod to check is all fields correct
        /// </summary>
        /// <returns>
        /// true if is good and false if not
        /// </returns>
        public bool isGood()
        {
            if (this.name != string.Empty && this.price != double.NaN && this.weight != double.NaN && this.ingredients != string.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Method that return sushi as string
        /// </summary>
        /// <returns>
        /// sushi presented as string
        /// </returns>
        public override string ToString()
        {
            return name + " " + price + " uah " + weight + " g " + ingredients;
        }
        /// <summary>
        /// Method for transformation our sushi as string to write in order file
        /// </summary>
        /// <returns>
        /// sushi presented as string
        /// </returns>
        public string ToWrite()
        {
            return name + " " + price + " uah " + weight + " g " + ingredients;
        }
        /// <summary>
        /// Method for transformation our sushi as string for list
        /// </summary>
        /// <returns>
        /// sushi presented as string
        /// </returns>
        public string ForList
        {
            get
            {
                return $"{name} {price} uah";
            }
        }
    }
}
