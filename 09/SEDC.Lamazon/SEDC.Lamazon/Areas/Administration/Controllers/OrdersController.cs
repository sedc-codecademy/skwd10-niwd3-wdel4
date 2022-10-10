using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SEDC.Lamazon.Domain.Constants;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.ViewModels.Models;
using System.Threading.Tasks;

namespace SEDC.Lamazon.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = Roles.Admin)]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;
        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;

            PageName = "Orders";
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> GetOrders(DatatableRequestViewModel datatableRequestViewModel)
        {
            var pagedResult = await _ordersService.GetFilteredOrders(datatableRequestViewModel);
            return Json(pagedResult.ToTableData());
        }
    }
}
