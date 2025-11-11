using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCA.Core.Entities
{
    [Table("Courses")]
    public class Course : BaseEntity
    {
        [Required(ErrorMessage = "Course title is required.")]
        [MaxLength(200)]
        public required string Title { get; set; }

        // Foreign key
        [Required(ErrorMessage = "CategoryId is required.")]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        // Navigation property
        public CourseCategory Category { get; set; } = default!;
    }
}
