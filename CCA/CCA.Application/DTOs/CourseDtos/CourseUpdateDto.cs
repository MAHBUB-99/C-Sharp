using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCA.Application.DTOs.CourseDtos
{
    public class CourseUpdateDto
    {
        public required string Title { get; set; }
        public required int CategoryId { get; set; }
    }
}
