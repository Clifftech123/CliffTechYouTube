namespace dotnetBlazorFullStuck.Web.Components.Client
{
    public class CountryClient
    {
        private readonly HttpClient _httpClient;

        public CountryClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<string> GetCountryDataAsync(int offset = 1, int limit = 20, string? serchQuery = null)
        {
            var response = await _httpClient.GetAsync($"api/countrydata?offset={offset}&limit={limit}&serchQuery={serchQuery}");
            return await response.Content.ReadAsStringAsync();
        }


        public async Task<string> GetCountryByCodeAsync(string code)
        {
            var response = await _httpClient.GetAsync($"api/country/{code}");
            return await response.Content.ReadAsStringAsync();
        }


        public async Task<string> GetCountryFlagAsync(string countrycode)
        {
            var response = await _httpClient.GetAsync($"api/countryflag/{countrycode}");
            return await response.Content.ReadAsStringAsync();
        }


        public async Task<string> GetRegionsByCountryCodeAsync(string code)
        {
            var response = await _httpClient.GetAsync($"api/regions/{code}");
            return await response.Content.ReadAsStringAsync();
        }



        public async Task<string> GetCurrencyAsync(string code)
        {
            var response = await _httpClient.GetAsync($"api/currency/{code}");
            return await response.Content.ReadAsStringAsync();
        }
    }
}
