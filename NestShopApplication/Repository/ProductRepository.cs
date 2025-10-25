using NestShopApplication.Data;
using NestShopApplication.Models;
using NestShopApplication.Repository.IRepository;

namespace NestShopApplication.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Product product)
        {
            var productInDb = _context.Products.FirstOrDefault(x => x.Id == product.Id);
            if (productInDb != null)
            {
                productInDb.Name = product.Name;
                productInDb.Price = product.Price;
                productInDb.Description = product.Description;
                productInDb.CategoryId = product.CategoryId;
                if (product.ImageUrl != null)
                {
                    productInDb.ImageUrl = product.ImageUrl;
                }
            }
            //_context.Products.Update(productInDb);
        }
    }
}
