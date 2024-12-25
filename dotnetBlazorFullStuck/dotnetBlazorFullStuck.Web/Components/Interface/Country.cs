namespace dotnetBlazorFullStuck.Web.Components.Interface
{
    public class Country
    {
        public string CountryName { get; set; }
        public string CountryFlag { get; set; }
        public string PhoneCode { get; set; }
        public string CountryShortCode { get; set; }
    }

    public class Regions
    {
        public string name { get; set; }
        public string shortCode { get; set; }
    }


    public class Currency
    {
        public string name { get; set; }
        public string code { get; set; }

    }
}
