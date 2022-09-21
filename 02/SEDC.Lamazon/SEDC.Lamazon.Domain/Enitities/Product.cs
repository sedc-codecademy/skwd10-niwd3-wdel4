namespace SEDC.Lamazon.Domain.Enitities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public decimal Price { get; set; }
    }
}
