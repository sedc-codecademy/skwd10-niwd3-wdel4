using SEDC.Lamazon.ViewModels.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SEDC.Lamazon.Services.Interfaces
{
    public interface IOrdersService
    {
        Task<List<OrderViewModel>> GetAllOrders();
        Task<OrderViewModel> GetOrderById(int id);
        Task CreateOrder(OrderViewModel orderViewModel);
        Task UpdateOrder(OrderViewModel orderViewModel);
        Task<PagedResultViewModel<OrderViewModel>> GetFilteredOrders(DatatableRequestViewModel datatableRequestViewModel);
    }
}
