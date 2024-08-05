using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPaciente.Core.Application.ViewModel.ResultadosLaboratorio
{
    public class ResultadosLaboratorioViewModel
    {
        public string Id { get; set; }
        public string Estatus { get; set; }
        public string CedulaPaciente { get; set; }
        public int Id_PruebasLaboratorio { get; set; }

    }
}
