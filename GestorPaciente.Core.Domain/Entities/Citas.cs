
using GestorPaciente.Core.Domain.Common;

namespace GestorPaciente.Core.Domain.Entities
{
    public class Citas : AuditableBaseEntity
    {
        public int Id { get; set; }
        public string Estatus { get; set; }
        public DateTime FechaCita { get; set; }
        public string CausaCita { get; set; }

        public string CedulaPaciente { get; set; }
        public string CedulaMedico { get; set; }

        // NAVIGATION PROPERTIES

        public Pacientes Pacientes { get; set; }    
        public Medicos Medicos { get; set; }

    }
}
