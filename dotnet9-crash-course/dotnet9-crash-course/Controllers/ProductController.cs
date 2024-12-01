using dotnet9_crash_course.src.Service;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using static dotnet9_crash_course.src.Domain.Contract.ProductsContracts;

namespace dotnet9_crash_course.Controllers
{
    /// <summary>
    /// Controller for managing products.
    /// </summary>
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IValidator<CreateProductRequest> _createProductRequestValidator;
        private readonly IValidator<UpdateProductRequest> _updateProductRequestValidator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductController"/> class.
        /// </summary>
        /// <param name="productService">The product service.</param>
        /// <param name="createProductRequestValidator">The validator for create product requests.</param>
        /// <param name="updateProductRequestValidator">The validator for update product requests.</param>
        public ProductController(IProductService productService, IValidator<CreateProductRequest> createProductRequestValidator, IValidator<UpdateProductRequest> updateProductRequestValidator)
        {
            _productService = productService;
            _createProductRequestValidator = createProductRequestValidator;
            _updateProductRequestValidator = updateProductRequestValidator;
        }

        /// <summary>
        /// Creates a new product.
        /// </summary>
        /// <param name="request">The request containing product details.</param>
        /// <returns>An <see cref="IActionResult"/> containing the created product.</returns>
        [HttpPost("api/product")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request)
        {
            var validationResult = await _createProductRequestValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var response = await _productService.CreateProduct(request);
            return Ok(response);
        }

        /// <summary>
        /// Retrieves all products.
        /// </summary>
        /// <returns>An <see cref="IActionResult"/> containing a list of products.</returns>
        [HttpGet("api/products")]
        public async Task<IActionResult> GetProducts()
        {
            var response = await _productService.GetProducts();
            return Ok(response);
        }

        /// <summary>
        /// Retrieves a product by its identifier.
        /// </summary>
        /// <param name="id">The product identifier.</param>
        /// <returns>An <see cref="IActionResult"/> containing the product.</returns>
        [HttpGet("api/product/{id}")]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            var response = await _productService.GetProduct(id);
            return Ok(response);
        }

        /// <summary>
        /// Updates an existing product.
        /// </summary>
        /// <param name="id">The product identifier.</param>
        /// <param name="request">The request containing updated product details.</param>
        /// <returns>An <see cref="IActionResult"/> containing the updated product.</returns>
        [HttpPut("api/product/{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] UpdateProductRequest request)
        {
            var validationResult = await _updateProductRequestValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var response = await _productService.UpdateProduct(id, request);
            return Ok(response);
        }

        /// <summary>
        /// Deletes a product by its identifier.
        /// </summary>
        /// <param name="id">The product identifier.</param>
        /// <returns>An <see cref="IActionResult"/> indicating whether the deletion was successful.</returns>
        [HttpDelete("api/product/{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var response = await _productService.DeleteProduct(id);
            return Ok(response);
        }
    }
}
