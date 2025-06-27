using AutoMapper;
using Domain.Entities.ProductModule;
using Shared.Dtos;

namespace Service.Profiles
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(d => d.TypeName, option => option.MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.BrandName, option => option.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.PictureUrl, option => option.MapFrom<PictureUrlResolver>());

            CreateMap<ProductType, ProductTypesDto>();

            CreateMap<ProductBrand, ProductBrandsDto>();
        }
    }
}
