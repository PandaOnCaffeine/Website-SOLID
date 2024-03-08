using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Website_SOLID.Classes;
using Website_SOLID.Interfaces;

namespace Website_SOLID
{
    internal class Program
    {
        // HttpClient lifecycle management best practices:
        // https://learn.microsoft.com/dotnet/fundamentals/networking/http/httpclient-guidelines#recommended-use
        private static HttpClient client = new HttpClient()
        {
            BaseAddress = new Uri("https://jsonplaceholder.typicode.com"),
        };
        static async Task Main(string[] args)
        {
            IPrinter printerType; // Printer Type

            // Writes Menu
            Console.WriteLine("Select website part");
            Console.WriteLine("1. Website Part 1 (Console)");
            Console.WriteLine("2. Website Part 2 (File)");
            
            ConsoleKey key = Console.ReadKey().Key; // User Input

            switch (key)
            {
                case ConsoleKey.D1: // Website Part 1 (Console)
                    printerType = new ConsolePrinter();
                    break;
                case ConsoleKey.D2: // Website Part 2 (File)
                    // Path to File // Change To Other Path if git cloned // If there's no file at that path, then it creates a new one
                    string path = @"C:\Users\Tue\source\repos\Website SOLID\NewWriteFile.txt"; 
                    printerType = new FilePrinter(path);
                    break;
                default: // When User Selects something other then what is shown above
                    Console.WriteLine("Not Valid Option | Default: Website Part 1 (Console) Choosen");
                    printerType = new ConsolePrinter();
                    break;
            }

            // HttpClient is made as a private static variable in the top of this file
            WebRequester requester = new WebRequester(client, printerType); // Dependency Injection x2

            Console.WriteLine("URL: \"https://www.bt.dk\"");
            string url = "https://www.bt.dk";

            requester.SetBaseAddress(url); // Set the Url that the WebRequester uses
            await requester.GetAsync("/"); // Run Get Request to the Url

            /// Expected Result:
            /// 
            /// Part 1(Console)
            /// A Very Long HTML as Text Written in the console window.
            /// 
            /// Part 2(File)
            /// A Very Long HTML as Text Written in the file "WriteFile.txt" / Or at another .txt if path was changed.

            Console.ReadLine();
        }
    }
}
