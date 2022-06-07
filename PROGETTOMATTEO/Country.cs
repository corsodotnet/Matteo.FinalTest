using System.Collections.Generic;

namespace PROGETTOMATTEO
{
    public class Country : AreaGeografica
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public long NAbitanti { get; set; }
       // public event NotificaCovid Notify;
        long nPositivi;
        public long NPositivi {get { return nPositivi; } set{
                if (nPositivi != value)
                {
                    nPositivi = value;
                  continent.CalcolaPositiviContinent();
                   

                }
            }
            } 
        public List<City> cities { get; set; }
        Continent continent;
        
        public Continent? Continent
        {
            get { return continent; }
            set
            {
                ContinentId = value.ID;
                continent = value;
            }
        }
        public int ContinentId { get; set; }
        public string ColorCountry { get; set; }
        public void CalcolaPositiviCountry()
        {
            long res =0;
            foreach (var item in cities)
            {
                res = res+ item.NPositivi;
            }
            NPositivi = res;
        }
        public void UpdateColor()
        {
            if (NPositivi <= 10000)
            {
                ColorCountry = "White";
            }
            if (NPositivi > 10000 && NPositivi <= 100000)
            {
                ColorCountry = "Yellow";
            }
            if (NPositivi > 100000 && NPositivi <= 500000)
            {
                ColorCountry = "Orange";
            }
            if (NPositivi > 500000)
            {
                ColorCountry = "Red";
            }
        }
    }
}
