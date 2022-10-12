using System.Collections.Generic;

namespace SEDC.Lamazon.Domain.Enitities
{
    public class ProductStatus
    {
        public ProductStatus()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
