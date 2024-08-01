

using GestorPaciente.Core.Domain.Common;

namespace GestorPaciente.Core.Domain.Entities
{
    public class Pacientes : AuditableBaseEntity
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

        // NAVIGATIONS PROPERTIES
        public ICollection<ResultadosLaboratorio>? ResultadosLaboratorio { get; set; }
        public ICollection<Citas>? Citas { get; set; }
    }
}
