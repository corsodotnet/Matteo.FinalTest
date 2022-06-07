using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using PROGETTOMATTEO;

namespace ClientHttp
{
    internal class Program
    {
        static HttpClient client = new HttpClient();

        static async Task<Country> GetCountryByNameAsync(string Name)
        {
            Country c = null;
            //api / AreaGeografica / Name ? name = Spagna
            HttpResponseMessage response = await client.GetAsync($"api/AreaGeografica/Name?name={Name}");
            if (response.IsSuccessStatusCode)
            {
                c = await response.Content.ReadAsAsync<Country>();
            }
            return c;
        }
        static void Main(string[] args)
        {

            RunAsync().GetAwaiter().GetResult();
            Console.WriteLine("this is the end!");
            Console.ReadLine();
        }
        static async Task RunAsync()
        {
            Country c = null;


            client.BaseAddress = new Uri("https://localhost:5001/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));

            c = await GetCountryByNameAsync("Germania");
            Console.WriteLine("il country selezionato è di colore " + c.ColorCountry);
           
        }
    }
    



}
