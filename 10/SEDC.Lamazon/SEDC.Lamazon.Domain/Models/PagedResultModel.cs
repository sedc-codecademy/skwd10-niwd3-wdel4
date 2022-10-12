using System.Collections.Generic;

namespace SEDC.Lamazon.Domain.Models
{
    public class PagedResultModel<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalRecords { get; set; }
        public int TotalDisplayRecords { get; set; }
    }
}
