using Microsoft.EntityFrameworkCore;
using SEDC.Lamazon.DataAccess.DataContext;
using SEDC.Lamazon.DataAccess.Extensions;
using SEDC.Lamazon.DataAccess.Interfaces;
using SEDC.Lamazon.Domain.Enitities;
using SEDC.Lamazon.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.Lamazon.DataAccess.Implementations
{
    public class OrdersRepository : BaseRepository, IOrdersRepository
    {
        public OrdersRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }

        public async Task<List<Order>> GetAllOrders()
        {
            return await _applicationDbContext.Orders.ToListAsync();
        }

        public async Task<Order> GetById(int id)
        {
            return await _applicationDbContext.Orders.Include(x => x.OrderLineItems).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PagedResultModel<Order>> GetFilteredOrders(int startIndex, int count, string searchValue, string orderByColumn, bool isAscending)
        {
            var result = new PagedResultModel<Order>();

            var ordersQuery = _applicationDbContext.Orders.Include(x => x.User).AsQueryable();
            result.TotalRecords = ordersQuery.Count();


            ordersQuery = ordersQuery.Where(x => x.OrderNumber.Contains(searchValue));
            result.TotalDisplayRecords = ordersQuery.Count();

            ordersQuery = isAscending ? ordersQuery.OrderByProperty(orderByColumn)
                                        : ordersQuery.OrderByPropertyDescending(orderByColumn);
            result.Items = await ordersQuery.ToListAsync();

            return result;
        }

        public async Task<int> GetMaxId()
        {
            if(await _applicationDbContext.Orders.AnyAsync())
            {
                return _applicationDbContext.Orders.Max(x => x.Id);
            }
            else
            {
                return 0;
            }
        }

        public async Task<int> Insert(Order order)
        {
            await _applicationDbContext.Orders.AddAsync(order);
            await _applicationDbContext.SaveChangesAsync();
            return order.Id;
        }

        public async Task Update(Order order)
        {
            if(await _applicationDbContext.Orders.AnyAsync(x => x.Id == order.Id))
            {
                _applicationDbContext.Update(order);
                await _applicationDbContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"Order with id {order.Id} was not found");
            }
        }
    }
}
