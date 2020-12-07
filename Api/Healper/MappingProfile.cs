using Api.Dtos;
using AutoMapper;
using Core.Entity;

namespace Api.Healper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductsToDisplayDto>()
            .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
            .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
            .ForMember(d => d.ProductUrl, o => o.MapFrom<ProducturlResolver>());
        }
    }
}