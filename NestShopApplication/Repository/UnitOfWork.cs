using NestShopApplication.Data;
using NestShopApplication.Repository.IRepository;

namespace NestShopApplication.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;
        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }
        public IBannerRepository Banner { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Category = new CategoryRepository(_context);
            Product = new ProductRepository(_context);
            Banner = new BannerRepository(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
