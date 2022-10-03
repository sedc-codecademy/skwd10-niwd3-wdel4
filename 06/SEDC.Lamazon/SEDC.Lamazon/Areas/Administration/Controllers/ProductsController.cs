using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.ViewModels.Constants;
using SEDC.Lamazon.ViewModels.Models;

namespace SEDC.Lamazon.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = Roles.Admin)]
    public class ProductsController : ControllerBase
    {
        private IProductsService _productsService;
        private IProductCategoriesService _productCategoriesService;

        public ProductsController(IProductsService productsService, IProductCategoriesService productCategoriesService)
        {
            _productsService = productsService;
            _productCategoriesService = productCategoriesService;

            PageName = "Products";
        }

        public IActionResult Index()
        {
            SetMetadata();
            return View();
        }

        [HttpPost]
        public JsonResult GetProducts(ProductsDatatableRequestViewModel roductsDatatableRequestViewModel)
        {
            var pagedResult = _productsService.GetFilteredProducts(roductsDatatableRequestViewModel);
            return Json(pagedResult.ToTableData());
        }

        private void SetMetadata(ProductViewModel productViewModel = null)
        {
            var productCategories = _productCategoriesService.GetAllProductCategories();
            ViewBag.ProductCategoryId = new SelectList(productCategories, "Id", "Name", productViewModel?.ProductCategoryId);
        }
    }
}
