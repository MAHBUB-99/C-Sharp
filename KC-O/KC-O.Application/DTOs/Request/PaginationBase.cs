using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KC_O.Application.DTOs.Request
{
    public abstract class PaginationBase
    {
        public string Search { get; set; } = string.Empty;
        public string SortBy { get; set; } = "id";
        public string SortOrder { get; set; } = "asc";  // desc
        public bool IsActive { get; set; } = true;
        const int maxPageSize = 500;
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 10;
        public int ItemsPerPage
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }

    }
}
