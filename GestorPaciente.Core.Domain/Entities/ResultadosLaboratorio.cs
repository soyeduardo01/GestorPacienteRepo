

using GestorPaciente.Core.Domain.Common;

namespace GestorPaciente.Core.Domain.Entities
{
    public class ResultadosLaboratorio : AuditableBaseEntity
    {
        public string Id { get; set; }
        public string Estatus { get; set;}
        public string CedulaPaciente { get; set; }
        public int Id_PruebasLaboratorio { get; set; }

        // NAVIGATION PROPERTIES

        public Pacientes? Pacientes { get; set; }
        public PruebasLaboratorio? PruebasLaboratorio { get; set; }  
    }
}
