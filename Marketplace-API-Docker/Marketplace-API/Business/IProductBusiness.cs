﻿using MarketplaceAPI.Model;
using System.Collections.Generic;


namespace MarketplaceAPI.Business.Implementattions
{
    public interface IProductBusiness
    {
        Product Create(Product product);
        Product FindById(long id);
        List<Product> FindByTerm(string entity, string atrribute, string term);
        List<Product> GetRelated(string entity, string attribute, string term);
        List<Product> FindAll();
        Product Update(Product product);
        void Delete(long id);
    }
}
