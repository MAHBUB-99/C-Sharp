using AutoMapper;
using PC.Application.DTOs;
using PC.Application.IRepository;
using PC.Application.IService;
using PC.Application.Wrappers;
using PC.Domain.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC.Application.Service
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<ProductOutDto>> CreateAsync(ProductInDto productInDto)
        {
            var product = _mapper.Map<Product>(productInDto);
            var created = await _repository.AddAsync(product);
            var outDto = _mapper.Map<ProductOutDto>(created);

            return new ServiceResponse<ProductOutDto>(outDto, 200);
        }
        public async Task<ServiceResponse<bool>> DeleteAsync(int id)
        {
            var deleted = await _repository.DeleteAsync(id);
            if (!deleted)
                return new ServiceResponse<bool>(new List<string> { "Product not found" }, 404);

            return new ServiceResponse<bool>(true, 200);
        }

        public async Task<ServiceResponse<ProductOutDto>> GetByIdAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null)
                return new ServiceResponse<ProductOutDto>(new List<string> { "Product not found" }, 404);

            var outDto = _mapper.Map<ProductOutDto>(product);
            return new ServiceResponse<ProductOutDto>(outDto, 200);
        }

        public async Task<ServiceResponse<(List<ProductOutDto> Items, int TotalCount)>> GetPagedAsync(int page, int pageSize)
        {
            var (items, totalCount) = await _repository.GetPagedAsync(page, pageSize);
            var dtoItems = _mapper.Map<List<ProductOutDto>>(items);

            return new ServiceResponse<(List<ProductOutDto>, int)>((dtoItems, totalCount), 200);
        }

        public async Task<ServiceResponse<ProductOutDto>> UpdateAsync(int id, ProductUpdateDto productUpdateDto)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null)
                return new ServiceResponse<ProductOutDto>(new List<string> { "Product not found" }, 404);

            _mapper.Map(productUpdateDto, product); // AutoMapper handles nulls
            var updated = await _repository.UpdateAsync(product);
            var outDto = _mapper.Map<ProductOutDto>(updated);

            return new ServiceResponse<ProductOutDto>(outDto, 200);
        }

    }
}
