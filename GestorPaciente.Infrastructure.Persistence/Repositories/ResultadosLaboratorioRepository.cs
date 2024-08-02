using GestorPaciente.Core.Application.Interfaces.Repositories;
using GestorPaciente.Core.Domain.Entities;
using GestorPaciente.Infrastructure.Persistence.Contexts;

namespace GestorPaciente.Infrastructure.Persistence.Repositories
{
    public class ResultadosLaboratorioRepository : GenericRepository<ResultadosLaboratorio>, IResultadosLaboratorioRepository
    {
        private readonly GestorPacienteContext _context;    

        public ResultadosLaboratorioRepository(GestorPacienteContext context) : base(context)
        {
            _context = context;
        }
    }
}
