using AutoMapper;
using SEDC.Lamazon.DataAccess.Interfaces;
using SEDC.Lamazon.Domain.Enitities;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.ViewModels.Enums;
using SEDC.Lamazon.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SEDC.Lamazon.Services.Implementations
{
    public class OrdersService : BaseService, IOrdersService
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly IMapper _mapper;

        public OrdersService(IOrdersRepository ordersRepository, IMapper mapper)
        {
            _ordersRepository = ordersRepository;
            _mapper = mapper;
        }

        public async Task CreateOrder(OrderViewModel orderViewModel)
        {
            orderViewModel.OrderDate = DateTime.Today;
            orderViewModel.OrderStatus = OrderStatusEnum.Pending;
            var maxId = await _ordersRepository.GetMaxId();
            maxId++;
            orderViewModel.OrderNumber = $"{maxId}/{DateTime.Now.Year}";

            var order = _mapper.Map<Order>(orderViewModel);
            int orderId = await _ordersRepository.Insert(order);
            if (orderId <= 0)
            {
                throw new Exception($"Something went wrong while saving the new order");
            }
        }

        public async Task<List<OrderViewModel>> GetAllOrders()
        {
            var orders = await _ordersRepository.GetAllOrders();
            return _mapper.Map<List<OrderViewModel>>(orders);
        }

        public async Task<PagedResultViewModel<OrderViewModel>> GetFilteredOrders(DatatableRequestViewModel datatableRequestViewModel)
        {
            var searchValue = datatableRequestViewModel.search?.value ?? string.Empty;
            var ordersPagedResult = await _ordersRepository.GetFilteredOrders(datatableRequestViewModel.start, datatableRequestViewModel.length, searchValue, datatableRequestViewModel.sortColumn, datatableRequestViewModel.isAscending);
            return _mapper.Map<PagedResultViewModel<OrderViewModel>>(ordersPagedResult);
        }

        public async Task<OrderViewModel> GetOrderById(int id)
        {
            var order = await _ordersRepository.GetById(id);
            return _mapper.Map<OrderViewModel>(order);
        }

        public async Task UpdateOrder(OrderViewModel orderViewModel)
        {
            var order = _mapper.Map<Order>(orderViewModel);
            await _ordersRepository.Update(order);
        }
    }
}
