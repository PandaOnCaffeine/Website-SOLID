using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Website_SOLID.Interfaces;

namespace Website_SOLID.Classes
{
    internal class FilePrinter : IPrinter
    {
        private string _path;
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }
        public FilePrinter(string path)
        {
            _path = path;
        }

        public void Print(string text)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(Path))
                {
                    writer.WriteLine(text);
                }
                Console.WriteLine($"Path: {Path}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
