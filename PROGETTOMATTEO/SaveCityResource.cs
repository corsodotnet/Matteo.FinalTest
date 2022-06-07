namespace PROGETTOMATTEO
{
    // Serve per il FROMBODY
    public class SaveCityResource
    {
        public int _NAbitanti { get; set; }
        public City  ToCity() => new City()
        {
            NAbitanti = _NAbitanti, 

        };
    }
    public class SaveCityResourceFull
    {
        public string _Name { get; set; }
        public int _NPositivi { get; set; } 
        public int _CountryID { get; set; } 
        public int _NAbitanti { get; set; }
        public City ToCity() => new City()
        {
            NAbitanti = _NAbitanti,
            Name = _Name,
            NPositivi = _NPositivi,
            countryId = _CountryID

        };
    }
        
}
