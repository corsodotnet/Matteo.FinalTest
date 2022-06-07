using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PROGETTOMATTEO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaGeograficaController : ControllerBase
    {
        private readonly ILogger<AreaGeograficaController> _logger;
        private readonly IMapper _mapper;
        private DatabaseCxt _context;
        private IOptions<AppSettings> _setting;
        // GET: api/<AreaGeograficaController>

        public AreaGeograficaController(ILogger<AreaGeograficaController> logger, DatabaseCxt ctx)
        {

            _logger = logger;
            _context = ctx;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Continente = await _context._Continent.ToListAsync();
            return Ok(Continente);
        }

       // GET api/<AreaGeograficaController>/5
        [HttpGet("Name")]
        public async Task<IActionResult> Get(string name)
        {
            Country c = null;
            using (_context)
            {
                try
                {
                    c = await _context._Country.Where(x => x.Name == name).FirstAsync();
                    return Ok(c);
                }
                catch (Exception ex)
                {
                    throw;
                }
                
            }
        }

        //POST api/<AreaGeograficaController>
        //[HttpPost]
        //public IActionResult Post([FromBody] SaveCityResourceFull savecity)
        //{
        //    City result = null;
        //    try
        //    {
        //        try
        //        {
        //            result = _context._City.Add(savecity.ToCity()).Entity;
        //            _context.SaveChanges();
        //            return Ok(result);
        //        }
        //        catch (Exception)
        //        {

        //            throw;
        //        }
        //        // var studente = _mapper.Map<SaveStudenteResource, Studente>(value);

        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }

        //}

        // put api/<areageograficacontroller>/5
        [HttpPut("name")]
        public async Task<IActionResult> put(string _name, [FromBody] SaveCityResource savecity)
        {

            City city = _context._City.Where(c => c.Name == _name).First();
            //country country = _context._country.where(x => x == ).first();


            City _city = savecity.ToCity();
            city.NAbitanti = _city.NAbitanti;


            var result = _context._City.Update(city).Entity;
            try
            {
                var res = await _context.SaveChangesAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // DELETE api/<AreaGeograficaController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            City c = await _context._City.FindAsync(id);
            _context._City.Remove(c);
            await _context.SaveChangesAsync();
        }
    }
}
