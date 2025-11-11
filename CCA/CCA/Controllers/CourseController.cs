using CCA.Application.DTOs.CourseDtos;
using CCA.Application.IService;
using CCA.Application.Pagination;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CCA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationParams paginationParams)
        {
            try
            {
                var courses = await _courseService.GetAllPagedAsync(paginationParams);
                return Ok(courses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var course = await _courseService.GetByIdAsync(id);
                if (course == null)
                    return NotFound(new { message = $"Course with ID {id} not found." });

                return Ok(course);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("by-category/{categoryId}")]
        public async Task<IActionResult> GetByCategoryId(int categoryId, [FromQuery] PaginationParams paginationParams)
        {
            try
            {
                var courses = await _courseService.GetByCategoryIdAsync(categoryId, paginationParams);
                return Ok(courses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CourseCreateDto courseCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _courseService.AddAsync(courseCreateDto);
                if (result)
                    return Ok(new { message = "Course added successfully." });

                return BadRequest(new { message = "Failed to add course." });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CourseUpdateDto courseUpdateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _courseService.UpdateAsync(id, courseUpdateDto);
                if (result)
                    return Ok(new { message = "Course updated successfully." });

                return BadRequest(new { message = "Failed to update course." });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _courseService.DeleteAsync(id);
                if (result)
                    return Ok(new { message = "Course deleted successfully." });

                return NotFound(new { message = $"Course with ID {id} not found." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
