using SEDC.Lamazon.Domain.Enitities;
using SEDC.Lamazon.ViewModels.Models;
using System.Collections.Generic;

namespace SEDC.Lamazon.Mappers
{
    public static class OrderLineItemMapper
    {
        public static OrderLineItemViewModel ToOrderLineItemViewModel(this OrderLineItem orderLineItem)
        {
            return new OrderLineItemViewModel
            {
                Id = orderLineItem.Id,
                DiscountPercentage = orderLineItem.DiscountPercentage,
                Product = orderLineItem.Product.ToProductViewModel(),
                ProductName = orderLineItem.ProductName,
                ProductPrice = orderLineItem.ProductPrice,
                Quantity = orderLineItem.Quantity,
                TotalPrice = orderLineItem.TotalPrice
            };
        }

        public static OrderLineItem ToOrderLineItem(this OrderLineItemViewModel orderLineItemViewModel)
        {
            return new OrderLineItem
            {
                Id = orderLineItemViewModel.Id,
                DiscountPercentage = orderLineItemViewModel.DiscountPercentage,
                Product = orderLineItemViewModel.Product.ToProduct(),
                ProductName = orderLineItemViewModel.ProductName,
                ProductPrice = orderLineItemViewModel.ProductPrice,
                Quantity = orderLineItemViewModel.Quantity,
                TotalPrice = orderLineItemViewModel.TotalPrice,
            };
        }


        public static List<OrderLineItemViewModel> ToOrderLineItemViewModelList(this List<OrderLineItem> orderLineItems)
        {
            List<OrderLineItemViewModel> viewModels = new List<OrderLineItemViewModel>();
            foreach (var orderLineItem in orderLineItems)
            {
                viewModels.Add(orderLineItem.ToOrderLineItemViewModel());
            }

            return viewModels;
        }

        public static List<OrderLineItem> ToOrderLineItemList(this List<OrderLineItemViewModel> orderLineItemViewModels)
        {
            List<OrderLineItem> models = new List<OrderLineItem>();
            foreach (var orderLineItemViewModel in orderLineItemViewModels)
            {
                models.Add(orderLineItemViewModel.ToOrderLineItem());
            }

            return models;
        }
    }
}
