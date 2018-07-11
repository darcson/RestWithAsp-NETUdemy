using Microsoft.EntityFrameworkCore;
using RestWithAspNETUdemy.Extensions;
using RestWithAspNETUdemy.Model.Base;
using RestWithAspNETUdemy.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithAspNETUdemy.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private SQLContext _context;
        private DbSet<T> _dataSet;

        public GenericRepository(SQLContext context)
        {
            _context = context;
            _dataSet = _context.Set<T>();
        }

        public T Create(T item)
        {
            try
            {
                _dataSet.Add(item);
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
            var dbItem = FindById(id);
            if (dbItem.IsNull())
                return;

            try
            {
                _dataSet.Remove(dbItem);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<T> FindAll()
        {
            try
            {
                return _dataSet.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T FindById(long id)
        {
            try
            {
                return _dataSet.SingleOrDefault(p => p.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T Update(T item)
        {
            var dbitem = FindById(item.Id.GetValueOrDefault());
            if (dbitem.IsNull())
                return null;

            try
            {
                _context.Entry(dbitem).CurrentValues.SetValues(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
