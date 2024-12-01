using FluentValidation;
using static dotnet9_crash_course.src.Domain.Contract.ProductsContracts;

namespace dotnet9_crash_course.src.Domain.Validators
{
    public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
        }
    }
}
