using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace shoppayEntieys.Repository
{
    public interface IgenericRepository<T> where T : class
    {
        //Context,category.Incloude("Product").Tolist();
        //Context,category.Where(x=>x.id==id).Tolist();
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? predicate = null , string? Includeword = null );

        //Context,category.Incloude("Product").Tolist();
        //Context,category.Where(x=>x.id==id).Tolist();

        T GetFirstorDefault(Expression<Func<T, bool>>? predicate = null, string? Includeword = null);
        // _context.categories.add.(category);
        void Add(T entity);

        //_contexte.categories.Remove(categories);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);

    }
}
