using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KC_O.Core.Entities.Knowledge
{
    [Table("Knowledges")]
    public class Knowledge : BaseEntity
    {
        [Required]
        public string? Question { get; set; }
        [Required]
        public string? Answer { get; set; }
        public string? Tag { get; set; }
        public bool IsPopular { get; set; }
        public int KnowledgeCategoryId { get; set; }
        [ForeignKey(nameof(KnowledgeCategoryId)]
        public KnowledgeCategory? KnowledgeCategory { get; set; }
    }
}
