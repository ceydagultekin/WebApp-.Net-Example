using AutoMapper;
using WebApp.Models;
using WebApp.Models.Dto;

namespace WebApp.Helper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<MovieDto, Movie>();
        }
    }
}
