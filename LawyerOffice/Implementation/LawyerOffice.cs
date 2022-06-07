using LawyerOffice.Contracts.Delivery;
using LawyerOffice.Service.DeliveryFood;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawyerOffice
{
    internal class LawyerOffice
    {
        public string codiceDocumento;
        ManagerOffice manager = new ManagerOffice();
      

        public async Task<Food> OrdinaFood(FOOD ordine , Feedback feedbackLawyer)
        {

            return await Task.Run(() => manager.StartOrdine(ordine, feedbackLawyer));
            //var food = await manager.StartOrdine(ordine , feedbackLawyer);
            //return food;

        }
      


        
        public async Task<string> OrdinaTraduzione(LANGUAGE lang, string text)
        {
            return await manager.StartTranslation(lang, text);
        }

        //public void OrdinaFood(ORDINI ordine)
        //{
        //    Console.WriteLine(manager.StartOrdine(ordine));
        //}
        public void  OrdinaTask(DOCUMENTO documento, Feedback feedbackTaskLawyer)
        {
            manager.StartOrdineTask(documento, feedbackTaskLawyer);
        }
        public void OrdinaViaggio(string country , Feedback feedbackLawyer)
        {
            manager.StartOrdinaViaggio(country, feedbackLawyer);
        }


    }
}
