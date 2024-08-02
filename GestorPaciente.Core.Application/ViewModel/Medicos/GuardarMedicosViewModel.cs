using System.ComponentModel.DataAnnotations;

namespace GestorPaciente.Core.Application.ViewModel.Medicos
{
    public class GuardarMedicosViewModel
    {
        [Required(ErrorMessage = "Se debe ingresar la Cédula.")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "Se debe ingresar el Nombre.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Se debe ingresar el Apellido.")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Se debe ingresar el Correo.")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "Se debe ingresar el Téléfono.")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Se debe ingresar la Foto del Paciente.")]
        public string FotoMedico { get; set; }
    }
}
