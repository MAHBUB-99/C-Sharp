using CCA.Application.DTOs;
using CCA.Application.IRepository;
using CCA.Application.Pagination;
using CCA.Core.Entities;
using CCA.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCA.Infrastructure.Repository
{
    public class CourseCategoryRepository : ICourseCategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedResult<CourseCategory>> GetAllPagedAsync(PaginationParams paginationParams)
        {
            var query = _context.CourseCategories.AsQueryable();
            var totalCount = await query.CountAsync();
            var courseCategories = await query
                .Skip((paginationParams.PageNumber - 1) * paginationParams.PageSize)
                .Take(paginationParams.PageSize)
                .ToListAsync();
            return new PaginatedResult<CourseCategory>(
                data: courseCategories,
                totalCount: totalCount,
                currentPage: paginationParams.PageNumber,
                pageSize: paginationParams.PageSize
            );
        }

        public async Task<CourseCategory> GetByIdAsync(int id)
        {
            var category = await _context.CourseCategories.FindAsync(id);
            if (category == null)
            {
                return null;
            }
            return category;
        }

        public async Task<CourseCategory> GetByNameAsync(string name)
        {
            var category = await _context.CourseCategories
                .FirstOrDefaultAsync(c => c.Name.ToLower() == name.ToLower());

            return category ;
        }


        public async Task<bool> AddAsync(CourseCategory category)
        {
            await _context.CourseCategories.AddAsync(category);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(CourseCategory category)
        {
            _context.CourseCategories.Update(category);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _context.CourseCategories.FindAsync(id);
            if (category == null)
            {
                return false;
            }

            _context.CourseCategories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
