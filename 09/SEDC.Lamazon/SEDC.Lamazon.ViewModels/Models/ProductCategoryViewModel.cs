using SEDC.Lamazon.ViewModels.Enums;

namespace SEDC.Lamazon.ViewModels.Models
{
    public class ProductCategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProductCategoryStatusEnum ProductCategoryStatus { get; set; }
    }
}
