using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace SEDC.Lamazon.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            var allProducts = StaticDb.Products;
            return View(allProducts);
        }

        public IActionResult ProductDetails(int? id)
        {
            var product = StaticDb.Products.FirstOrDefault(x => x.Id == id);
            if(product == null)
            {
                return new EmptyResult();
            }
            else
            {
                return View(product);
            }
        }
    }
}
