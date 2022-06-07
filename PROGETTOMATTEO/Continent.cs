using System.Collections.Generic;

namespace PROGETTOMATTEO
{
    public class Continent : AreaGeografica
    {
        public int ID { get; set; } 
        public string Name { get; set; }
        public long NAbitanti { get; set; }
        public long NPositivi { get; set; }
        public List<Country> countries { get; set; }

        public void CalcolaPositiviContinent()
        {
            long res = 0;
            foreach (var item in countries)
            {
                res = res +item.NPositivi;
            }
            NPositivi = res;
        }
    }
}
