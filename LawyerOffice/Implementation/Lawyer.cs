using LawyerOffice.Contracts;
using LawyerOffice.Contracts.Delivery;
using LawyerOffice.Service.DeliveryFood;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawyerOffice.Implementation
{
    internal class Lawyer : Employee
    {
        public LawyerOffice lawyerOffice;
        


        public async Task OrdinaTraduzione(LANGUAGE lang, string text)
        {
            await Task.Run(() => Console.WriteLine(lawyerOffice.OrdinaTraduzione(lang, text).Result));

        }

        public Lawyer()
        {
            feedback = GetFeedback;
            lawyerOffice = new LawyerOffice();
        }
        public void OrdinaTaskUfficio(DOCUMENTO documento)
        {
            lawyerOffice.OrdinaTask(documento, feedback);
        }
        public async Task<Food> OrdinazioneCibo(FOOD food)
        {
            
            return await Task.Run(() => lawyerOffice.OrdinaFood(food , feedback));
            
        }
        public void PrendiBliglietto(string country)
        {
            lawyerOffice.OrdinaViaggio(country, feedback);
        }
        
    }
}
