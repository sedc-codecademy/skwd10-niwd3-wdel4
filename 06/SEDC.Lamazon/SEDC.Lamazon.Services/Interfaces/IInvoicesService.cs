using SEDC.Lamazon.ViewModels.Models;
using System.Collections.Generic;

namespace SEDC.Lamazon.Services.Interfaces
{
    public interface IInvoicesService
    {
        List<InvoiceViewModel> GetAllInvoices();
        InvoiceViewModel GetInvoiceById(int id);
        void CreateInvoice(InvoiceViewModel invoiceViewModel);
        void UpdateInvoice(InvoiceViewModel invoiceViewModel);
        void DeleteInvoiceById(int id);
    }
}
