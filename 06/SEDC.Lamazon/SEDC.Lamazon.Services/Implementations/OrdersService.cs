using AutoMapper;
using SEDC.Lamazon.DataAccess;
using SEDC.Lamazon.Domain.Enitities;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.ViewModels.Models;
using System;
using System.Collections.Generic;

namespace SEDC.Lamazon.Services.Implementations
{
    public class OrdersService : IOrdersService
    {
        private readonly IRepository<Order> _ordersRepository;
        private readonly IMapper _mapper;

        public OrdersService(IRepository<Order> ordersRepository, IMapper mapper)
        {
            _ordersRepository = ordersRepository;
            _mapper = mapper;
        }

        public void CreateOrder(OrderViewModel orderViewModel)
        {
            var order = _mapper.Map<Order>(orderViewModel);
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
            return _mapper.Map<List<OrderViewModel>>(orders);
        }

        public OrderViewModel GetOrderById(int id)
        {
            var order = _ordersRepository.GetById(id);
            return _mapper.Map<OrderViewModel>(order);
        }

        public void UpdateOrder(OrderViewModel orderViewModel)
        {
            var order = _mapper.Map<Order>(orderViewModel);
            _ordersRepository.Update(order);
        }
    }
}
