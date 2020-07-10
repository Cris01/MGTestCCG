using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MGtestCCG.Application.Query;
using MGtestCCG.Domain.Entities;
using MGtestCCG.Domain.Irepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MGtestCCG.Web.Controllers
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
        private readonly IEmployeeRepository employeeRepository;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IEmployeeRepository employeeRepository)
        {
            _logger = logger;
            this.employeeRepository = employeeRepository;
        }

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        [HttpGet]
        public async Task<IEnumerable<Employee>> Get()
        {
            return await this.employeeRepository.GetAllAsync().ConfigureAwait(false);
        }

    }
}
