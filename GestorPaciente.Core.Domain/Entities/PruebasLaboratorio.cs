

using GestorPaciente.Core.Domain.Common;

namespace GestorPaciente.Core.Domain.Entities
{
    public class PruebasLaboratorio : AuditableBaseEntity
    {
        public int Id { get; set; } 
        public string Nombre { get; set; }

        // NAVIGATION PROPERTIES

        public ResultadosLaboratorio? ResultadosLaboratorio { get; set; }


    }
}
