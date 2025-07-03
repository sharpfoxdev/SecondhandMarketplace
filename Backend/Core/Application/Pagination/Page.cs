using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Pagination
{
    public class Page<T>
    {
        public List<T> Items { get; }
        public int TotalCount { get; }
        public int PageNumber { get; }
        public int PageSize { get; }
        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
        public Page(List<T> items, int count, int pageNumber, int pageSize)
        {
            Items = items;
            TotalCount = count;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }

}
