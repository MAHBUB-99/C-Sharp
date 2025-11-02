using CleanArchitecture.Application.DTOs.Student;
using CleanArchitecture.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Mappers
{
    public static class StudentMapper
    {
        public static StudentResponseDto ToStudentResponseDto(Student student)
        {
            return new StudentResponseDto
            {
                FirstName = student.FirstName,
                LastName = student.LastName
            };
        }
    }
}
