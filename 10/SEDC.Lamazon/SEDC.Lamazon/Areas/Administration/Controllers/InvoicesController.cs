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
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoicesService _invoicesService;
        public InvoicesController(IInvoicesService invoicesService)
        {
            _invoicesService = invoicesService;

            PageName = "Invoices";
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> GetInvoices(DatatableRequestViewModel datatableRequestViewModel)
        {
            var pagedResult = await _invoicesService.GetFilteredInvoices(datatableRequestViewModel);
            return Json(pagedResult.ToTableData());
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if(id.HasValue)
            {
                var invoiceViewModel = await _invoicesService.GetInvoiceById(id.Value);
                return View(invoiceViewModel);
            }
            else
            {
                return new EmptyResult();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CancelInvoice(int? id)
        {
            if (id.HasValue)
            {
                await _invoicesService.CancelInvoice(id.Value);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return new EmptyResult();
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SetAsPaid(int? id)
        {
            if (id.HasValue)
            {
                await _invoicesService.SetAsPaid(id.Value);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return new EmptyResult();
            }
        }
    }
}
