using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication3.Models
{
    public partial class InvoiceLineItem
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public int OrderLineItemId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
        public int DiscountPercentage { get; set; }
        public decimal TotalPrice { get; set; }

        public virtual Invoice Invoice { get; set; }
        public virtual OrderLineItem OrderLineItem { get; set; }
        public virtual Product Product { get; set; }
    }
}
