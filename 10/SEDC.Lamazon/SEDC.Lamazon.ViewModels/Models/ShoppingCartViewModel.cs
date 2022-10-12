using System.Collections.Generic;

namespace SEDC.Lamazon.ViewModels.Models
{
    public class ShoppingCartViewModel
    {
        public ShoppingCartViewModel()
        {
            ShoppingCartItems = new List<ShoppingCartItemViewModel>();
        }

        public List<ShoppingCartItemViewModel> ShoppingCartItems { get; set; }
    }
}
