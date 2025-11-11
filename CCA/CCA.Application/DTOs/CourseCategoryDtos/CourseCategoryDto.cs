using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCA.Application.DTOs.CourseCategoryDtos
{
    public class CourseCategoryDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
