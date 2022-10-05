﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SEDC.Lamazon.Domain.Constants;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.ViewModels.Models;

namespace SEDC.Lamazon.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = Roles.Admin)]
    public class ProductCategoriesController : ControllerBase
    {
        private IProductCategoriesService _productCategoriesService;

        public ProductCategoriesController(IProductCategoriesService productCategoriesService)
        {
            _productCategoriesService = productCategoriesService;
            PageName = "Product Categories";
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetProductCategories(DatatableRequestViewModel datatableRequestViewModel)
        {
            var pagedResult = _productCategoriesService.GetFilteredProductCategories(datatableRequestViewModel);
            return Json(pagedResult.ToTableData());
        }

        public IActionResult Create()
        {
            var productCategoryViewModel = new ProductCategoryViewModel();
            return View(productCategoryViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductCategoryViewModel productCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                _productCategoriesService.CreateProductCategory(productCategoryViewModel);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(productCategoryViewModel);
            }
        }


        public IActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                var productCategoryViewModel = _productCategoriesService.GetProductCategoryById(id.Value);
                return View(productCategoryViewModel);
            }
            else
            {
                return new EmptyResult();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductCategoryViewModel productCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                _productCategoriesService.UpdateProductCategory(productCategoryViewModel);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(productCategoryViewModel);
            }
        }

        public IActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                var productCategoryViewModel = _productCategoriesService.GetProductCategoryById(id.Value);
                return View(productCategoryViewModel);
            }
            else
            {
                return new EmptyResult();
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            if (id.HasValue)
            {
                _productCategoriesService.DeleteProductCategoryById(id.Value);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return new EmptyResult();
            }
        }
    }
}
