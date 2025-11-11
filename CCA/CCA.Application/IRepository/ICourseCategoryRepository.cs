using CCA.Application.DTOs;
using CCA.Application.Pagination;
using CCA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCA.Application.IRepository
{
    public interface ICourseCategoryRepository
    {
        Task<PaginatedResult<CourseCategory>> GetAllPagedAsync(PaginationParams paginationParams);
        Task<CourseCategory> GetByIdAsync(int id);
        Task<CourseCategory> GetByNameAsync(string name);
        Task<bool> AddAsync(CourseCategory category);
        Task<bool> UpdateAsync(CourseCategory category);
        Task<bool> DeleteAsync(int id);
    }
}
