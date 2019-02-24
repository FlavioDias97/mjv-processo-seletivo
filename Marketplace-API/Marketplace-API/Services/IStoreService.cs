using MarketplaceAPI.Model;
using System.Collections.Generic;


namespace MarketplaceAPI.Services.Implementattions
{
    public interface IStoreService
    {
        Store Create(Store store);
        Store FindById(long id);
        List<Store> FindAll();
        Store Update(Store store);
        void Delete(long id);


    }
}
