using SEDC.Lamazon.Domain.Enitities;
using SEDC.Lamazon.ViewModels.Models;

namespace SEDC.Lamazon.Services.AutoMapperProfiles
{
    public class InvoiceMappingProfile : AutoMapper.Profile
    {
        public InvoiceMappingProfile()
        {
            CreateMap<Invoice, InvoiceViewModel>().ReverseMap();
        }
    }
}
