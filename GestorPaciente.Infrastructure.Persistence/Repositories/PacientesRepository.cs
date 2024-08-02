

using GestorPaciente.Core.Application.Interfaces.Repositories;
using GestorPaciente.Core.Domain.Entities;
using GestorPaciente.Infrastructure.Persistence.Contexts;

namespace GestorPaciente.Infrastructure.Persistence.Repositories
{
    public class PacientesRepository : GenericRepository<Pacientes>, IPacientesRepository
    {
        private readonly GestorPacienteContext _context;

        public PacientesRepository(GestorPacienteContext context) : base(context)
        { 
            _context = context;
        }
    }
}
