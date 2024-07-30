using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPaciente.Core.Domain.Entities
{
    public class Citas
    {
        public int Id { get; set; }
        public string Estatus { get; set; }
        public DateTime FechaCita { get; set; }
        public string CausaCita { get; set; }

    }
}
