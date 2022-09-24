using Microsoft.AspNetCore.Mvc;
using SEDC.Lamazon.Services.Interfaces;
using System.Linq;

namespace SEDC.Lamazon.Controllers
{
    public class ProductsController : Controller
    {
        private IProductsServices _productsServices;
        public ProductsController(IProductsServices productsServices)
        {
            _productsServices = productsServices;
        }

        public IActionResult Index()
        {
            var allProducts = _productsServices.GetAllProducts();
            return View(allProducts);
        }

        public IActionResult ProductDetails(int? id)
        {
            if(id.HasValue)
            {
                var product = _productsServices.GetProductById(id.Value);
                return View(product);
            }
            else
            {
                return new EmptyResult();
            }
        }
    }
}
