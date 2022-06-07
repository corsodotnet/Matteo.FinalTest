using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LawyerOffice.Contracts.Delivery;
using LawyerOffice.Implementation;
using LawyerOffice.Service.DeliveryFood;
using LawyerOffice.Service.DeliveryTask;
using PROGETTOMATTEO;

namespace LawyerOffice
{
    public class ManagerOffice : Employee
    {
        
        TranslationOffice translationOffice = new TranslationOffice();
        //FactoryDelivery delivery = new FactoryDelivery();
        FoodDelivery foodDelivery = new FoodDelivery();
        Restaurant restaurant;
        
           
        TaskDelivery taskDelivery = new TaskDelivery();
        TaskService taskService;
        public async Task<string> StartTranslation(LANGUAGE lang, string text)
        {
            // return translationOffice.Translate(lang, text);

            var translation = FactoryTranslation.GetTranslator(lang).Translate(text);
            await Task.Delay(2000); 
            return translation; 
            //return translator.Translate(text);

        }
        public ManagerOffice()
        {
            feedback = GetFeedback;
        }
        public Food StartOrdine(FOOD ordine , Feedback feedbackLawyer)
        {
            
            Restaurant r =  foodDelivery.GetNameRestaurants(ordine);
            Food food = foodDelivery.DeliveryOrder(r, feedback);


            feedbackLawyer(food.FoodName + " è arrivato");
           
            return food;
        }
        public OfficeTask StartOrdineTask(DOCUMENTO documento, Feedback feedbackTaskLawyer)

        {
            taskService = taskDelivery.GetTaskService(documento);
            OfficeTask officeTask = taskDelivery.TaskOrder(taskService, feedback);
            feedbackTaskLawyer("Il task " + officeTask.TaskName + " è arrivato");
            return officeTask;

        }
        public void StartOrdinaViaggio(string country, Feedback feedbackLawyer)

        {
           Country c = ClientViaggio.RunAsync(country , feedbackLawyer).GetAwaiter().GetResult();
            feedbackLawyer("il country selezionato è di colore " + c.ColorCountry);
        }


        


       
        


    }
}
