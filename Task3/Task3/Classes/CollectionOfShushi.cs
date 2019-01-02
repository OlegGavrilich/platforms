using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Classes
{
    public class CollectionOfShushi:FileManager
    {
        /// <summary>
        /// list that saves all sushi 
        /// </summary>
        public List<Sushi> list;
        /// <summary>
        /// Constructor without parameters
        /// </summary>
        public CollectionOfShushi()
        {
            list = new List<Sushi>();
        }
        /// <summary>
        /// Method that allow to read from file list of sushi
        /// </summary>
        /// <param name="filePath">
        /// string that discribes path to file to read from
        /// </param>
        public void Read(string filePath)
        {
            StreamReader Reader = new StreamReader(filePath, System.Text.Encoding.Default);
            string sLine = Reader.ReadLine();
            while (sLine != null)
            {
                string[] fields = sLine.Split();
                list.Add(new Sushi(fields[0], Convert.ToDouble(fields[1]), Convert.ToDouble(fields[2]), fields[3]));
                sLine = Reader.ReadLine();
            }
            Reader.Close();
        }
        /// <summary>
        /// Method that allow to write to file list of sushi
        /// </summary>
        /// <param name="filePath">
        /// string that discribes path to file to write to
        /// </param>
        public void Write(string filePath)
        {
            if (filePath == null)
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            using (StreamWriter writer = File.AppendText(filePath))
            {
                foreach (var i in list)
                {
                    string h = i.ToWrite();
                    writer.WriteLine(h);
                }
            }
        }
        /// <summary>
        /// Method that allow to add to list new sushi
        /// </summary>
        /// <param name="toAdd">
        /// Sushi that should be added to list
        /// </param>
        public void Add(Sushi toAdd)
        {
            if (list.Find(x => x.name == toAdd.name) != null || !toAdd.isGood())
            {
                throw new ArgumentNullException("This item is already in list or it is empty!");
            }
            else
            {
                list.Add(toAdd);
            }
        }
        /// <summary>
        /// Method allows to delete sushi from list by name
        /// </summary>
        /// <param name="nameToDelete">
        /// name of sushi that should be deleted
        /// </param>
        public void DeleteByName(string nameToDelete)
        {
            foreach (var i in list)
            {
                if (i.name == nameToDelete)
                {
                    list.Remove(i);
                }
            }
        }
        /// <summary>
        /// Method to get all list of sushi
        /// </summary>
        /// <returns>
        /// returns list of suhsi
        /// </returns>
        public List<Sushi> getList()
        {
            return list;
        }
    }
}
