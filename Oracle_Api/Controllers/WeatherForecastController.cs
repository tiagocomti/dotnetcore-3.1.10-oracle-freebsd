using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Oracle.ManagedDataAccess.Client;

namespace Oracle_Api.Controllers
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
        public Countries paises;
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public Countries Get()
        {

            using (OracleConnection connection = new OracleConnection("User Id=hr;Password=oracle;Data Source=//192.168.0.24:1521/orcl"))
            {
                using (OracleCommand cmd = connection.CreateCommand())
                {
                    try
                    {
                        connection.Open();
                        cmd.BindByName = true;
                        cmd.CommandText = "select * from countries";
                        OracleDataReader reader = cmd.ExecuteReader();

                        while (reader.Read()) {
                            this.paises = new Countries();
                            this.paises.Country_name = reader.GetString(1);
                            this.paises.Country_ID = reader.GetString(0);
                            this.paises.Region_id = Convert.ToInt32(reader.GetString(2));
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                connection.Close();
            }
            return this.paises;
            /**
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
            */
        }
    }
}
