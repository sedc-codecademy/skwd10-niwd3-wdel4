namespace SEDC.Lamazon.Domain.Enitities
{
    public class InvoiceLineItem
    {
        public int Id { get; set; }
        public OrderLineItem OrderLineItem { get; set; }
        public Product Product { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
        public int DiscountPercentage { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
