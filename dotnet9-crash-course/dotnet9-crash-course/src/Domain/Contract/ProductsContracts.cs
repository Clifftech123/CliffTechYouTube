namespace dotnet9_crash_course.src.Domain.Contract
{
    public class ProductsContracts
    {
        /// <summary>
        /// Request to create a new product.
        /// </summary>
        /// <param name="Name">The name of the product.</param>
        /// <param name="Price">The price of the product.</param>
        /// <param name="Description">The description of the product.</param>
        public record CreateProductRequest(string Name, decimal Price, string Description);

        /// <summary>
        /// Request to update an existing product.
        /// </summary>
        /// <param name="Name">The name of the product.</param>
        /// <param name="Price">The price of the product.</param>
        /// <param name="Description">The description of the product.</param>
        public record UpdateProductRequest(string Name, decimal Price, string Description);

        /// <summary>
        /// Response containing product details.
        /// </summary>
        /// <param name="Id">The unique identifier of the product.</param>
        /// <param name="Name">The name of the product.</param>
        /// <param name="Price">The price of the product.</param>
        /// <param name="Description">The description of the product.</param>
        /// <param name="CreatedAt">The date and time when the product was created.</param>
        /// <param name="UpdatedAt">The date and time when the product was last updated.</param>
        public record ProductResponse(Guid Id, string Name, decimal Price, string Description, DateTime CreatedAt, DateTime UpdatedAt);
    }

    public class ApiResponse<T>
    {
        /// <summary>
        /// The data of the response.
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Indicates whether the request was successful.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// The message associated with the response.
        /// </summary>
        public string Message { get; set; }
    }
}
