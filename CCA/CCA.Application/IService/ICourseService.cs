using CCA.Application.DTOs.CourseDtos;
using CCA.Application.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCA.Application.IService
{
    public interface ICourseService
    {
        Task<PaginatedResult<CourseDto>> GetAllPagedAsync(PaginationParams paginationParams);
        Task<PaginatedResult<CourseDto>> GetByCategoryIdAsync(int categoryId, PaginationParams paginationParams);
        Task<CourseDto> GetByIdAsync(int id);
        Task<bool> AddAsync(CourseCreateDto courseCreateDto);
        Task<bool> UpdateAsync(int id, CourseUpdateDto courseUpdateDto);
        Task<bool> DeleteAsync(int id);
    }
}
