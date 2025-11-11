using CCA.Application.IRepository;
using CCA.Application.IService;
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
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedResult<Course>> GetAllPagedAsync(PaginationParams paginationParams)
        {
            var query = _context.Courses.Include(c => c.Category).AsQueryable();

            var totalCount = await query.CountAsync();

            var courses = await query
                .Skip((paginationParams.PageNumber - 1) * paginationParams.PageSize)
                .Take(paginationParams.PageSize)
                .ToListAsync();

            return new PaginatedResult<Course>(
                data: courses,
                totalCount: totalCount,
                currentPage: paginationParams.PageNumber,
                pageSize: paginationParams.PageSize
            );
        }

        public async Task<PaginatedResult<Course>> GetByCategoryIdAsync(int categoryId, PaginationParams paginationParams)
        {
            var query = _context.Courses
                .Where(c => c.CategoryId == categoryId)
                .Include(c => c.Category)
                .AsQueryable();

            var totalCount = await query.CountAsync();

            var courses = await query
                .Skip((paginationParams.PageNumber - 1) * paginationParams.PageSize)
                .Take(paginationParams.PageSize)
                .ToListAsync();

            return new PaginatedResult<Course>(
                data: courses,
                totalCount: totalCount,
                currentPage: paginationParams.PageNumber,
                pageSize: paginationParams.PageSize
            );
        }

        public async Task<Course> GetByIdAsync(int id)
        {
            return await _context.Courses
                .Include(c => c.Category)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> AddAsync(Course course)
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Course course)
        {
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null) return false;

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
