﻿using System.Collections.Generic;

namespace SEDC.Lamazon.Domain.Enitities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int ProductCategoryId { get; set; }
        public int ProductStatusId { get; set; }
        public decimal Price { get; set; }
        public bool IsFeatured { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
        public virtual ProductStatus ProductStatus { get; set; }

        public virtual ICollection<InvoiceLineItem> InvoiceLineItems { get; set; }
        public virtual ICollection<OrderLineItem> OrderLineItems { get; set; }
    }
}
