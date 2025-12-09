using UOW.Repositories;

namespace UOW.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository _productRepository { get; }
        IOrderRepository _orderRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
