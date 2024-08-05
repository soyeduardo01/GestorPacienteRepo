
using System.ComponentModel.DataAnnotations;

namespace GestorPaciente.Core.Application.ViewModel.Citas
{
    public class GuardarCitasViewModel
    {
        public int Id { get; set; }
        public string Estatus { get; set; }

        [Required(ErrorMessage = "Se debe ingresar la Fecha de la cita.")]
        public DateTime FechaCita { get; set; }

        [Required(ErrorMessage = "Se debe ingresar la Causa de la cita.")]
        public string CausaCita { get; set; }

        [Required(ErrorMessage = "Se debe ingresar la Cédula del paciente.")]
        public string CedulaPaciente { get; set; }

        [Required(ErrorMessage = "Se debe ingresar la Cédula del Médico.")]
        public string CedulaMedico { get; set; }
    }
}
