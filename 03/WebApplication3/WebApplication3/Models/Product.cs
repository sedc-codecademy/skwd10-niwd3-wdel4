using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication3.Models
{
    public partial class Product
    {
        public Product()
        {
            InvoiceLineItems = new HashSet<InvoiceLineItem>();
            OrderLineItems = new HashSet<OrderLineItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int ProductCategoryId { get; set; }
        public decimal Price { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
        public virtual ICollection<InvoiceLineItem> InvoiceLineItems { get; set; }
        public virtual ICollection<OrderLineItem> OrderLineItems { get; set; }
    }
}
