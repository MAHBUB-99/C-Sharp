using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KC_O.Application.DTOs.Request.Knowledge
{
    public class KnowledgeInDTO
    {
        [Required(ErrorMessage = "The question field is required.")]
        public string? Question { get; set; }
        [Required(ErrorMessage = "The answer field is required.")]
        public string? Answer { get; set; }
        public string? Tag { get; set; }
        public bool IsPopular { get; set; }
        [Required(ErrorMessage = "The KnowledgeCategoryId field is required.")]
        public int KnowledgeCategoryId { get; set; }
    }
}
