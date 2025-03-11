using DotNetFluentCore9.Contracts;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace DotNetFluentCore9.Controllers
{
    [ApiController]
    [Route("api/")]
    public class BaseController : ControllerBase
    {


        private readonly IValidator<BusinessRegistrationRequest> _businessValidator;
        private readonly IValidator<UserRegistrationRequest> _userValidator;
        private readonly IValidator<ProductCatalogRequest> _catalogValidator;
        private readonly IValidator<ShippingRequest> _shippingValidator;



        public BaseController(IValidator<BusinessRegistrationRequest> businessValidator, IValidator<UserRegistrationRequest> userValidator, IValidator<ProductCatalogRequest> catalogValidator, IValidator<ShippingRequest> shippingValidator)
        {
            _businessValidator = businessValidator;
            _userValidator = userValidator;
            _catalogValidator = catalogValidator;
            _shippingValidator = shippingValidator;
        }


        [HttpPost("annotation")]
        public ActionResult AnnotationRequest([FromBody] AnnotationUserRegistrationRequest request)
        {
            if (ModelState.IsValid)
            {
                return Ok(request);
            }


            return BadRequest(new
            {
                Title = "Validation Failed",
                Status = 400,
                Errors = ModelState.Where(m => m.Value.Errors.Count > 0)
                    .ToDictionary(
                        kvp => kvp.Key,
                        kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                    )
            });
        }


        [HttpPost("request")]
        public ActionResult Request([FromBody] UserRegistrationRequest request)
        {
            var validationResult = _userValidator.Validate(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(FormatValidationErrors(validationResult));
            }
            return Ok(request);
        }

        [HttpPost("products")]
        public ActionResult ProductCatalog([FromBody] ProductCatalogRequest request)
        {
            var validationResult = _catalogValidator.Validate(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(FormatValidationErrors(validationResult));
            }
            return Ok(request);
        }


        [HttpPost("shipping")]
        public ActionResult Shipping([FromBody] ShippingRequest request)
        {
            var validationResult = _shippingValidator.Validate(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(FormatValidationErrors(validationResult));
            }
            return Ok(request);
        }




        [HttpPost("business")]
        public ActionResult BusinessRegistration([FromBody] BusinessRegistrationRequest request)
        {
            var validationResult = _businessValidator.Validate(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(FormatValidationErrors(validationResult));
            }
            return Ok(request);
        }



        private object FormatValidationErrors(FluentValidation.Results.ValidationResult validationResult)
        {

            var detailedErrors = validationResult.Errors
                .Select(e => new
                {
                    Field = e.PropertyName,
                    Message = e.ErrorMessage,
                    Code = e.ErrorCode,
                    Severity = e.Severity.ToString()
                })
                .ToList();

            // For teaching purposes, return both formats to show the difference
            return new
            {
                Title = "Validation Failed",
                Status = 400,
                //SimpleErrors = simpleErrors,
                DetailedErrors = detailedErrors
            };
        }
    }
}
