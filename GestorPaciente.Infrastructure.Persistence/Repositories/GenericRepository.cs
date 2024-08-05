using GestorPaciente.Core.Application.Interfaces.Repositories;
using GestorPaciente.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace GestorPaciente.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
    {
        private readonly GestorPacienteContext _context;
        public GenericRepository(GestorPacienteContext context) { 
            _context = context;
        }

        public async Task<Entity> AddAsync(Entity entity)
        {
            await _context.Set<Entity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync (Entity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync (Entity entity)
        {
            _context.Set<Entity>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Entity>> GetAllAsync()
        {
            return await _context.Set<Entity>().ToListAsync();
        }

        public async Task<List<Entity>> GetAllWithIncludeAsync(List<String> properties)
        {
            var query =  _context.Set<Entity>().AsQueryable();

            foreach (var property in properties)
            {
               query = query.Include(property);
            }

            return await query.ToListAsync();
        }

        public async Task<Entity> GetByIdAsync (int id)
        {
            var item = await _context.Set<Entity>().FindAsync(id);

            if (item == null)
            {
                throw new KeyNotFoundException($"El ID: {id}, no fue encontrado.");
            }

            return item;
        }

    }
}
