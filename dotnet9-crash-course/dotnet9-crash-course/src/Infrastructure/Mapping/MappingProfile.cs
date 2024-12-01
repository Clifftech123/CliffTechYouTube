using AutoMapper;
using dotnet9_crash_course.src.Domain.Entities;
using static dotnet9_crash_course.src.Domain.Contract.ProductsContracts;



namespace dotnet9_crash_course.src.Infrastructure.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductResponse>();
            CreateMap<CreateProductRequest, Product>();
            CreateMap<UpdateProductRequest, Product>();
        }
    }
}
