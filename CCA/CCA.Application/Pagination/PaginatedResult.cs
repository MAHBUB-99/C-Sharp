using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCA.Application.Pagination
{
    public class PaginatedResult<T> where T : class
    {
        public IEnumerable<T> Data { get; set; } = Enumerable.Empty<T>();
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }

        public PaginatedResult(IEnumerable<T> data,
            int totalCount,
            int currentPage,
            int pageSize
            ) 
        { 
            Data = data;
            TotalCount = totalCount;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
        }
    }
}
