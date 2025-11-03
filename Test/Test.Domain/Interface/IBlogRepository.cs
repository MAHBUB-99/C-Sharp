using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Domain.Entities;

namespace Test.Domain.Interface
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetAllAsync();
        Task<Blog> GetByIdAsync(Guid Id);
        Task<Blog> CreateAsync(Blog blog);
        Task<int> UpdateAsync(Guid Id,Blog blog);
        Task<int> DeleteAsync(Guid Id);
    }
}
