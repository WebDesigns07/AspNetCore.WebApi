using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Authentication;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AuthorizeToken]
    public class WeathersController : ControllerBase
    {
        private readonly ApiDbContext _context;

        private readonly IAuthenticationService _authService;

        public WeathersController(ApiDbContext context, IAuthenticationService authService)
        {
            _context = context;
            _authService = authService;
        }

        // GET: api/Weathers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Weather>>> GetWeather()
        {
            // Seed
            //if (_context.Weather.Count() <= 0)
            //{
            //    string[] Summaries = new[]
            //    {
            //            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            //    };
            //    var rng = new Random();
            //    var weathers = Enumerable.Range(1, 5).Select(index => new Weather
            //    {
            //        Id = index,
            //        Date = DateTime.Now.AddDays(index),
            //        TemperatureC = rng.Next(-20, 55),
            //        Summary = Summaries[rng.Next(Summaries.Length)]
            //    }).ToArray();
            //    await _context.Weather.AddRangeAsync(weathers);
            //    await _context.SaveChangesAsync();
            //}
            return await _context.Weather.ToListAsync();
        }

        // GET: api/Weathers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Weather>> GetWeather(int id)
        {
            var weather = await _context.Weather.FindAsync(id);

            if (weather == null)
            {
                return NotFound();
            }

            return weather;
        }

        // PUT: api/Weathers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeather(int id, Weather weather)
        {
            if (id != weather.Id)
            {
                return BadRequest();
            }

            _context.Entry(weather).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeatherExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Weathers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Weather>> PostWeather(Weather weather)
        {
            _context.Weather.Add(weather);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWeather", new { id = weather.Id }, weather);
        }

        // DELETE: api/Weathers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Weather>> DeleteWeather(int id)
        {
            var weather = await _context.Weather.FindAsync(id);
            if (weather == null)
            {
                return NotFound();
            }

            _context.Weather.Remove(weather);
            await _context.SaveChangesAsync();

            return weather;
        }

        private bool WeatherExists(int id)
        {
            return _context.Weather.Any(e => e.Id == id);
        }
    }
}
