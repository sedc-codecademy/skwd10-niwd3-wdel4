using SEDC.Lamazon.Domain.Enitities;
using SEDC.Lamazon.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.Lamazon.Mappers
{
    public static class InvoiceLineItemMapper
    {
        public static InvoiceLineItemViewModel ToInvoiceLineItemViewModel(this InvoiceLineItem invoiceLineItem)
        {
            return new InvoiceLineItemViewModel
            {
                Id = invoiceLineItem.Id,
                DiscountPercentage = invoiceLineItem.DiscountPercentage,
                Product = invoiceLineItem.Product.ToProductViewModel(),
                ProductName = invoiceLineItem.ProductName,
                ProductPrice = invoiceLineItem.ProductPrice,
                Quantity = invoiceLineItem.Quantity,
                TotalPrice = invoiceLineItem.TotalPrice,
                OrderLineItem = invoiceLineItem.OrderLineItem.ToOrderLineItemViewModel()
            };
        }

        public static InvoiceLineItem ToInvoiceLineItem(this InvoiceLineItemViewModel invoiceLineItemViewModel)
        {
            return new InvoiceLineItem
            {
                Id = invoiceLineItemViewModel.Id,
                DiscountPercentage = invoiceLineItemViewModel.DiscountPercentage,
                Product = invoiceLineItemViewModel.Product.ToProduct(),
                ProductName = invoiceLineItemViewModel.ProductName,
                ProductPrice = invoiceLineItemViewModel.ProductPrice,
                Quantity = invoiceLineItemViewModel.Quantity,
                TotalPrice = invoiceLineItemViewModel.TotalPrice,
                OrderLineItem = invoiceLineItemViewModel.OrderLineItem.ToOrderLineItem()
            };
        }


        public static List<InvoiceLineItemViewModel> ToInvoiceLineItemViewModelList(this List<InvoiceLineItem> invoiceLineItems)
        {
            List<InvoiceLineItemViewModel> viewModels = new List<InvoiceLineItemViewModel>();
            foreach (var invoiceLineItem in invoiceLineItems)
            {
                viewModels.Add(invoiceLineItem.ToInvoiceLineItemViewModel());
            }

            return viewModels;
        }

        public static List<InvoiceLineItem> ToInvoiceLineItemList(this List<InvoiceLineItemViewModel> invoiceLineItemViewModels)
        {
            List<InvoiceLineItem> models = new List<InvoiceLineItem>();
            foreach (var invoiceLineItemViewModel in invoiceLineItemViewModels)
            {
                models.Add(invoiceLineItemViewModel.ToInvoiceLineItem());
            }

            return models;
        }
    }
}
