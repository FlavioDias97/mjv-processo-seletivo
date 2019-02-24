using System;
using System.Collections.Generic;
using System.Linq;
using MarketplaceAPI.Model;
using MarketplaceAPI.Model.Context;
using MarketplaceAPI.Repository.Implementattions;

namespace MarketplaceAPI.Business.Implementattions
{
    public class ProductBusinessImpl : IProductBusiness
    {
        private IProductRepository _repository;

        public ProductBusinessImpl(IProductRepository repository)
        {
            _repository = repository;
        }

        public Product Create(Product product)
        {
            return _repository.Create(product);
        }

        public void Delete(long id) 
        {
            _repository.Delete(id);
        }

        public List<Product> FindAll()
        {
            return _repository.FindAll();
        }


        public Product FindById(long id)
        {
            return _repository.FindById(id); 
        }

        public Product Update(Product product)
        {
            return _repository.Update(product);

        }
    }
}
