using GestorPaciente.Core.Application.Interfaces.Repositories;
using GestorPaciente.Core.Application.Interfaces.Services;
using GestorPaciente.Core.Application.ViewModel.Medicos;
using GestorPaciente.Core.Domain.Entities;

namespace GestorPaciente.Core.Application.Services
{
    public class MedicosService : IMedicosService
    {
        private readonly IMedicosRepository _medicosRepository;

        public MedicosService (IMedicosRepository medicosRepository)
        {
            _medicosRepository = medicosRepository;
        }   

        public async Task Agregar(GuardarMedicosViewModel vm)
        {
            Medicos medicos = new()
            {
               Cedula = vm.Cedula,
               Nombre = vm.Nombre,
               Apellido = vm.Apellido,
               Correo = vm.Correo,
               Telefono = vm.Telefono,
               FotoMedico = vm.FotoMedico,
            };
            
            await _medicosRepository.AddAsync(medicos);
        }

        public async Task Actualizar(GuardarMedicosViewModel vm)
        {
            Medicos medicos = new()
            {
                Cedula = vm.Cedula,
                Nombre = vm.Nombre,
                Apellido = vm.Apellido,
                Correo = vm.Correo,
                Telefono = vm.Telefono,
                FotoMedico = vm.FotoMedico,
            };

            await _medicosRepository.UpdateAsync(medicos);
        }

        public async Task Eliminar(int id)
        {
           var medico = await _medicosRepository.GetByIdAsync(id);
           await _medicosRepository.DeleteAsync(medico);
        }

        public async Task<List<MedicosViewModel>> GetAllViewModel()
        {
            var medicosList = await _medicosRepository.GetAllAsync();

            return medicosList.Select(medicos => new MedicosViewModel() {
                Cedula = medicos.Cedula,
                Nombre = medicos.Nombre,
                Apellido = medicos.Apellido,
                Correo = medicos.Correo,
                Telefono = medicos.Telefono,
                FotoMedico = medicos.FotoMedico,

            }).ToList();       
        }

        public async Task<GuardarMedicosViewModel> GetByIdGuardarViewModel(int id)
        {
            var medico = await _medicosRepository.GetByIdAsync (id);

            GuardarMedicosViewModel vm = new()
            {
                Cedula = medico.Cedula,
                Nombre = medico.Nombre,
                Apellido = medico.Apellido,
                Correo = medico.Correo,
                Telefono = medico.Telefono,
                FotoMedico = medico.FotoMedico,
            };

            return vm;

        }


    }
}
