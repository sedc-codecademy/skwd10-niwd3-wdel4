using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SEDC.Lamazon.ViewModels.Constants;

namespace SEDC.Lamazon.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize(Roles = Roles.Admin)]
    public class OrdersController : ControllerBase
    {
        public OrdersController()
        {
            PageName = "Orders";
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
