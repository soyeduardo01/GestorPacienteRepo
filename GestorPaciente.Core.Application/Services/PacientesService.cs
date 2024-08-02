
using GestorPaciente.Core.Application.Interfaces.Repositories;
using GestorPaciente.Core.Application.ViewModel.Pacientes;
using GestorPaciente.Core.Domain.Entities;

namespace GestorPaciente.Core.Application.Services
{
    public class PacientesService
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
    }
}
