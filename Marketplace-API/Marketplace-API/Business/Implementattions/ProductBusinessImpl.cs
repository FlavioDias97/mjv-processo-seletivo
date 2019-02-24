using System.Collections.Generic;
using MarketplaceAPI.Model;
using MarketplaceAPI.Repository.Generic;

namespace MarketplaceAPI.Business.Implementattions
{
    public class ProductBusinessImpl : IProductBusiness
    {
        private IRepository<Product> _repository;

        public ProductBusinessImpl(IRepository<Product> repository) => _repository = repository;

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

        public List<Product> FindByTerm(string entity, string atrribute, string term)
        {
            return _repository.FindByTerm(entity,atrribute, term);
        }


        public Product Update(Product product)
        {
            return _repository.Update(product);

        }
    }
}
