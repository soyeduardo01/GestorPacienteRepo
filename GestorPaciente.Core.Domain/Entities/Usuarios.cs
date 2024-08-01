
using GestorPaciente.Core.Domain.Common;

namespace GestorPaciente.Core.Domain.Entities
{
    public class Usuarios : AuditableBaseEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public string TipoUsuario { get; set; }
    }
}
