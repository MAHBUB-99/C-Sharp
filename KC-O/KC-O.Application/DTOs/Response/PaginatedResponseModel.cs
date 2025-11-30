using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KC_O.Application.DTOs.Response
{
    public class PaginatedResponseModel<T> where T : class
    {
        public PaginatedResponseModel() 
        { 
            Items = new List<T>();
        }
        public List<T>? Items { get; set; }
        public long TotalItems { get; set; }
        public int TotalPages { get; set; }
        public int PageNumber { get; set; }
        public int ItemsPerPage { get; set; }

    }
}
