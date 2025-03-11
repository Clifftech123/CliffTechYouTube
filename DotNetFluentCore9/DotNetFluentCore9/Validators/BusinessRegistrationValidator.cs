using DotNetFluentCore9.Contracts;
using FluentValidation;

namespace DotNetFluentCore9.Validators
{
    public class BusinessRegistrationValidator : AbstractValidator<BusinessRegistrationRequest>
    {
        public BusinessRegistrationValidator()
        {

            RuleFor(x => x.CompanyName).NotEmpty().WithMessage("Company name Required");

            RuleFor(x => x.TaxId)
                .NotEmpty()
                .Matches(@"^\d{2}-\d{7}$").When(x => x.BusinessType == "Corporation")
                .WithMessage("Corporations must provide a valid Tax ID in format XX-XXXXXXX");

            RuleFor(x => x.YearsInBusiness)
                .NotEmpty()
                .GreaterThanOrEqualTo(2).When(x => x.AnnualRevenue > 100000)
                .WithMessage("Businesses with revenue over $100,000 must be established for at least 2 years");

            RuleFor(x => x.HasBusinessLicense)
                .Equal(true).When(x => x.BusinessType != "Sole Proprietorship")
                .WithMessage("All business types except Sole Proprietorship must have a business license");



        }
    }
}
