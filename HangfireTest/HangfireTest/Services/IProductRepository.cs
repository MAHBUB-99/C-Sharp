using HangfireTest.Models;
using System.Collections.Concurrent;

namespace HangfireTest.Services
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> GetAll();
        public Task<Product?> GetById(int id);
        public Task<Product> Create(Product product);
        public Task<Product?> Update(int id, Product product);
        public Task<bool> Delete(int id);
    }
    public class ProductRepository : IProductRepository
    {
        private readonly ConcurrentDictionary<int, Product> _store = new();
        private int _idCounter = 1;
        public Task<Product> Create(Product product)
        {
            var id = Interlocked.Increment(ref _idCounter);
            product.id = id;
            product.price = product.price;
            product.stock = product.stock;
            _store[id] = product;
            return Task.FromResult(product);
        }

        public Task<bool> Delete(int id)
        {
            _store.TryRemove(id, out _);
            return Task.FromResult(true);
        }

        public Task<IEnumerable<Product>> GetAll()
        {
            var result = _store.Values.OrderBy(x=>x.id).AsEnumerable();
            return Task.FromResult(result);
        }

        public Task<Product?> GetById(int id)
        {
            var result = _store.GetValueOrDefault(id);
            return Task.FromResult<Product?>(result);
        }

        public Task<Product?> Update(int id, Product product)
        {
            var existingProduct = _store.GetValueOrDefault(id);
            if (existingProduct == null)
            {
                return Task.FromResult<Product?>(null);
            }
            existingProduct.name = product.name;
            existingProduct.price = product.price;
            existingProduct.stock = product.stock;
            _store[id] = existingProduct;
            return Task.FromResult<Product?>(existingProduct);
        }
    }
}

