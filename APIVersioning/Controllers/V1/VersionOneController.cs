using APIVersioning.Models.V1;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace APIVersioning.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]")]
    [Route("api/v{version:apiVersion}/products")]
    [ApiVersion("1.0")]
    public class ProductsController : ControllerBase
    {
        private static readonly List<Product> Products = new()
    {
        new Product { Id = 1, Name = "Laptop", Price = 999.99m },
        new Product { Id = 2, Name = "Mouse", Price = 29.99m }
    };

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {

            return Ok(new
            {

                Products,
                message = "This is version 1 of the API",

            });
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            return product == null
                ? NotFound()
                : Ok(new
                {
                    product.Id,
                    product.Name,
                    product.Price,
                    message = "This is version 1 of the API",

                });
        }

    }
}
