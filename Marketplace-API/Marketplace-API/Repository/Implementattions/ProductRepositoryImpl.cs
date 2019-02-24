using MarketplaceAPI.Model.Context;

namespace MarketplaceAPI.Repository.Implementattions
{
    public class ProductRepositoryImpl : IProductRepository
    {
        private MySQLContext _context;

        public ProductRepositoryImpl(MySQLContext context)
        {
            _context = context;
        }


        //using only generics yet
    }
}
