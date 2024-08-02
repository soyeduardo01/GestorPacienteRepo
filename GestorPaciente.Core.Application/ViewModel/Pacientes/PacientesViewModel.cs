

using GestorPaciente.Core.Domain.Entities;

namespace GestorPaciente.Core.Application.ViewModel.Pacientes
{
    public class PacientesViewModel
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool Fumador { get; set; }
        public bool Alergico { get; set; }
        public string FotoPaciente { get; set; }
    }
}
