using System;
using System.Collections.Generic;
using System.Linq;
using MarketplaceAPI.Model;
using MarketplaceAPI.Model.Context;
using MarketplaceAPI.Repository.Implementattions;

namespace MarketplaceAPI.Business.Implementattions
{
    public class StoreBusinessImpl : IStoreBusiness
    {
        private IStoreRepository _repository;

        public StoreBusinessImpl(IStoreRepository repository)
        {
            _repository = repository;
        }

        public Store Create(Store store)
        {
            return _repository.Create(store);
        }

        public void Delete(long id) 
        {
            _repository.Delete(id);
        }

        public List<Store> FindAll()
        {
            return _repository.FindAll();
        }


        public Store FindById(long id)
        {
            return _repository.FindById(id); 
        }

        public Store Update(Store store)
        {
            return _repository.Update(store);

        }

    }
}
