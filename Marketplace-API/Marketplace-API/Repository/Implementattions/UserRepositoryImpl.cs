using MarketplaceAPI.Model;
using MarketplaceAPI.Model.Context;
using System.Linq;

namespace MarketplaceAPI.Repository.Implementattions
{
    public class UserRepositoryImpl : IUserRepository
    {
        private MySQLContext _context;

        public UserRepositoryImpl(MySQLContext context)
        {
            _context = context;
        }

        public User FindByLogin(string login)
        {
            return _context.Users.SingleOrDefault(p => p.Login.Equals(login)) ;
        }
    }
}
