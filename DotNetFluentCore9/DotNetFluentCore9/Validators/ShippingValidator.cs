using DotNetFluentCore9.Contracts;
using FluentValidation;
using System.Text.RegularExpressions;

namespace DotNetFluentCore9.Validators
{

    public class ShippingValidator : AbstractValidator<ShippingRequest>
    {
        private readonly IReadOnlyList<string> _supportedCountries = new[] { "USA", "Canada", "Mexico" };

        public ShippingValidator()
        {
            RuleFor(x => x.RecipientName).NotEmpty();
            RuleFor(x => x.Address).NotEmpty();
            RuleFor(x => x.City).NotEmpty();

            RuleFor(x => x.PostalCode)
                .NotEmpty()
                .Must((request, postalCode) => IsValidPostalCodeForCountry(postalCode, request.Country))
                .WithMessage(request => $"The postal code format is invalid for {request.Country}");

            RuleFor(x => x.Country)
                .NotEmpty()
                .Must(country => _supportedCountries.Contains(country))
                .WithMessage(request => $"We only ship to: {string.Join(", ", _supportedCountries)}. You selected: {request.Country}");

            RuleFor(x => x.PackageWeight)
                .GreaterThan(0)
                .LessThanOrEqualTo(70).When(x => x.Country == "USA")
                .LessThanOrEqualTo(30).When(x => x.Country == "Canada" || x.Country == "Mexico")
                .WithMessage(request => $"Maximum package weight for {request.Country} is {(request.Country == "USA" ? 70 : 30)}kg");
        }

        private bool IsValidPostalCodeForCountry(string postalCode, string country)
        {
            return country switch
            {
                "USA" => Regex.IsMatch(postalCode, @"^\d{5}(-\d{4})?$"),
                "Canada" => Regex.IsMatch(postalCode, @"^[A-Z]\d[A-Z] \d[A-Z]\d$"),
                "Mexico" => Regex.IsMatch(postalCode, @"^\d{5}$"),
                _ => true
            };
        }
    }

}
