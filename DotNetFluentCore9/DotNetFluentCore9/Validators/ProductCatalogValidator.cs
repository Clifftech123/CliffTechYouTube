using DotNetFluentCore9.Contracts;
using FluentValidation;

namespace DotNetFluentCore9.Validators
{

    public class ProductItemValidator : AbstractValidator<ProductItem>
    {
        public ProductItemValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Price).GreaterThan(0);
            RuleFor(x => x.QuantityInStock).GreaterThanOrEqualTo(0);
        }


        public class ProductCatalogValidator : AbstractValidator<ProductCatalogRequest>
        {
            public ProductCatalogValidator()
            {
                RuleFor(x => x.StoreName).NotEmpty();

                RuleFor(x => x.Products).NotEmpty().WithMessage("At least one product must be added");

                RuleForEach(x => x.Products).SetValidator(new ProductItemValidator());

                // Complex collection rule
                RuleFor(x => x.Products)
                    .Must(products => products.Select(p => p.Name).Distinct().Count() == products.Count)
                    .WithMessage("Product names must be unique in the catalog");
            }
        }
    }
}
