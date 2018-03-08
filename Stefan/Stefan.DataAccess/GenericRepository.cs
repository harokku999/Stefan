using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Stefan.DataAccess.Entities;

namespace Stefan.DataAccess
{
    public interface IGenericRepository<TEntity>
        where TEntity : class, IEntity
    {
        Task<IList<TEntity>> GetAll();
        Task<TEntity> Get(int id);
        Task Create(TEntity entity);
        Task Edit(TEntity entity);
        Task Delete(int id);
    }

    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class, IEntity
    {
        private readonly StefanDbContext _context;

        public GenericRepository(StefanDbContext context)
        {
            _context = context;
        }

        public async Task<IList<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public Task<TEntity> Get(int id)
        {
            return _context.Set<TEntity>().SingleAsync(e => e.Id == id);
        }

        public async Task Create(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await Get(id);
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
