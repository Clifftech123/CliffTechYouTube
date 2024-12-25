using dotnetBlazorFullStuck.ApiService.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnetBlazorFullStuck.ApiService.Controllers
{
    [ApiController]
    [Route("api/")]
    public class CountryDataController : ControllerBase
    {
        private readonly ICountryDataServices _countryDataServices;

        public CountryDataController(ICountryDataServices countryDataServices)
        {
            _countryDataServices = countryDataServices;
        }



        [HttpGet("countrydata")]
        public async Task<IActionResult> GetCountryDataAsync([FromQuery] int offset = 1, [FromQuery] int limit = 20, [FromQuery] string? serchQuery = null)
        {
            var data = await _countryDataServices.GetCountryDataAsync(offset, limit, serchQuery);
            return Ok(data);
        }


        [HttpGet("country/{code}")]
        public async Task<IActionResult> GetCountryByCodeAsync(string code)
        {
            var data = await _countryDataServices.GetCountryByCodeAsync(code);
            return Ok(data);
        }



        [HttpGet("countryflag/{countrycode}")]
        public async Task<IActionResult> GetCountryFlagAsync(string countrycode)
        {
            var data = await _countryDataServices.GetCountryFlagAsync(countrycode);
            return Ok(data);
        }


        [HttpGet("regions/{code}")]

        public async Task<IActionResult> GetRegionsByCountryCodeAsync(string code)
        {
            var data = await _countryDataServices.GetRegionsByCountryCodeAsync(code);
            return Ok(data);
        }



        [HttpGet("currency/{code}")]
        public async Task<IActionResult> GetCurrencyAsync(string code)
        {
            var data = await _countryDataServices.GetCurrencyAsync(code);
            return Ok(data);
        }



    }
}
