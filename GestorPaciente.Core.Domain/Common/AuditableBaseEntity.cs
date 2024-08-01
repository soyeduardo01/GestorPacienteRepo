using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPaciente.Core.Domain.Common
{
    public class AuditableBaseEntity
    {
        public string CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string? UltimaModificacionPor { get; set; }
        public DateTime? UltimaFechaModificacion { get; set; }
    }
}
