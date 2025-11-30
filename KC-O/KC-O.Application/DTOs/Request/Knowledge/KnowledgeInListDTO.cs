using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KC_O.Application.DTOs.Request.Knowledge
{
    public class KnowledgeInListDTO : PaginationBase
    {
        public string? Question { get; set; }
        public string? Tag { get; set; }
        public bool? IsPopular { get; set; }
    }
}
