using SEDC.Lamazon.Domain.Enitities;
using SEDC.Lamazon.Domain.Models;
using SEDC.Lamazon.Services.AutoMapperPropertyResolvers;
using SEDC.Lamazon.ViewModels.Models;

namespace SEDC.Lamazon.Services.AutoMapperProfiles
{
    public class ProductCategoryMappingProfile : AutoMapper.Profile
    {
        public ProductCategoryMappingProfile()
        {
            CreateMap<ProductCategory, ProductCategoryViewModel>()
                .ForMember(x => x.Name, opt => opt.MapFrom<ProductCategoryNameResolver>())
                .ReverseMap();

            CreateMap<PagedResultModel<ProductCategory>, PagedResultViewModel<ProductCategoryViewModel>>();
        }
    }
}
