﻿using System;
using System.Collections.Generic;

namespace SEDC.Lamazon.Domain.Enitities
{
    public class Order
    {
        public Order()
        {
            Invoices = new HashSet<Invoice>();            
            OrderLineItems = new HashSet<OrderLineItem>();
        }

        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public int UserId { get; set; }
        public int OrderStatusId { get; set; }
        public string IpAddress { get; set; }
        public string CountryCode { get; set; }
        public string CountryFlagUrl { get; set; }

        public virtual User User { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }

        public virtual ICollection<OrderLineItem> OrderLineItems { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }        
    }
}
