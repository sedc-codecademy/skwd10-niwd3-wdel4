using SEDC.Lamazon.Domain.Enitities;
using SEDC.Lamazon.ViewModels.Models;
using System.Collections.Generic;

namespace SEDC.Lamazon.Mappers
{
    public static class InvoiceMapper
    {
        public static InvoiceViewModel ToInvoiceViewModel(this Invoice invoice)
        {
            return new InvoiceViewModel
            {
                Id = invoice.Id,
                InvoiceDate = invoice.InvoiceDate,
                InvoiceLineItems = invoice.InvoiceLineItems.ToInvoiceLineItemViewModelList(),
                InvoiceNumber = invoice.InvoiceNumber,
                InvoiceStatus = (ViewModels.Enums.InvoiceStatus)invoice.InvoiceStatus,
                User = invoice.User.ToUserViewModel()
            };
        }

        public static Invoice ToInvoice(this InvoiceViewModel invoiceViewModel)
        {
            return new Invoice
            {
                Id = invoiceViewModel.Id,
                InvoiceDate = invoiceViewModel.InvoiceDate,
                InvoiceLineItems = invoiceViewModel.InvoiceLineItems.ToInvoiceLineItemList(),
                InvoiceNumber = invoiceViewModel.InvoiceNumber,
                InvoiceStatus = (Domain.Enums.InvoiceStatus)invoiceViewModel.InvoiceStatus,
                User = invoiceViewModel.User.ToUser()
            };
        }


        public static List<InvoiceViewModel> ToInvoiceViewModelList(this List<Invoice> invoices)
        {
            List<InvoiceViewModel> viewModels = new List<InvoiceViewModel>();
            foreach (var invoice in invoices)
            {
                viewModels.Add(invoice.ToInvoiceViewModel());
            }

            return viewModels;
        }

        public static List<Invoice> ToInvoiceList(this List<InvoiceViewModel> invoiceViewModels)
        {
            List<Invoice> models = new List<Invoice>();
            foreach (var invoiceViewModel in invoiceViewModels)
            {
                models.Add(invoiceViewModel.ToInvoice());
            }

            return models;
        }
    }
}
