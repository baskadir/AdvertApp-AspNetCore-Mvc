using AdvertApp.Common.Enums;
using AdvertApp.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdvertApp.DataAccess.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T,bool>> filter);
        Task<IEnumerable<T>> GetAllAsync<TKey>(Expression<Func<T,TKey>> selector, OrderByType orderByType = OrderByType.Descending);
        Task<IEnumerable<T>> GetAllAsync<TKey>(Expression<Func<T,bool>> filter, Expression<Func<T, TKey>> selector, OrderByType orderByType = OrderByType.Descending);
        Task<T> FindAsync(object id);
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter, bool asNoTracking = false);
        IQueryable<T> GetQuery();
        void Remove(T entity);
        Task CreateAsync(T entity);
        void Update(T entity, T unchanged);
    }
}
