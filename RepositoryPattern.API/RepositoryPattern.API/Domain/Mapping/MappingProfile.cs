using AutoMapper;
using RepositoryPattern.API.Domain.Contracts;
using RepositoryPattern.API.Domain.Entities;

namespace RepositoryPattern.API.Domain.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Author, GetAuthorDto>()
             .ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.Books));
            CreateMap<CreateAuthor, Author>();
            CreateMap<UpdateAuthor, Author>();
            CreateMap<DeleteAuthor, Author>();
            CreateMap<GetAuthor, Author>();


            // Mapping for Book

            CreateMap<Book, GetBookDto>();
            CreateMap<CreateBook, Book>();
            CreateMap<UpdateBook, Book>();
            CreateMap<DeleteBook, Book>();
            CreateMap<GetBook, Book>();

        }
    }
}
