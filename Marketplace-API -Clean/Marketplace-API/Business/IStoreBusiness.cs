using MarketplaceAPI.Model;
using System.Collections.Generic;


namespace MarketplaceAPI.Business.Implementattions
{
    public interface IStoreBusiness
    {
        Store Create(Store store);
        Store FindById(long id);
        List<Store> FindByTerm(string entity, string atrribute, string term);
        List<Store> FindAll();
        Store Update(Store store);
        void Delete(long id);
    }
}
