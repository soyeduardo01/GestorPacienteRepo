

using GestorPaciente.Core.Domain.Common;

namespace GestorPaciente.Core.Domain.Entities
{
    public class Medicos : AuditableBaseEntity
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }  
        public string Telefono { get; set; }
        public string FotoMedico { get; set; }

        // NAVIGATION PROPERTIES
        public ICollection<Citas>? Citas { get; set; }
    }
}
