using GestorPaciente.Core.Application.Interfaces.Repositories;
using GestorPaciente.Core.Application.Interfaces.Services;
using GestorPaciente.Core.Application.ViewModel.PruebasLaboratorio;
using GestorPaciente.Core.Domain.Entities;

namespace GestorPaciente.Core.Application.Services
{
    public class PruebasLaboratorioService : IPruebasLaboratorioService
    {
        private readonly IPruebasLaboratorioRepository _pruebasLaboratorioRepository;

        public PruebasLaboratorioService(IPruebasLaboratorioRepository pruebasLaboratorioRepository)
        {
            _pruebasLaboratorioRepository = pruebasLaboratorioRepository;
        }

        public async Task Agregar(GuardarPruebasLaboratorioViewModel vm)
        {
            PruebasLaboratorio pruebasLaboratorio = new()
            {
                Nombre = vm.Nombre,
            };

            await _pruebasLaboratorioRepository.AddAsync(pruebasLaboratorio);
        }

        public async Task Actualizar(GuardarPruebasLaboratorioViewModel vm)
        {
            PruebasLaboratorio pruebasLaboratorio = new()
            {
                Nombre = vm.Nombre,
            };

            await _pruebasLaboratorioRepository.UpdateAsync(pruebasLaboratorio);
        }

        public async Task Eliminar(int id)
        {
            var pruebasLaboratorio = await _pruebasLaboratorioRepository.GetByIdAsync(id);
            await _pruebasLaboratorioRepository.DeleteAsync(pruebasLaboratorio);
        }

        public async Task<List<PruebasLaboratorioViewModel>> GetAllViewModel()
        {
            var pruebasLaboratorioList = await _pruebasLaboratorioRepository.GetAllAsync();

            return pruebasLaboratorioList.Select(pruebasLaboratorio => new PruebasLaboratorioViewModel(){
                Nombre = pruebasLaboratorio.Nombre
            }).ToList();
        }

        public async Task<GuardarPruebasLaboratorioViewModel> GetByIdGuardarViewModel(int id)
        {
            var pruebasLaboratorio = await _pruebasLaboratorioRepository.GetByIdAsync(id);

            GuardarPruebasLaboratorioViewModel vm = new()
            {
                Nombre = pruebasLaboratorio.Nombre
            };

            return vm;
        }


    }
}
