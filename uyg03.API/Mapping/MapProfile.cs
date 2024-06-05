using AutoMapper;
using uyg03.API.Dtos;
using uyg03.API.Models;
using uyg03.Dtos;
using uyg03.Models;

namespace uyg03.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Education, EducationDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<AppUser, UserDto>().ReverseMap();
        }
    }
}
