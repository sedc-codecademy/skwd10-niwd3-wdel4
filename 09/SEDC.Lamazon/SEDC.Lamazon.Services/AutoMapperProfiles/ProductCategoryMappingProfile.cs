using SEDC.Lamazon.Domain.Enitities;
using SEDC.Lamazon.Domain.Models;
using SEDC.Lamazon.ViewModels.Models;

namespace SEDC.Lamazon.Services.AutoMapperProfiles
{
    public class ProductCategoryMappingProfile : AutoMapper.Profile
    {
        public ProductCategoryMappingProfile()
        {
            CreateMap<ProductCategory, ProductCategoryViewModel>()
                .ForMember(x => x.ProductCategoryStatus, opt => opt.Ignore())
                .ForMember(x => x.ProductCategoryStatus, opt => opt.MapFrom(x => x.ProductCategoryStatusId))                
                .ReverseMap()
                .ForMember(x => x.ProductCategoryStatus, opt => opt.Ignore())
                .ForMember(x => x.ProductCategoryStatusId, opt => opt.MapFrom(x => x.ProductCategoryStatus));

            CreateMap<PagedResultModel<ProductCategory>, PagedResultViewModel<ProductCategoryViewModel>>();
        }
    }
}
