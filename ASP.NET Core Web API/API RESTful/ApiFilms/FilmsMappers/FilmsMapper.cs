using ApiFilms.Models;
using ApiFilms.Models.Dtos;
using AutoMapper;

namespace ApiFilms.FilmsMapper
{
    public class FilmsMapper : Profile
    {
        public FilmsMapper()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
        }
    }
}
