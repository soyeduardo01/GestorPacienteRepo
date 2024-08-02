
using System.ComponentModel.DataAnnotations;

namespace GestorPaciente.Core.Application.ViewModel.PruebasLaboratorio
{
    public class GuardarPruebasLaboratorioViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Se debe ingresar el Nombre de la prueba de laboratorio.")]
        public string Nombre { get; set; }
    }
}
