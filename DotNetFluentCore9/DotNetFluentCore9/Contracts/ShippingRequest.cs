namespace DotNetFluentCore9.Contracts
{
    public class ShippingRequest
    {
        public string? RecipientName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public decimal PackageWeight { get; set; }

    }
}
