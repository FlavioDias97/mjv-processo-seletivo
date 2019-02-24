using System;
using System.Collections.Generic;
using System.Linq;
using MarketplaceAPI.Model;
using MarketplaceAPI.Model.Context;

namespace MarketplaceAPI.Repository.Implementattions
{
    public class StoreRepositoryimpl : IStoreRepository
    {
        private MySQLContext _context;

        public StoreRepositoryimpl(MySQLContext context)
        {
            _context = context;
        }

        public Store Create(Store store)
        {
            try
            {
                _context.Add(store);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }


            return store;
        }

        public void Delete(long id)
        {
            var result = _context.Stores.SingleOrDefault(s => s.Id.Equals(id));
            try
            {
                if (result != null) _context.Stores.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        
        }

        public List<Store> FindAll()
        {
            return _context.Stores.ToList();
        }


        public Store FindById(long id)
        {
            return _context.Stores.SingleOrDefault(s => s.Id.Equals(id));
        }

        public Store Update(Store store)
        {
            if (!Exist(store.Id)) return null;

            var result = _context.Stores.SingleOrDefault(s => s.Id.Equals(store.Id));
            try
            {
                _context.Entry(result).CurrentValues.SetValues(store);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return store;
        }

        public bool Exist(long? id)
        {
            return _context.Stores.Any(s => s.Id.Equals(id));
        }
    }
}
