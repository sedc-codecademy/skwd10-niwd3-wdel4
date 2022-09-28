namespace SEDC.Lamazon.ViewModels.Models
{
    public class OrderLineItemViewModel
    {
        public int Id { get; set; }
        public ProductViewModel Product { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal ProductPrice { get; set; }
        public int DiscountPercentage { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
