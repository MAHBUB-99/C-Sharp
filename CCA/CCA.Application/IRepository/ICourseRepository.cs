using CCA.Application.Pagination;
using CCA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCA.Application.IRepository
{
    public interface ICourseRepository
    {
        Task<PaginatedResult<Course>> GetAllPagedAsync(PaginationParams paginationParams);
        Task<Course> GetByIdAsync(int categoryId);
        Task<PaginatedResult<Course>> GetByCategoryIdAsync(int categoryId, PaginationParams paginationParams);
        Task<bool> AddAsync(Course course);
        Task<bool> UpdateAsync(Course course);
        Task<bool> DeleteAsync(int id);
    }
}
