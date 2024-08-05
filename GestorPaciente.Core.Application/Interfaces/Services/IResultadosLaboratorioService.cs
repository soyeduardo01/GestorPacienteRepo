using GestorPaciente.Core.Application.ViewModel.ResultadosLaboratorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPaciente.Core.Application.Interfaces.Services
{
    public interface IResultadosLaboratorioService : IGenericService<ResultadosLaboratorioViewModel, GuardarResultadosLaboratorioViewModel>
    {
    }
}
