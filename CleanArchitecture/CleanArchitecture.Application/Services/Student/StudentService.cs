using CleanArchitecture.Application.DTOs.Student;
using CleanArchitecture.Application.Entities;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services.Student
{
    public class StudentService
    {
        private readonly IApplicationDbContext _context;

        public StudentService(IApplicationDbContext context)
        {
            _context = context;
        }

        public List<StudentResponseDto> GetAll()
        {
            var students =  _context.Students.ToList();
            var studentDtos = students.Select(s => StudentMapper.ToStudentResponseDto(s)).ToList();
            return studentDtos;
        }
    }
}
