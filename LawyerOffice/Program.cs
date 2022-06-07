using LawyerOffice.Implementation;
using System;
using System.Threading.Tasks;

namespace LawyerOffice
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Lawyer lawyer = new Lawyer();
            await lawyer.OrdinaTraduzione(LANGUAGE.ENG, "HI");
            lawyer.PrendiBliglietto("Germania");
            var y =await lawyer.OrdinazioneCibo(FOOD.PIZZA);
           
            //lawyer.OrdinaTaskUfficio(DOCUMENTO.MODULO);
            //await Task.WhenAll(y);
            Console.ReadLine(); 

        }
    }

    public enum LANGUAGE
    {
        ENG,
        GERMAN,
        SPANISH

    }
    public enum RESTAURANTTYPE
    { 
        BREAKFAST,
        LUNCH,
        DINNER

        

    }
    public enum FOOD
    {
        CAFFE,
        PANINO,
        PIZZA
    }

    public enum DOCUMENTO
    {
        MODULO,
        PRATICA
    }
    public enum TASKTYPE
    {
        LEGALE,
        FISCALE
    }


}
