﻿using MarketplaceAPI.Model.Base;
using MarketplaceAPI.Model.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarketplaceAPI.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MySQLContext _context;
        private DbSet<T> dataset;

        public GenericRepository(MySQLContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }

        public T Create(T item)
        {
            try
            {
                dataset.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }

        public void Delete(long id)
        {
            var result = dataset.SingleOrDefault(s => s.Id.Equals(id));
            try
            {
                if (result != null) dataset.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Exist(long? id)
        {
            return dataset.Any(s => s.Id.Equals(id));
        }

        public List<T> FindAll()
        {
            return dataset.ToList();
        }

        public T FindById(long id)
        {
            return dataset.SingleOrDefault(s => s.Id.Equals(id));
        }

        public List<T> FindByTerm(string entity, string attribute, string term)
        {
            string query = "";
            if (entity.Equals("products"))
            {
               query  = " SELECT PROD.Id,PROD.Image,PROD.ProductName,PROD.price,PROD.Description ,PROD.Quantity, PROD.Category, STO.FantasyName AS 'store_id' FROM products AS PROD INNER JOIN stores AS STO " +
                        " WHERE PROD."+ attribute + " LIKE '%"+term+"%' AND PROD.store_id = STO.Id";
            }
            else
            {
                query = "SELECT * FROM " + entity + " WHERE " + attribute + " LIKE '%" + term + "%' ";
            }
            List<T> result = dataset
                .FromSql(query)
                .ToList();
            return result;
        }

        public List<T> GetRelated(string entity, string attribute, string term)
        {

            var query = " SELECT * FROM " + entity + " WHERE " + attribute + " LIKE '%"+term+"%' ";
          
            List<T> result = dataset
                .FromSql(query)
                .ToList();

            return result;
        }

        public T Update(T item)
        {
            if (!Exist(item.Id)) return null;

            var result = dataset.SingleOrDefault(s => s.Id.Equals(item.Id));
            try
            {
                _context.Entry(result).CurrentValues.SetValues(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}
