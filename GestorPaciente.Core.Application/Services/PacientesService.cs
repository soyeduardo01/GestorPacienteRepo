
using GestorPaciente.Core.Application.Interfaces.Repositories;
using GestorPaciente.Core.Application.Interfaces.Services;
using GestorPaciente.Core.Application.ViewModel.Pacientes;
using GestorPaciente.Core.Domain.Entities;

namespace GestorPaciente.Core.Application.Services
{
    public class PacientesService : IPacientesService
    {
        private readonly IPacientesRepository _pacientesRepository;

        public PacientesService(IPacientesRepository pacientesRepository) 
        { 
            _pacientesRepository = pacientesRepository;
        }

        public async Task Agregar(GuardarPacientesViewModel vm)
        {
            Pacientes pacientes = new()
            {
                Cedula = vm.Cedula,
                Nombre = vm.Nombre,
                Apellido = vm.Apellido,
                Telefono = vm.Telefono,
                Direccion = vm.Direccion,   
                FechaNacimiento = vm.FechaNacimiento,
                Fumador = vm.Fumador,
                Alergico = vm.Alergico,
                FotoPaciente = vm.FotoPaciente
            };

            await _pacientesRepository.AddAsync(pacientes);
        }

        public async Task Actualizar(GuardarPacientesViewModel vm)
        {
            Pacientes pacientes = new()
            {
                Cedula = vm.Cedula,
                Nombre = vm.Nombre,
                Apellido = vm.Apellido,
                Telefono = vm.Telefono,
                Direccion = vm.Direccion,
                FechaNacimiento = vm.FechaNacimiento,
                Fumador = vm.Fumador,
                Alergico = vm.Alergico,
                FotoPaciente = vm.FotoPaciente
            };

            await _pacientesRepository.UpdateAsync(pacientes);
        }

        public async Task Eliminar(int id)
        {
            var paciente = await _pacientesRepository.GetByIdAsync(id);

            await _pacientesRepository.DeleteAsync(paciente);
        }

        public async Task<List<PacientesViewModel>> GetAllViewModel()
        {
            var pacientesList = await _pacientesRepository.GetAllAsync();
            return pacientesList.Select(paciente => new PacientesViewModel()
            {
                Cedula = paciente.Cedula,
                Nombre = paciente.Nombre,
                Apellido = paciente.Apellido,
                Telefono = paciente.Telefono,
                Direccion = paciente.Direccion,
                FechaNacimiento = paciente.FechaNacimiento,
                Fumador = paciente.Fumador,
                Alergico = paciente.Alergico

            }).ToList();
        }

        public async Task<GuardarPacientesViewModel> GetByIdGuardarViewModel(int id)
        {
            var medico = await _pacientesRepository.GetByIdAsync(id);

            GuardarPacientesViewModel vm = new()
            {
                Cedula = medico.Cedula,
                Nombre = medico.Nombre,
                Apellido = medico.Apellido,
                Telefono = medico.Telefono,
                Direccion = medico.Direccion,
                FechaNacimiento = medico.FechaNacimiento,
                Fumador = medico.Fumador,
                Alergico = medico.Alergico
            };
            
            return vm;
        }
    }
}
