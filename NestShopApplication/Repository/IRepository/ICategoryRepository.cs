using NestShopApplication.Models;

namespace NestShopApplication.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category category);

    }
}
