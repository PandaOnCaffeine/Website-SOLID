using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Website_SOLID.Interfaces;

namespace Website_SOLID.Classes
{
    internal class ConsolePrinter : IPrinter
    {
        public ConsolePrinter() { }
        public void Print(string text)
        {
            Console.WriteLine(text);
        }
    }
}
