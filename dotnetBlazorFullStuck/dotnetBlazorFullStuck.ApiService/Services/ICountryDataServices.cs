using CountryData.Standard;

namespace dotnetBlazorFullStuck.ApiService.Services
{
    public interface ICountryDataServices
    {
        Task<string> GetCountryByCodeAsync(string code);
        Task<string> GetCountryByPhoneCodeAsync(string phoneCode);
        Task<string> GetCountryDataAsync(int offset = 1, int limit = 20, string? serchQuery = null);
        Task<string> GetCountryFlagAsync(string countrycode);
        Task<List<Regions>> GetRegionsByCountryCodeAsync(string code);

        Task<IEnumerable<Currency>> GetCurrencyAsync(string code);


    }
}
