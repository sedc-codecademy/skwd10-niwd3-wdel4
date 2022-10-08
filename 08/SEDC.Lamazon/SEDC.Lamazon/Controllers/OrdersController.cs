using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.ViewModels.Models;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.Lamazon.Controllers
{
    [Authorize]
    public class OrdersController : BaseController
    {
        private readonly IProductsService _productsService;
        public OrdersController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        public IActionResult ShoppingCart()
        {
            var shoppingCart = GetShoopingCart();

            if(shoppingCart.ShoppingCartItems.Any())
            {
                var orderLineItems = new List<OrderLineItemViewModel>();

                foreach(var shoppingCartItem in shoppingCart.ShoppingCartItems)
                {
                    var product = _productsService.GetProductById(shoppingCartItem.Id);

                    var orderLineItem = new OrderLineItemViewModel();
                    orderLineItem.ProductId = product.Id;
                    orderLineItem.ProductName = product.Name;
                    orderLineItem.ProductPrice = product.Price;
                    orderLineItem.ProductDescription = product.Description;
                    orderLineItem.ProductImage = product.ImageUrl;
                    orderLineItem.Quantity = 1;

                    orderLineItems.Add(orderLineItem);
                }

                return View(orderLineItems);
            }
            else
            {
                return RedirectToAction("Index", "Products");
            }
        }
    }
}
