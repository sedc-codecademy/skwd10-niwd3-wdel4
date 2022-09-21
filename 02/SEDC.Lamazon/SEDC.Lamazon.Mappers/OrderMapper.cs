using SEDC.Lamazon.Domain.Enitities;
using SEDC.Lamazon.ViewModels.Models;
using System.Collections.Generic;

namespace SEDC.Lamazon.Mappers
{
    public static class OrderMapper
    {
        public static OrderViewModel ToOrderViewModel(this Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                OrderLineItems = order.OrderLineItems.ToOrderLineItemViewModelList(),
                OrderNumber = order.OrderNumber,
                OrderStatus = (ViewModels.Enums.OrderStatus)order.OrderStatus,
                User = order.User.ToUserViewModel()
            };
        }

        public static Order ToOrder(this OrderViewModel orderViewModel)
        {
            return new Order
            {
                Id = orderViewModel.Id,
                OrderDate = orderViewModel.OrderDate,
                OrderLineItems = orderViewModel.OrderLineItems.ToOrderLineItemList(),
                OrderNumber = orderViewModel.OrderNumber,
                OrderStatus = (Domain.Enums.OrderStatus)orderViewModel.OrderStatus,
                User = orderViewModel.User.ToUser()
            };
        }


        public static List<OrderViewModel> ToOrderViewModelList(this List<Order> orders)
        {
            List<OrderViewModel> viewModels = new List<OrderViewModel>();
            foreach (var order in orders)
            {
                viewModels.Add(order.ToOrderViewModel());
            }

            return viewModels;
        }

        public static List<Order> ToOrderList(this List<OrderViewModel> orderViewModels)
        {
            List<Order> models = new List<Order>();
            foreach (var orderViewModel in orderViewModels)
            {
                models.Add(orderViewModel.ToOrder());
            }

            return models;
        }
    }
}
