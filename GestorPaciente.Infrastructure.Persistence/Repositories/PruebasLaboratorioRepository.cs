

using GestorPaciente.Core.Application.Interfaces.Repositories;
using GestorPaciente.Core.Domain.Entities;
using GestorPaciente.Infrastructure.Persistence.Contexts;

namespace GestorPaciente.Infrastructure.Persistence.Repositories
{
    public class PruebasLaboratorioRepository : GenericRepository<PruebasLaboratorio>, IPruebasLaboratorioRepository
    {
        private readonly GestorPacienteContext _context;

        public PruebasLaboratorioRepository(GestorPacienteContext context) : base(context)
        {
            _context = context; 
        }
    }
}
