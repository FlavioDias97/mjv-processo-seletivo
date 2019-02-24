using MarketplaceAPI.Model;
using System.Collections.Generic;


namespace MarketplaceAPI.Business.Implementattions
{
    public interface ILoginBusiness
    {
        object FindByLogin(User user);
    }
}
