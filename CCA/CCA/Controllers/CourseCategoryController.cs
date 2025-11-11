using CCA.Application.DTOs.CourseCategoryDtos;
using CCA.Application.IService;
using CCA.Application.Pagination;
using CCA.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CCA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseCategoryController : ControllerBase
    {
        private readonly ICourseCategoryService _courseCategoryService;
        public CourseCategoryController(ICourseCategoryService courseCategoryService)
        {
            _courseCategoryService = courseCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationParams paginationParams)
        {
            try
            {
                var categories = await _courseCategoryService.GetAllPagedAsync(paginationParams);
                return Ok(categories);
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
                var category = await _courseCategoryService.GetByIdAsync(id);
                if (category == null)
                    return NotFound(new { message = $"Course category with ID {id} not found." });

                return Ok(category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }


        [HttpGet("by-name/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            try
            {
                var category = await _courseCategoryService.GetByNameAsync(name);
                return Ok(category);
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


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CourseCategoryCreateDto categoryDto)
        {
            if (categoryDto == null || string.IsNullOrWhiteSpace(categoryDto.Name))
                return BadRequest(new { message = "Category data is invalid." });

            try
            {
                var result = await _courseCategoryService.AddAsync(categoryDto);
                if (result)
                    return Ok(new { message = "Course category added successfully." });

                return BadRequest(new { message = "Failed to add course category." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CourseCategoryUpdateDto categoryDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _courseCategoryService.UpdateAsync(id, categoryDto);
                if (result)
                    return Ok(categoryDto);

                return BadRequest("Unable to update category.");
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
                var result = await _courseCategoryService.DeleteAsync(id);
                if (result)
                    return Ok(new { Message = $"Course category with ID {id} deleted successfully." });

                return BadRequest(new { Message = "Unable to delete course category." });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }



    }
}
