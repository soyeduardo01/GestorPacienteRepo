using GestorPaciente.Core.Application.Interfaces.Services;
using GestorPaciente.Core.Application.ViewModel.Citas;
using Microsoft.AspNetCore.Mvc;

namespace GestorPaciente.WebApp.Controllers.Citas
{
    public class CitasController : Controller
    {
        private readonly ICitasService _citasService;

        public CitasController(ICitasService citasService) { 
            _citasService = citasService;
        }
        public async Task<IActionResult> Index()
        {
            return View("GuardarPacientes", await _citasService.GetAllViewModel());
        }

        public IActionResult Agregar()
        {
            return View("GuadarCitas", new GuardarCitasViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Agregar(GuardarCitasViewModel vm)
        {
            if(ModelState.IsValid)
            {
                return View("GuadarCitas", vm);
            }
            await _citasService.Agregar(vm);
            return RedirectToRoute(new { controller = "Citas", action = "Index" });
        }

        public async Task<IActionResult> Actualizar(int id)
        {
            return View("GuadarCitas", await _citasService.GetByIdGuardarViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Actualizar(GuardarCitasViewModel vm)
        {
            if (ModelState.IsValid)
            {
                return View("GuadarCitas", vm);
            }
            await _citasService.Actualizar(vm);
            return RedirectToRoute(new { controller = "Citas", action = "Index" });
        }

        public async Task<IActionResult> Eliminar(int id)
        {
            return View(await _citasService.GetByIdGuardarViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> EliminarPorPost(int id)
        {
            await _citasService.Eliminar(id);
            return RedirectToRoute(new { controller = "Citas", action = "Index" });
        }
    }
}
