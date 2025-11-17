using Api.W.Movies.Backend.DAL.Models;
using Api.W.Movies.Backend.DAL.Models.Dtos;
using AutoMapper;

namespace Api.W.Movies.Backend.MoviesMapper
{
    public class Mappers : Profile
    {
        public Mappers()
        {
            CreateMap<Category,CategoryDto>().ReverseMap();

            CreateMap<Category,CategoryCreateDto>().ReverseMap();
        }
    }
}