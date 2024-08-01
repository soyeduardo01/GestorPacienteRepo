using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPaciente.Core.Application.Interfaces.Repositories
{
    public interface IGenericRepository<Entity>
    {
        Task<Entity> AddAsync(Entity entity);
        Task UpdateAsync(Entity entity);
        Task DeleteAsync(Entity entity);
        Task<List<Entity>> GetAllAsync(Entity entity);
        Task<List<Entity>> GetAllWithIncludeAsync(List<String> properties);
        Task<Entity> GetByIdAsync(int id);
    }
}
