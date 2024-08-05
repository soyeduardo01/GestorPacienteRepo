using GestorPaciente.Core.Application.ViewModel.Pacientes;

namespace GestorPaciente.Core.Application.Interfaces.Services
{
    public interface IPacientesService : IGenericService<PacientesViewModel, GuardarPacientesViewModel>
    {
    }
}
