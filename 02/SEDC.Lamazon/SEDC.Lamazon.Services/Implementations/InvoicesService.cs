using SEDC.Lamazon.DataAccess;
using SEDC.Lamazon.Domain.Enitities;
using SEDC.Lamazon.Mappers;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.ViewModels.Models;
using System;
using System.Collections.Generic;

namespace SEDC.Lamazon.Services.Implementations
{
    public class InvoicesService : IInvoicesService
    {
        private readonly IRepository<Invoice> _invoicesRepository;
        public InvoicesService(IRepository<Invoice> invoicesRepository)
        {
            _invoicesRepository = invoicesRepository;
        }

        public void CreateInvoice(InvoiceViewModel invoiceViewModel)
        {
            var invoice = invoiceViewModel.ToInvoice();
            int invoiceId = _invoicesRepository.Insert(invoice);
            if (invoiceId <= 0)
            {
                throw new Exception($"Something went wrong while saving the new invoice");
            }
        }

        public void DeleteInvoiceById(int id)
        {
            _invoicesRepository.DeleteById(id);
        }

        public List<InvoiceViewModel> GetAllInvoices()
        {
            var invoices = _invoicesRepository.GetAll();
            return invoices.ToInvoiceViewModelList();
        }

        public InvoiceViewModel GetInvoiceById(int id)
        {
            var invoice = _invoicesRepository.GetById(id);
            return invoice.ToInvoiceViewModel();
        }

        public void UpdateInvoice(InvoiceViewModel invoiceViewModel)
        {
            var invoice = invoiceViewModel.ToInvoice();
            _invoicesRepository.Update(invoice);
        }
    }
}
