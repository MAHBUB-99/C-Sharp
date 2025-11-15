using PC.Application.Common;
using PC.Application.DTOs;
using PC.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC.Application.IService
{
    public interface IProductService
    {
        Task<ServiceResponse<ProductOutDto>> GetByIdAsync(int id);
        Task<ServiceResponse<PaginatedResult<ProductOutDto>>> GetPagedAsync(PaginationParameters parameters);
        Task<ServiceResponse<ProductOutDto>> CreateAsync(ProductInDto productInDto);
        Task<ServiceResponse<ProductOutDto>> UpdateAsync(int id, ProductUpdateDto productUpdateDto);
        Task<ServiceResponse<bool>> DeleteAsync(int id);
    }
}
