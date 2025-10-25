using NestShopApplication.Models;

namespace NestShopApplication.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product product);

    }
}
