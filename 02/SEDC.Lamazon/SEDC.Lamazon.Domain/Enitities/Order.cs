using SEDC.Lamazon.Domain.Enums;
using System;
using System.Collections.Generic;

namespace SEDC.Lamazon.Domain.Enitities
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public User User { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public List<OrderLineItem> OrderLineItems { get; set; }
    }
}
