using SEDC.Lamazon.DataAccess;
using SEDC.Lamazon.Domain.Enitities;
using SEDC.Lamazon.Mappers;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.ViewModels.Models;
using System;
using System.Collections.Generic;

namespace SEDC.Lamazon.Services.Implementations
{
    public class OrdersService : IOrdersService
    {
        private readonly IRepository<Order> _ordersRepository;
        public OrdersService(IRepository<Order> ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public void CreateOrder(OrderViewModel orderViewModel)
        {
            var order = orderViewModel.ToOrder();
            int orderId = _ordersRepository.Insert(order);
            if (orderId <= 0)
            {
                throw new Exception($"Something went wrong while saving the new order");
            }
        }

        public void DeleteOrderById(int id)
        {
            _ordersRepository.DeleteById(id);
        }

        public List<OrderViewModel> GetAllOrders()
        {
            var orders = _ordersRepository.GetAll();
            return orders.ToOrderViewModelList();
        }

        public OrderViewModel GetOrderById(int id)
        {
            var order = _ordersRepository.GetById(id);
            return order.ToOrderViewModel();
        }

        public void UpdateOrder(OrderViewModel orderViewModel)
        {
            var order = orderViewModel.ToOrder();
            _ordersRepository.Update(order);
        }
    }
}
