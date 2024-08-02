using GestorPaciente.Core.Application.Interfaces.Repositories;
using GestorPaciente.Core.Domain.Entities;
using GestorPaciente.Infrastructure.Persistence.Contexts;

namespace GestorPaciente.Infrastructure.Persistence.Repositories
{
    public class MedicosRepositoy : GenericRepository<Medicos>, IMedicosRepository
    {
        private readonly GestorPacienteContext _context;

        public MedicosRepositoy(GestorPacienteContext context) : base(context)
        {
            _context = context;
        }
    }
}
