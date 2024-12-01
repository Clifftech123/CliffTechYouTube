using AutoMapper;
using dotnet9_crash_course.src.Domain.Contract;
using dotnet9_crash_course.src.Domain.Entities;
using dotnet9_crash_course.src.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using static dotnet9_crash_course.src.Domain.Contract.ProductsContracts;

namespace dotnet9_crash_course.src.Service
{
    /// <summary>
    /// Service class for managing products.
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly ProductDbContext _context;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductService"/> class.
        /// </summary>
        /// <param name="context">The database context for products.</param>
        /// <param name="mapper">The AutoMapper instance.</param>
        public ProductService(ProductDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates a new product.
        /// </summary>
        /// <param name="request">The request containing product details.</param>
        /// <returns>An <see cref="ApiResponse{T}"/> containing the created product.</returns>
        public async Task<ApiResponse<ProductResponse>> CreateProduct(CreateProductRequest request)
        {
            var product = _mapper.Map<Product>(request);
            product.CreatedAt = DateTime.Now;
            product.UpdatedAt = DateTime.Now;

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return new ApiResponse<ProductResponse>
            {
                Data = _mapper.Map<ProductResponse>(product),
                Success = true,
                Message = "Product created successfully"
            };
        }

        /// <summary>
        /// Retrieves all products.
        /// </summary>
        /// <returns>An <see cref="ApiResponse{T}"/> containing a list of products.</returns>
        public async Task<ApiResponse<IEnumerable<ProductResponse>>> GetProducts()
        {
            var prouducts = await _context.Products.ToListAsync();
            if (prouducts == null || prouducts.Count == 0)
            {
                return new ApiResponse<IEnumerable<ProductResponse>>
                {
                    Data = new List<ProductResponse>(),
                    Success = true,
                    Message = "No product found"
                };
            }
            return new ApiResponse<IEnumerable<ProductResponse>>
            {
                Data = _mapper.Map<IEnumerable<ProductResponse>>(prouducts),
                Success = true,
                Message = "Products fetched successfully"
            };
        }

        /// <summary>
        /// Retrieves a product by its identifier.
        /// </summary>
        /// <param name="id">The product identifier.</param>
        /// <returns>An <see cref="ApiResponse{T}"/> containing the product.</returns>
        public async Task<ApiResponse<ProductResponse>> GetProduct(Guid id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
                return new ApiResponse<ProductResponse>
                {
                    Data = null,
                    Success = false,
                    Message = "Product not found"
                };
            }
            return new ApiResponse<ProductResponse>
            {
                Data = _mapper.Map<ProductResponse>(product),
                Success = true,
                Message = "Product fetched successfully"
            };
        }

        /// <summary>
        /// Updates an existing product.
        /// </summary>
        /// <param name="id">The product identifier.</param>
        /// <param name="request">The request containing updated product details.</param>
        /// <returns>An <see cref="ApiResponse{T}"/> containing the updated product.</returns>
        public async Task<ApiResponse<ProductResponse>> UpdateProduct(Guid id, UpdateProductRequest request)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
                return new ApiResponse<ProductResponse>
                {
                    Data = null,
                    Success = false,
                    Message = "Product not found"
                };
            }
            if (!string.IsNullOrEmpty(request.Name))
            {
                product.Name = request.Name;
            }

            if (!string.IsNullOrEmpty(request.Description))
            {
                product.Description = request.Description;
            }

            if (request.Price != default)
            {
                product.Price = request.Price;
            }

            product.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return new ApiResponse<ProductResponse>
            {
                Data = _mapper.Map<ProductResponse>(product),
                Success = true,
                Message = "Product updated successfully"
            };
        }

        /// <summary>
        /// Deletes a product by its identifier.
        /// </summary>
        /// <param name="id">The product identifier.</param>
        /// <returns>An <see cref="ApiResponse{T}"/> indicating whether the deletion was successful.</returns>
        public async Task<ApiResponse<bool>> DeleteProduct(Guid id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
                return new ApiResponse<bool>
                {
                    Data = false,
                    Success = false,
                    Message = "Product not found"
                };
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return new ApiResponse<bool>
            {
                Data = true,
                Success = true,
                Message = "Product deleted successfully"
            };
        }
    }
}
