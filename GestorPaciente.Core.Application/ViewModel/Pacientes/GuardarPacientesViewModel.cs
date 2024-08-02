using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPaciente.Core.Application.ViewModel.Pacientes
{
    public class GuardarPacientesViewModel
    {
        [Required(ErrorMessage = "Se debe ingresar la Cédula.")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "Se debe ingresar el Nombre.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Se debe ingresar el Apellido.")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Se debe ingresar el Teléfono.")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Se debe ingresar la Dirección.")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Se debe ingresar la Fecha de Nacimiento.")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "Se debe verificar si la persona es fumadora.")]
        public bool Fumador { get; set; }

        [Required(ErrorMessage = "\"Se debe verificar si la persona es alérgica.")]
        public bool Alergico { get; set; }

        [Required(ErrorMessage = "Se debe ingresar la Foto del Paciente.")]
        public string FotoPaciente { get; set; }
    }
}
