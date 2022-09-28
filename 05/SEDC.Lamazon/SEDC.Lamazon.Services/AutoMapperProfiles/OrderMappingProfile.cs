using SEDC.Lamazon.Domain.Enitities;
using SEDC.Lamazon.ViewModels.Models;

namespace SEDC.Lamazon.Services.AutoMapperProfiles
{
    public class OrderMappingProfile : AutoMapper.Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<Order, OrderViewModel>().ReverseMap();
        }
    }
}
