using GestorPaciente.Core.Application.Interfaces.Repositories;
using GestorPaciente.Core.Domain.Entities;
using GestorPaciente.Infrastructure.Persistence.Contexts;


namespace GestorPaciente.Infrastructure.Persistence.Repositories
{
    public class CitasRepository : GenericRepository<Citas>, ICitasRepository
    {
        private GestorPacienteContext _context;

        public CitasRepository(GestorPacienteContext context) : base(context)
        {
            _context = context;
        }
    }
}
