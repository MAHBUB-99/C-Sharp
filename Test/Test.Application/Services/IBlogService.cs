using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Domain.Entities;

namespace Test.Application.Services
{
    public interface IBlogService
    {
        Task<List<Blog>> GetAllAsync();
        Task<Blog> GetByIdAsync(Guid id);
        Task<Blog> CreateAsync(Blog blog);
        Task<int> UpdateAsync(Guid Id,Blog blog);
        Task<int> DeleteAsync(Guid Id);
    }
}
