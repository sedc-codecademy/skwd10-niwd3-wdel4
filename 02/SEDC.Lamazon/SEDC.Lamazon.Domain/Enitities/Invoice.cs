using SEDC.Lamazon.Domain.Enums;
using System;
using System.Collections.Generic;

namespace SEDC.Lamazon.Domain.Enitities
{
    public class Invoice
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public User User { get; set; }
        public Order Order { get; set; }
        public InvoiceStatus InvoiceStatus { get; set; }

        public List<InvoiceLineItem> InvoiceLineItems { get; set; }
    }
}
