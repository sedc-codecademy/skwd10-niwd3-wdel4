using SEDC.Lamazon.Domain.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.Lamazon.DataAccess.Implementations
{
    public class InvoicesRepository : IRepository<Invoice>
    {
        public void DeleteById(int id)
        {
            var invoice = StaticDb.Invoices.FirstOrDefault(x => x.Id == id);
            if (invoice == null)
            {
                throw new Exception($"Invoice with id {id} was not found");
            }

            int index = StaticDb.Invoices.IndexOf(invoice);
            StaticDb.Invoices.RemoveAt(index);
        }

        public List<Invoice> GetAll()
        {
            return StaticDb.Invoices;
        }

        public Invoice GetById(int id)
        {
            return StaticDb.Invoices.FirstOrDefault(x => x.Id == id);
        }

        public int Insert(Invoice invoice)
        {
            invoice.Id = StaticDb.InvoiceId;
            StaticDb.Invoices.Add(invoice);
            StaticDb.InvoiceId++;
            return invoice.Id;
        }

        public void Update(Invoice invoice)
        {
            var entity = StaticDb.Invoices.FirstOrDefault(x => x.Id == invoice.Id);
            if (entity == null)
            {
                throw new Exception($"Invoice with id {entity.Id} was not found.");
            }

            int index = StaticDb.Invoices.IndexOf(entity);
            StaticDb.Invoices[index] = invoice;
        }
    }
}
