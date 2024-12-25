using CountryData.Standard;
using Newtonsoft.Json;

namespace dotnetBlazorFullStuck.ApiService.Services
{
    public class CountryDataServices : ICountryDataServices
    {
        private readonly CountryHelper _countryHelper;

        public CountryDataServices(CountryHelper countryHelper)
        {
            _countryHelper = countryHelper;
        }

        /// <summary>
        /// Get country data with pagination and search
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <param name="serchQuery"></param>
        /// <returns></returns>

        public Task<string> GetCountryDataAsync(int offset = 1, int limit = 20, string? serchQuery = null)
        {
            var countries = _countryHelper.GetCountryData();
            if (!string.IsNullOrEmpty(serchQuery))
            {

                serchQuery = serchQuery.ToLower();
                countries = countries.Where(x => x.CountryName.ToLower().Contains(serchQuery)).ToList();
            }
            var pagination = countries.Skip((offset - 1) * limit).Take(limit).ToList();

            if (!pagination.Any())
            {
                return Task.FromResult("No data found");
            }

            return Task.FromResult(JsonConvert.SerializeObject(pagination, Formatting.Indented));



        }


        /// <summary>
        /// Get country by code 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Task<string> GetCountryByCodeAsync(string code)
        {
            var country = _countryHelper.GetCountryByCode(code);
            if (country == null)
            {
                return Task.FromResult("No data found");
            }
            return Task.FromResult(JsonConvert.SerializeObject(country, Formatting.Indented));

        }

        /// <summary>
        /// Get country by phone code
        /// </summary>
        /// <param name="phoneCode"></param>
        /// <returns></returns>

        public Task<string> GetCountryByPhoneCodeAsync(string phoneCode)
        {
            var country = _countryHelper.GetCountryByPhoneCode(phoneCode);
            if (country == null)
            {
                return Task.FromResult("No data found");
            }
            return Task.FromResult(JsonConvert.SerializeObject(country, Formatting.Indented));
        }



        /// <summary>
        /// .Get country flag by country code
        /// </summary>
        /// <param name="countrycode"></param>
        /// <returns></returns>

        public Task<string> GetCountryFlagAsync(string countrycode)
        {
            var flag = _countryHelper.GetCountryEmojiFlag(countrycode);
            if (string.IsNullOrEmpty(flag))
            {
                return Task.FromResult("No data found");
            }
            return Task.FromResult(flag);
        }


        /// <summary>
        /// Get currency by country code
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Task<IEnumerable<Currency>> GetCurrencyAsync(string code)
        {
            var currency = _countryHelper.GetCurrencyCodesByCountryCode(code);
            return Task.FromResult(currency);
        }

        public Task<List<Regions>> GetRegionsByCountryCodeAsync(string code)
        {
            var regions = _countryHelper.GetRegionByCountryCode(code);
            return Task.FromResult(regions);
        }
    }
}
