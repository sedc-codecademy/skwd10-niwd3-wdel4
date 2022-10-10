using AutoMapper;
using SEDC.Lamazon.DataAccess;
using SEDC.Lamazon.Domain.Enitities;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.ViewModels.Models;
using System;
using System.Collections.Generic;

namespace SEDC.Lamazon.Services.Implementations
{
    public class InvoicesService : BaseService, IInvoicesService
    {
        private readonly IRepository<Invoice> _invoicesRepository;
        private readonly IMapper _mapper;

        public InvoicesService(IRepository<Invoice> invoicesRepository, IMapper mapper)
        {
            _invoicesRepository = invoicesRepository;
            _mapper = mapper;
        }

        public void CreateInvoice(InvoiceViewModel invoiceViewModel)
        {
            var invoice = _mapper.Map<Invoice>(invoiceViewModel);
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
            return _mapper.Map<List<InvoiceViewModel>>(invoices);
        }

        public InvoiceViewModel GetInvoiceById(int id)
        {
            var invoice = _invoicesRepository.GetById(id);
            return _mapper.Map<InvoiceViewModel>(invoice);
        }

        public void UpdateInvoice(InvoiceViewModel invoiceViewModel)
        {
            var invoice = _mapper.Map<Invoice>(invoiceViewModel);
            _invoicesRepository.Update(invoice);
        }
    }
}
