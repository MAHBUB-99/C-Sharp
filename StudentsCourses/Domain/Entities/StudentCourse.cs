using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class StudentCourse
    {
        public Guid StudentId { get; set; }
        public Student Student { get; set; } = null!;


        public Guid CourseId { get; set; }
        public Course Course { get; set; } = null!;


        public DateTime EnrolledAt { get; set; } = DateTime.Now;
    }
}
