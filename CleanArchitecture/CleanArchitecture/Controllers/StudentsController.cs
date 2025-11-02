using CleanArchitecture.Application.DTOs.Student;
using CleanArchitecture.Application.Mappers;
using CleanArchitecture.Application.Services.Student;
using CleanArchitecture.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentService _service;

        public StudentsController(StudentService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = _service.GetAll();
            return Ok(students);
        }
    }
}
