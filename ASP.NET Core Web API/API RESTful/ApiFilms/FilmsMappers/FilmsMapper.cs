﻿using ApiFilms.Models;
using ApiFilms.Models.Dtos;
using AutoMapper;

namespace ApiFilms.FilmsMapper
{
    public class FilmsMapper : Profile
    {
        public FilmsMapper()
        {
            /* We link a class with its Dto in both directions when we are getting the data*/
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Film, FilmDto>().ReverseMap();
        }
    }
}
