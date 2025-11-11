using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCA.Core.Entities
{
    [Table("CourseCategories")]
    public class CourseCategory : BaseEntity
    {
        [Required(ErrorMessage = "Category name is required.")]
        [MaxLength(150)]
        public required string Name { get; set; }

        // One-to-many relationship with Course
        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
