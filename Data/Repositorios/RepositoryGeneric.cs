using Azure.Core;
using Microsoft.EntityFrameworkCore;

namespace DemoJuntaViernes.Data.Repositorios
{
    public class RepositoryGeneric<TEntity> : IRepositoryGeneric<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TEntity> _entities;
        public RepositoryGeneric(ApplicationDbContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }
        public async Task<int> Create(TEntity entity)
        {
            await _context.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _entities.ToListAsync();
        }

    }
}
