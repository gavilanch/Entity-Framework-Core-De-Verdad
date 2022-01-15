using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaBDPrimero.Entidades;

namespace PruebaBDPrimero.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly EFCorePeliculasDBContext context;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            EFCorePeliculasDBContext context)
        {
            _logger = logger;
            this.context = context;
        }

        [HttpGet("generos")]
        public async Task<IEnumerable<Genero>> GetGenero()
        {
            return await context.Generos.ToListAsync();
        }


        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}