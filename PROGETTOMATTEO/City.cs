namespace PROGETTOMATTEO
{
    public class City : AreaGeografica
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public long NAbitanti { get; set; }
        //public event NotificaCovid Notify;
        long nPositivi;
        public long NPositivi
        {
            get { return nPositivi; }
            set
            {
                if (nPositivi != value)
                {
                    nPositivi = value;
                    country.CalcolaPositiviCountry();
                    country.UpdateColor();


                }
            }
        }
        Country country;
        public Country? Country { get { return country; } set
            {
                countryId = value.ID;
                country = value;
            } }
        public int countryId { get; set; }

    }
}
