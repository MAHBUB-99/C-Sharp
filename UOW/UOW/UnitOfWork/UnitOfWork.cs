using UOW.Repositories;

namespace UOW.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public IProductRepository _productRepository { get; }
        public IOrderRepository _orderRepository { get; }

        public UnitOfWork(ApplicationDbContext applicationDbContext,IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _applicationDbContext = applicationDbContext;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }
        public void Dispose()
        {
            _applicationDbContext.Dispose();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _applicationDbContext.SaveChangesAsync();
        }
    }
}
