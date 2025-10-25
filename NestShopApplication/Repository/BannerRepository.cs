using NestShopApplication.Data;
using NestShopApplication.Models;
using NestShopApplication.Repository.IRepository;

namespace NestShopApplication.Repository
{
    public class BannerRepository : Repository<Banner>, IBannerRepository
    {
        private ApplicationDbContext _context;
        public BannerRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Banner banner)
        {
            var productInDb = _context.Products.FirstOrDefault(x => x.Id == banner.Id);
            if (productInDb != null)
            {
                productInDb.Name = banner.Name;
                productInDb.Description = banner.Description;
                if (banner.ImageUrl != null)
                {
                    productInDb.ImageUrl = banner.ImageUrl;
                }
            }
        }
    }
}
