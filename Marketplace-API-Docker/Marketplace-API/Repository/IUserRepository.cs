using MarketplaceAPI.Model;
using System.Collections.Generic;


namespace MarketplaceAPI.Repository.Implementattions
{
    public interface IUserRepository
    {
        User FindByLogin(string login);
    }
}
