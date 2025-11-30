using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KC_O.Application.DTOs.Request.Knowledge
{
    public class KnowledgeCategoryInDTO
    {
        [Required(ErrorMessage = "The name field is required.")]
        public string? Name { get; set; }
    }
}
