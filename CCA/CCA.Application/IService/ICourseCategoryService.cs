using CCA.Application.DTOs.CourseCategoryDtos;
using CCA.Application.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCA.Application.IService
{
    public interface ICourseCategoryService
    {
        Task<PaginatedResult<CourseCategoryDto>> GetAllPagedAsync(PaginationParams paginationParams);
        Task<CourseCategoryDto> GetByIdAsync(int id);
        Task<CourseCategoryDto> GetByNameAsync(string name);
        Task<bool> AddAsync(CourseCategoryCreateDto courseCategoryCreateDto);
        Task<bool> UpdateAsync(int id,CourseCategoryUpdateDto categoryDto);
        Task<bool> DeleteAsync(int id);
    }
}
