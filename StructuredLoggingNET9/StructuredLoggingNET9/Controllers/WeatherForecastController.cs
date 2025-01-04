using Microsoft.AspNetCore.Mvc;

namespace StructuredLoggingNET9.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            _logger.LogInformation("Getting weather forecast");
            var forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
           .ToArray();
            _logger.LogInformation("Generated weather forecasts: {Forecasts}", forecasts);

            _logger.LogWarning("This is a warning message");

            return forecasts;
        }

        [HttpGet("date/{date}")]
        public ActionResult<WeatherForecast> GetByDate(DateOnly date)
        {
            _logger.LogInformation("Entering GetByDate method with date: {Date}", date);

            var forecast = new WeatherForecast
            {
                Date = date,
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            };

            _logger.LogInformation("Generated weather forecast: {Forecast}", forecast);

            _logger.LogInformation("Exiting GetByDate method");

            return Ok(forecast);
        }

        [HttpPost("add")]
        public IActionResult AddForecast([FromBody] WeatherForecast forecast)
        {
            _logger.LogInformation("Entering AddForecast method with forecast: {Forecast}", forecast);

            // Here you would typically add the forecast to a database or in-memory collection
            // For this example, we'll just log the forecast and return it

            _logger.LogInformation("Added weather forecast: {Forecast}", forecast);

            _logger.LogInformation("Exiting AddForecast method");

            return CreatedAtAction(nameof(GetByDate), new { date = forecast.Date }, forecast);
        }
    }
}
