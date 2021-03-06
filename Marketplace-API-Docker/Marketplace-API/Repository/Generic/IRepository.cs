﻿using MarketplaceAPI.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketplaceAPI.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T FindById(long id);
        List<T> FindByTerm(string entity,string attribute, string term);
        List<T> GetRelated(string entity, string attribute, string term);
        List<T> FindAll();
        T Update(T item);
        void Delete(long id);

        bool Exist(long? id);
    }
}
