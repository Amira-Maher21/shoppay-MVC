using Microsoft.EntityFrameworkCore;
using shoppayData.Data;
using shoppayEntieys.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace shoppayData.Implementation
{
    public class GenericRepository<T> : IgenericRepository<T> where T : class
    {
        private readonly ShopDbcontext _context;

        private DbSet<T> _dbSet;
        public GenericRepository(ShopDbcontext context)
        {
           _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            //categories.add(Category);
            _dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate, string? Includeword)
        {
           IQueryable<T> query = _dbSet;
            if (predicate != null) 
            {
            query = query.Where(predicate);
            }
            if (Includeword != null )
            {
                // _context.product.Include(category,logo,user)
                foreach (var item in Includeword.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);

                }
            }
            return query.ToList();


        }

        public T GetFirstorDefault(Expression<Func<T, bool>> predicate, string? Includeword)
        {
            IQueryable<T> query = _dbSet;
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (Includeword != null)
            {
                // _context.product.Include(category,logo,user)
                foreach (var item in Includeword.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);

                }
            }
            return query.SingleOrDefault();
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }
    }
}
