using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.ViewModels.Constants;
using SEDC.Lamazon.ViewModels.Models;

namespace SEDC.Lamazon.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = Roles.Admin)]
    public class ProductsController : Controller
    {
        private IProductsService _productsService;
        private IProductCategoriesService _productCategoriesService;

        public ProductsController(IProductsService productsService, IProductCategoriesService productCategoriesService)
        {
            _productsService = productsService;
            _productCategoriesService = productCategoriesService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetProducts(DatatableRequestViewModel datatableRequestViewModel)
        {
            var pagedResult = _productsService.GetFilteredProducts(datatableRequestViewModel);
            return Json(pagedResult.ToTableData());
        }
    }
}
