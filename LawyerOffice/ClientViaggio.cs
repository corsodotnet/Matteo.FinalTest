using LawyerOffice.Contracts.Delivery;
using PROGETTOMATTEO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LawyerOffice
{
    internal class ClientViaggio
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
        public static async Task<Country> RunAsync(string country, Feedback feedbackLawyer)
        {
            Country c = null;


            client.BaseAddress = new Uri("https://localhost:5001/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));

            c = await GetCountryByNameAsync(country);
            return c;
           // feedbackLawyer("il country selezionato è di colore " + c.ColorCountry);
            

        }
    }
}

