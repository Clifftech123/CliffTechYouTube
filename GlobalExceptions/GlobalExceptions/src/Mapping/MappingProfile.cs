using AutoMapper;
using GlobalExceptions.src.Contracts;
using GlobalExceptions.src.Modles;

namespace GlobalExceptions.src.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentDto>();
            CreateMap<CreateStudent, Student>();
            CreateMap<UpdateStudent, Student>();
        }
    }
}
