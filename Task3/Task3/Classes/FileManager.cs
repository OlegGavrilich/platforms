using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Classes
{
    public interface FileManager
    {
        /// <summary>
        /// Method witch read file
        /// </summary>
        /// <param name="filePath"></param>
        void Read(string filePath);
        /// <summary>
        /// Method witch write to file
        /// </summary>
        /// <param name="filePath"></param>
        void Write(string filePath);
    }
}
