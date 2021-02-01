namespace ElectronicShop.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private ElectronicShopDbContext dbContext;

        public ElectronicShopDbContext Init()
        {
            return dbContext ?? (dbContext = new ElectronicShopDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}