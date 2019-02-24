using System;
using System.Collections.Generic;
using System.Linq;
using MarketplaceAPI.Model;
using MarketplaceAPI.Model.Context;

namespace MarketplaceAPI.Repository.Implementattions
{
    public class ProductRepositoryImpl : IProductRepository
    {
        private MySQLContext _context;

        public ProductRepositoryImpl(MySQLContext context)
        {
            _context = context;
        }

    
        public Product Create(Product Product)
        {
            try
            {
                _context.Add(Product);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }


            return Product;
        }

        public void Delete(long id)
        {
            var result = _context.Products.SingleOrDefault(s => s.Id.Equals(id));
            try
            {
                if (result != null) _context.Products.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        
        }

        public List<Product> FindAll()
        {
            return _context.Products.ToList();
        }


        public Product FindById(long id)
        {
            return _context.Products.SingleOrDefault(s => s.Id.Equals(id));
        }

        public Product Update(Product Product)
        {
            if (!Exist(Product.Id)) return new Product();

            var result = _context.Products.SingleOrDefault(s => s.Id.Equals(Product.Id));
            try
            {
                _context.Entry(result).CurrentValues.SetValues(Product);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Product;
        }

        public bool Exist(long? id)
        {
            return _context.Products.Any(s => s.Id.Equals(id));
        }
    }
}
