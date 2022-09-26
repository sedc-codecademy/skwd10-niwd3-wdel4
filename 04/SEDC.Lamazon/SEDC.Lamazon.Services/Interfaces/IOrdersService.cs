using SEDC.Lamazon.ViewModels.Models;
using System.Collections.Generic;

namespace SEDC.Lamazon.Services.Interfaces
{
    public interface IOrdersService
    {
        List<OrderViewModel> GetAllOrders();
        OrderViewModel GetOrderById(int id);
        void CreateOrder(OrderViewModel orderViewModel);
        void UpdateOrder(OrderViewModel orderViewModel);
        void DeleteOrderById(int id);
    }
}
