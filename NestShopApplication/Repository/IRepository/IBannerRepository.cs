using NestShopApplication.Models;

namespace NestShopApplication.Repository.IRepository
{
    public interface IBannerRepository : IRepository<Banner>
    {
        void Update(Banner product);

    }
}
