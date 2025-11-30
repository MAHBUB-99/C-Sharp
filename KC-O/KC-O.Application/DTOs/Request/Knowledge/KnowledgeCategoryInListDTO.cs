using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KC_O.Application.DTOs.Request.Knowledge
{
    public class KnowledgeCategoryInListDTO : PaginationBase
    {
        public string? Name { get; set; }
    }
}
