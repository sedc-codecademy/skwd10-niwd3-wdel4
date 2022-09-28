using SEDC.Lamazon.Domain.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.Lamazon.DataAccess.Implementations
{
    public class OrdersRepository : IRepository<Order>
    {
        public void DeleteById(int id)
        {
            var order = StaticDb.Orders.FirstOrDefault(x => x.Id == id);
            if (order == null)
            {
                throw new Exception($"Order with id {id} was not found");
            }

            int index = StaticDb.Orders.IndexOf(order);
            StaticDb.Orders.RemoveAt(index);
        }

        public List<Order> GetAll()
        {
            return StaticDb.Orders;
        }

        public Order GetById(int id)
        {
            return StaticDb.Orders.FirstOrDefault(x => x.Id == id);
        }

        public int Insert(Order order)
        {
            order.Id = StaticDb.OrderId;
            StaticDb.Orders.Add(order);
            StaticDb.OrderId++;
            return order.Id;
        }

        public void Update(Order order)
        {
            var entity = StaticDb.Orders.FirstOrDefault(x => x.Id == order.Id);
            if (entity == null)
            {
                throw new Exception($"Order with id {order.Id} was not found");
            }

            int index = StaticDb.Orders.IndexOf(entity);
            StaticDb.Orders[index] = order;
        }
    }
}
