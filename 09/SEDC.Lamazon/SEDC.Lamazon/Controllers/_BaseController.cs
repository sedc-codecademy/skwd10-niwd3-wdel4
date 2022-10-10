using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using SEDC.Lamazon.Domain.Constants;
using SEDC.Lamazon.ViewModels.Models;

namespace SEDC.Lamazon.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            SetShoppingCartMetadata();
        }

        private void SetShoppingCartMetadata()
        {
            var shoppingCart = GetShoopingCart();

            ViewBag.ShoppingCartItemsCount = shoppingCart == null ? 0 : shoppingCart.ShoppingCartItems.Count;
        }

        protected ShoppingCartViewModel GetShoopingCart()
        {
            var shoppingCart = new ShoppingCartViewModel();

            if (Request.Cookies.ContainsKey(Cookies.ShoppingCart))
            {
                var cookieValue = Request.Cookies[Cookies.ShoppingCart];
                shoppingCart = JsonConvert.DeserializeObject<ShoppingCartViewModel>(cookieValue);
            }

            return shoppingCart;
        }
    }
}
