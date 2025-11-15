using AutoMapper;
using PC.Application.Common;
using PC.Application.DTOs;
using PC.Application.IRepository;
using PC.Application.IService;
using PC.Application.Wrappers;
using PC.Domain.Product;
using StackExchange.Redis;
using System.Text.Json;

namespace PC.Application.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        private readonly IConnectionMultiplexer _redis;

        public ProductService(IProductRepository repository, IMapper mapper, IConnectionMultiplexer redis)
        {
            _repository = repository;
            _mapper = mapper;
            _redis = redis;
        }
        public async Task<ServiceResponse<ProductOutDto>> CreateAsync(ProductInDto productInDto)
        {
            var product = _mapper.Map<Product>(productInDto);
            var created = await _repository.AddAsync(product);
            var outDto = _mapper.Map<ProductOutDto>(created);

            var db = _redis.GetDatabase();
            await db.StringSetAsync($"product:{created.Id}",JsonSerializer.Serialize(outDto));

            return new ServiceResponse<ProductOutDto>(outDto, 200);
        }
        public async Task<ServiceResponse<bool>> DeleteAsync(int id)
        {
            var deleted = await _repository.DeleteAsync(id);
            if (!deleted)
                return new ServiceResponse<bool>(new List<string> { "Product not found" }, 404);

            var db = _redis.GetDatabase();
            await db.KeyDeleteAsync($"product:{id}"); // Invalidate cache
            return new ServiceResponse<bool>(true, 200);
        }

        public async Task<ServiceResponse<ProductOutDto>> GetByIdAsync(int id)
        {
            var db = _redis.GetDatabase();
            var redisValue = await db.StringGetAsync($"product:{id}");

            if (!redisValue.IsNullOrEmpty)
            {
                Console.WriteLine($"[REDIS HIT] product:{id}");
                var dto = JsonSerializer.Deserialize<ProductOutDto>(redisValue!);
                return new ServiceResponse<ProductOutDto>(dto, 200);
            }

            Console.WriteLine($"[REDIS MISS] product:{id}");


            // 2. If not in Redis → fetch from DB
            var product = await _repository.GetByIdAsync(id);
            if (product == null)
                return new ServiceResponse<ProductOutDto>(
                    new List<string> { "Product not found" }, 404);

            var outDto = _mapper.Map<ProductOutDto>(product);

            // 3. Save in Redis
            await db.StringSetAsync(
                $"product:{id}",
                JsonSerializer.Serialize(outDto),
                TimeSpan.FromMinutes(10) // expiration optional
            );

            return new ServiceResponse<ProductOutDto>(outDto, 200);
        }

        public async Task<ServiceResponse<PaginatedResult<ProductOutDto>>> GetPagedAsync(PaginationParameters parameters)
        {
            var db = _redis.GetDatabase();
            var result = await _repository.GetPagedAsync(parameters);
            var dtoItems = _mapper.Map<List<ProductOutDto>>(result.Items);
            var pagedDto = new PaginatedResult<ProductOutDto>
            {
                Items = dtoItems,
                TotalCount = result.TotalCount,
                Page = result.Page,
                PageSize = result.PageSize
            };
            return new ServiceResponse<PaginatedResult<ProductOutDto>>(pagedDto, 200);
        }

        public async Task<ServiceResponse<ProductOutDto>> UpdateAsync(int id, ProductUpdateDto productUpdateDto)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null)
                return new ServiceResponse<ProductOutDto>(new List<string> { "Product not found" }, 404);

            _mapper.Map(productUpdateDto, product); // AutoMapper handles nulls
            var updated = await _repository.UpdateAsync(product);
            var outDto = _mapper.Map<ProductOutDto>(updated);

            var db = _redis.GetDatabase();
            await db.KeyDeleteAsync($"product:{id}"); // Invalidate cache
            await db.StringSetAsync($"product:{id}",JsonSerializer.Serialize(outDto));

            return new ServiceResponse<ProductOutDto>(outDto, 200);
        }

    }
}
