namespace DotNetFluentCore9.Contracts
{
    public class BusinessRegistrationRequest
    {

        public required string CompanyName { get; set; }
        public string? TaxId { get; set; }
        public string? BusinessType { get; set; }
        public int? YearsInBusiness { get; set; }
        public decimal? AnnualRevenue { get; set; }
        public bool HasBusinessLicense { get; set; }

    }
}
