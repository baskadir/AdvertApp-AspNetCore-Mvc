using AdvertApp.DataAccess.Context;
using AdvertApp.DataAccess.Interfaces;
using AdvertApp.DataAccess.Repositories;
using System.Threading.Tasks;

namespace AdvertApp.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AdvertDbContext _context;
        public UnitOfWork(AdvertDbContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(_context);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
