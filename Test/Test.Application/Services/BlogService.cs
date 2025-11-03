using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Domain.Entities;
using Test.Domain.Interface;

namespace Test.Application.Services
{
    public class BlogService : IBlogServices
    {
        private readonly IBlogRepository _blogRepository;
        public BlogService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
        public async Task<Blog> CreateAsync(Blog blog)
        {
            return await _blogRepository.CreateAsync(blog);
        }

        public async Task<int> DeleteAsync(Guid Id)
        {
            return await _blogRepository.DeleteAsync(Id);
        }

        public async Task<List<Blog>> GetAllAsync()
        {
            return await _blogRepository.GetAllAsync();
        }

        public async Task<Blog> GetByIdAsync(Guid id)
        {
            return await _blogRepository.GetByIdAsync(id);
        }

        public async Task<int> UpdateAsync(Guid Id, Blog blog)
        {
            return await _blogRepository.UpdateAsync(Id, blog);   
        }
    }
}
