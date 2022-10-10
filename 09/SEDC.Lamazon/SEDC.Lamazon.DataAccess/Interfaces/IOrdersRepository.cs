using SEDC.Lamazon.Domain.Enitities;
using SEDC.Lamazon.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SEDC.Lamazon.DataAccess.Interfaces
{
    public interface IOrdersRepository
    {
        Task<List<Order>> GetAllOrders();
        Task<Order> GetById(int id);
        Task<int> Insert(Order order);
        Task Update(Order order);
        Task<int> GetMaxId();
        Task<PagedResultModel<Order>> GetFilteredOrders(int startIndex, int count, string searchValue, string orderByColumn, bool isAscending);
    }
}
