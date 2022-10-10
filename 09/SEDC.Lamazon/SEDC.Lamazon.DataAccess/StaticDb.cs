using SEDC.Lamazon.Domain.Enitities;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.Lamazon.DataAccess
{
    public static class StaticDb
    {
        public static int InvoiceId { get; set; }

        public static List<Invoice> Invoices { get; set; }
    }
}
