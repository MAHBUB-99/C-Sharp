using PC.Application.Common;
using PC.Domain.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC.Application.IRepository
{
    public interface IProductRepository
    {
        Task<PaginatedResult<Product>> GetPagedAsync(PaginationParameters parameters);
        Task<Product?> GetByIdAsync(int id);
        Task<Product> AddAsync(Product product);
        Task<Product> UpdateAsync(Product product);
        Task<bool> DeleteAsync(int id);
    }
}
