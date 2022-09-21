using AutoMapper;
using ECommerceServices.Catalog.Dtos;
using ECommerceServices.Catalog.Models;

namespace ECommerceServices.Catalog.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<Feature, FeatureDto>().ReverseMap();
        }
    }
}
