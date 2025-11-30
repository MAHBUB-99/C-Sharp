using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KC_O.Core.Entities.Knowledge
{
    [Table("KnowledgeCategories")]
    public class KnowledgeCategory
    {
        [Required]
        public string? Name { get; set; }
        public List<Knowledge>? Knowledges { get; set; }
    }
}
