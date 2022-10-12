﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SEDC.Lamazon.Areas.Administration.Controllers
{
    public class ControllerBase : Controller
    {
        protected string PageName { get; set; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ViewBag.PageName = PageName;

            base.OnActionExecuting(context);
        }

        protected void AddNotificationMessage(string message)
        {
            TempData["NotificationMessage"] = message;            
        }
    }
}
