using SEDC.Lamazon.Domain.Enitities;
using SEDC.Lamazon.Domain.Models;
using SEDC.Lamazon.ViewModels.Models;

namespace SEDC.Lamazon.Services.AutoMapperProfiles
{
    public class OrderMappingProfile : AutoMapper.Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<Order, OrderViewModel>()
                .ForMember(x => x.OrderStatus, opt => opt.Ignore())
                .ForMember(x => x.OrderStatus, opt => opt.MapFrom(y => y.OrderStatusId))
                .ReverseMap()
                .ForMember(x => x.OrderStatus, opt => opt.Ignore())
                .ForMember(x => x.OrderStatusId, opt => opt.MapFrom(y => y.OrderStatus));

            CreateMap<PagedResultModel<Order>, PagedResultViewModel<OrderViewModel>>();

            CreateMap<OrderLineItem, OrderLineItemViewModel>()
                .ReverseMap()
                .ForMember(x => x.Product, opt => opt.Ignore());
        }
    }
}
