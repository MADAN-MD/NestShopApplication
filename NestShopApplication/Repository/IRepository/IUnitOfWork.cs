namespace NestShopApplication.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        IProductRepository Product { get; }
        IBannerRepository Banner { get; }

        void Save();
    }
}
