using GestorPaciente.Core.Application.Interfaces.Repositories;
using GestorPaciente.Core.Application.Interfaces.Services;
using GestorPaciente.Core.Application.ViewModel.ResultadosLaboratorio;
using GestorPaciente.Core.Domain.Entities;
using System.Security.Cryptography.X509Certificates;


namespace GestorPaciente.Core.Application.Services
{
    public class ResultadosLaboratorioService : IResultadosLaboratorioService
    {
        private readonly IResultadosLaboratorioRepository _resultadosLaboratorioRepository;

        public ResultadosLaboratorioService (IResultadosLaboratorioRepository resultadosLaboratorioRepository)
        {
            _resultadosLaboratorioRepository = resultadosLaboratorioRepository;
        }

        public async Task Agregar(GuardarResultadosLaboratorioViewModel vm)
        {
            ResultadosLaboratorio resultadosLaboratorio = new()
            {
                Estatus = vm.Estatus,
                CedulaPaciente = vm.CedulaPaciente,
                Id_PruebasLaboratorio = vm.Id_PruebasLaboratorio,
            };

            await _resultadosLaboratorioRepository.AddAsync(resultadosLaboratorio);
        }

        public async Task Actualizar(GuardarResultadosLaboratorioViewModel vm)
        {
            ResultadosLaboratorio resultadosLaboratorio = new()
            {
                Estatus = vm.Estatus,
                CedulaPaciente = vm.CedulaPaciente,
                Id_PruebasLaboratorio = vm.Id_PruebasLaboratorio,
            };

            await _resultadosLaboratorioRepository.UpdateAsync(resultadosLaboratorio);
        }

        public async Task Eliminar(int id)
        {
            var resultadosLaboratorio = await _resultadosLaboratorioRepository.GetByIdAsync(id);
            await _resultadosLaboratorioRepository.DeleteAsync(resultadosLaboratorio);
        }

        public async Task<List<ResultadosLaboratorioViewModel>> GetAllViewModel()
        {
            var resultadosLaboratorioList = await _resultadosLaboratorioRepository.GetAllAsync();

            return resultadosLaboratorioList.Select(resultadosLaboratorio => new ResultadosLaboratorioViewModel()
            {
                Estatus = resultadosLaboratorio.Estatus,
                CedulaPaciente = resultadosLaboratorio.CedulaPaciente,
                Id_PruebasLaboratorio = resultadosLaboratorio.Id_PruebasLaboratorio

            }).ToList();
        }

        public async Task<GuardarResultadosLaboratorioViewModel> GetByIdGuardarViewModel(int id)
        {
            var resultadosLaboratorio = await _resultadosLaboratorioRepository.GetByIdAsync(id);

            GuardarResultadosLaboratorioViewModel vm = new()
            {
                Estatus = resultadosLaboratorio.Estatus,
                CedulaPaciente = resultadosLaboratorio.CedulaPaciente,
                Id_PruebasLaboratorio = resultadosLaboratorio.Id_PruebasLaboratorio,
            };

            return vm;
        }
    }
}
}
