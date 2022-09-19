using SEDC.Lamazon.Models.Enums;

namespace SEDC.Lamazon.Models.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public CategoryType CategoryType { get; set; }
    }
}
