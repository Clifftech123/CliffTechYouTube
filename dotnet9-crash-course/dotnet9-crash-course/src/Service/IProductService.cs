using dotnet9_crash_course.src.Domain.Contract;
using static dotnet9_crash_course.src.Domain.Contract.ProductsContracts;

namespace dotnet9_crash_course.src.Service
{
    public interface IProductService
    {
        Task<ApiResponse<ProductResponse>> GetProduct(Guid id);
        Task<ApiResponse<IEnumerable<ProductResponse>>> GetProducts();
        Task<ApiResponse<ProductResponse>> CreateProduct(CreateProductRequest request);
        Task<ApiResponse<ProductResponse>> UpdateProduct(Guid id, UpdateProductRequest request);
        Task<ApiResponse<bool>> DeleteProduct(Guid id);
    }
}
