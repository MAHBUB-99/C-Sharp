using Microsoft.EntityFrameworkCore;
using Test.Domain.Entities;
using Test.Domain.Interface;
using Test.Infrastructure.Data;

namespace Test.Infrastructure.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogDBContext _dbcontext;
        public BlogRepository(BlogDBContext dbcontext) 
        {
            _dbcontext = dbcontext;
        }
        public async Task<Blog> CreateAsync(Blog blog)
        {
            await _dbcontext.Blogs.AddAsync(blog);
            await  _dbcontext.SaveChangesAsync();
            return blog;
        }

        public async Task<int> DeleteAsync(Guid Id)
        {
            return await _dbcontext.Blogs.Where(model => model.Id == Id).ExecuteDeleteAsync();
        }

        public async Task<List<Blog>> GetAllAsync()
        {
            return await _dbcontext.Blogs.ToListAsync();
        }

        public async Task<Blog> GetByIdAsync(Guid Id)
        {
            return await _dbcontext.Blogs.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<int> UpdateAsync(Guid Id,Blog blog)
        {
            return await _dbcontext.Blogs
                .Where(m => m.Id == Id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Title, blog.Title)
                    .SetProperty(m => m.Content, blog.Content)
                    .SetProperty(m => m.Author, blog.Author)
                );
        }
    }
}
