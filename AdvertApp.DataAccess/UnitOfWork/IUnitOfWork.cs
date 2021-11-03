using AdvertApp.DataAccess.Interfaces;
using System;
using System.Threading.Tasks;

namespace AdvertApp.DataAccess.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class;
        Task SaveChangesAsync();
    }
}
