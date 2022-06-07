using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROGETTOMATTEO
{
    public static class SeedData
    {
        public static async Task SeedDatabase(DatabaseCxt dbCtx)
        {
            var rand = new Random();

            //using (dbCtx)
            //{
            //    Clear(dbCtx._Continent);
            //    Clear(dbCtx._Country);
            //    Clear(dbCtx._City);
            //    dbCtx.SaveChanges();
            //}

            Continent _continent = new Continent()
            {
                Name = "Europa",
               
                NAbitanti = 1000000,
                countries = new List<Country>()
            };
            List<Country> _countries = new List<Country>()
            {
                new Country() { Name = "Germania" ,
                    
                    NAbitanti = 100000,
                    Continent =_continent,
                    cities= new List<City>()
                },
                new Country() { Name = "Italia" ,
                   
                    NAbitanti = 100000,
                    Continent =_continent,
                    cities= new List<City>()},
                new Country() { Name = "Spagna" ,
                   
                    NAbitanti = 100000,
                    Continent =_continent,
                    cities= new List<City>()},
                
            };
            List<City> _cities = new List<City>() {
                new City(){
                    Country = _countries[1],
                    Name = "Torino",
                    NPositivi =3000,
                    NAbitanti = 100000,
                    
                },
                new City(){
                     Country = _countries[1],
                    Name = "Milano",
                    NPositivi = 4000,
                    NAbitanti = 100000,
                   
                },
                
                
            };
            List<City> _cities1 = new List<City>()
            {
                new City(){
                     Country = _countries[2],
                    Name = "Barcellona",
                    NPositivi = 4050,
                    NAbitanti = 100000,
                   
                },
                new City(){
                    Country = _countries[2],
                    Name = "Madrid",
                    NPositivi = 6000,
                    NAbitanti = 100000,
                    
                },
            };
            List<City> _cities2 = new List<City>()
            {
                new City(){
                    Country = _countries[0],
                    Name = "Berlino",
                    NPositivi = 9000,
                    NAbitanti = 100000,
                    
                },
                new City(){
                    Country = _countries[0],
                    Name = "Amburgo",
                    NPositivi = 1000,
                    NAbitanti = 10000,
                    
                },
            };


                _continent.countries = _countries;
            
            _continent.countries[0].cities = _cities2;
            _continent.countries[1].cities = _cities;
            _continent.countries[2].cities = _cities1;

            _continent.countries[0].CalcolaPositiviCountry();
            _continent.countries[1].CalcolaPositiviCountry();
            _continent.countries[2].CalcolaPositiviCountry();
            _continent.CalcolaPositiviContinent();
            //_continent.countries.AddRange(_countries);
            _continent.countries[0].UpdateColor();
            _continent.countries[1].UpdateColor();
            _continent.countries[2].UpdateColor();

            _continent.countries[0].cities[0].NPositivi = 200000;
            using (dbCtx)
            {
                dbCtx._Continent.Add(_continent);

                try
                {
                    await dbCtx.SaveChangesAsync();
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }
            public static void Clear<T>(this DbSet<T> dbSet) where T : class
        {
            if (dbSet.Any())
            {
                dbSet.RemoveRange(dbSet.ToList());
            }
        }
    }
}
