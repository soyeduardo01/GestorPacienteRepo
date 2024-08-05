using GestorPaciente.Core.Application.Interfaces.Repositories;
using GestorPaciente.Core.Application.Interfaces.Services;
using GestorPaciente.Core.Application.ViewModel.Citas;
using GestorPaciente.Core.Domain.Entities;

namespace GestorPaciente.Core.Application.Services
{
    public class CitasService : ICitasService
    {
        private readonly ICitasRepository _citasRepository;

        public CitasService (ICitasRepository citasRepository)
        {
            _citasRepository = citasRepository;
        }

        public async Task Agregar(GuardarCitasViewModel vm)
        {
            Citas citas = new()
            {
                Estatus = vm.Estatus,
                FechaCita = vm.FechaCita,
                CausaCita = vm.CausaCita,
                CedulaPaciente = vm.CedulaPaciente,
                CedulaMedico = vm.CedulaMedico
            };

            await _citasRepository.AddAsync(citas);
        }

        public async Task Actualizar(GuardarCitasViewModel vm)
        {
            Citas citas = new()
            {
                Estatus = vm.Estatus,
                FechaCita = vm.FechaCita,
                CausaCita = vm.CausaCita,
                CedulaPaciente = vm.CedulaPaciente,
                CedulaMedico = vm.CedulaMedico
            };

            await _citasRepository.UpdateAsync(citas);

        }

        public async Task Eliminar (int id)
        {
            var citas = await _citasRepository.GetByIdAsync(id);
            await _citasRepository.DeleteAsync(citas);

        }

        public async Task<List<CitasViewModel>> GetAllViewModel()
        {
            var citasList = await _citasRepository.GetAllAsync();

            return citasList.Select(citas => new CitasViewModel ()
            {
                Estatus = citas.Estatus,
                FechaCita = citas.FechaCita,
                CausaCita = citas.CausaCita

            }).ToList();
        }

        public async Task<GuardarCitasViewModel> GetByIdGuardarViewModel(int id)
        {
            var citas = await _citasRepository.GetByIdAsync(id);
            
            GuardarCitasViewModel vm = new GuardarCitasViewModel() { 
                Estatus = citas.Estatus,
                FechaCita = citas.FechaCita,
                CausaCita = citas.CausaCita,
                CedulaPaciente = citas.CedulaPaciente,
                CedulaMedico = citas.CedulaMedico
            };

            return vm;
        }

    }
}
