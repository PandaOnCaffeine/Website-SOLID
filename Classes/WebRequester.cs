using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Website_SOLID.Interfaces;

namespace Website_SOLID.Classes
{
    internal class WebRequester
    {
        private HttpClient _http;
        private IPrinter _printerType;
        public WebRequester(HttpClient http, IPrinter printerType)
        {
            _http = http;
            _printerType = printerType;
        }

        public void SetBaseAddress(string baseAddress)
        {
            _http.BaseAddress = new Uri(baseAddress); // Configure the base address of the shared client
        }

        public async Task GetAsync(string requestUri)
        {
            try
            {
                var response = await _http.GetAsync(requestUri); // Send a GET request to the specified Uri
                response.EnsureSuccessStatusCode(); // Throw an exception if the status code is unsuccessful
                _printerType.Print(await response.Content.ReadAsStringAsync()); // Write the result to the chosen output method
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync($"Error: {ex.Message}");
                throw;
            }
        }
    }
}
