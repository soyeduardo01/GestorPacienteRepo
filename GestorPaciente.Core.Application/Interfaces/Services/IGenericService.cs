

namespace GestorPaciente.Core.Application.Interfaces.Services
{
    public interface IGenericService<ViewModel, GuardarViewModel>
        where ViewModel : class
        where GuardarViewModel : class
    {
        Task Agregar(GuardarViewModel vm);
        Task Actualizar(GuardarViewModel vm);
        Task Eliminar(int id);
        Task<List<ViewModel>> GetAllViewModel();
        Task<GuardarViewModel> GetByIdGuardarViewModel(int id);
    }
}
