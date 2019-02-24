using MarketplaceAPI.Model.Context;

namespace MarketplaceAPI.Repository.Implementattions
{
    public class StoreRepositoryimpl : IStoreRepository
    {
        private MySQLContext _context;

        public StoreRepositoryimpl(MySQLContext context)
        {
            _context = context;
        }

        //using only generics yet
    }
}
