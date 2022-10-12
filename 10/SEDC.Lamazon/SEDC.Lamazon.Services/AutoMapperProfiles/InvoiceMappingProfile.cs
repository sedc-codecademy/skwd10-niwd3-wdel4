﻿using SEDC.Lamazon.Domain.Enitities;
using SEDC.Lamazon.Domain.Models;
using SEDC.Lamazon.ViewModels.Models;

namespace SEDC.Lamazon.Services.AutoMapperProfiles
{
    public class InvoiceMappingProfile : AutoMapper.Profile
    {
        public InvoiceMappingProfile()
        {
            CreateMap<Invoice, InvoiceViewModel>()
                .ForMember(x => x.InvoiceStatus, opt => opt.Ignore())
                .ForMember(x => x.InvoiceStatus, opt => opt.MapFrom(y => y.InvoiceStatusId))
                .ReverseMap()
                .ForMember(x => x.InvoiceStatus, opt => opt.Ignore())
                .ForMember(x => x.InvoiceStatusId, opt => opt.MapFrom(y => y.InvoiceStatus));

            CreateMap<InvoiceLineItem, InvoiceLineItemViewModel>().ReverseMap();

            CreateMap<PagedResultModel<Invoice>, PagedResultViewModel<InvoiceViewModel>>().ReverseMap();
        }
    }
}
