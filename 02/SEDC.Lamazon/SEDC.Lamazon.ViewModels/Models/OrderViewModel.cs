using SEDC.Lamazon.ViewModels.Enums;
using System;
using System.Collections.Generic;

namespace SEDC.Lamazon.ViewModels.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public UserViewModel User { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public List<OrderLineItemViewModel> OrderLineItems { get; set; }
    }
}
