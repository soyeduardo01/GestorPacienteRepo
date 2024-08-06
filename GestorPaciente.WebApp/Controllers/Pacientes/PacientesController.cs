using GestorPaciente.Core.Application.Interfaces.Services;
using GestorPaciente.Core.Application.ViewModel.Pacientes;
using Microsoft.AspNetCore.Mvc;

namespace GestorPaciente.WebApp.Controllers.Pacientes
{
    public class PacientesController : Controller
    {
        private readonly IPacientesService _pacientesService;

        public PacientesController(IPacientesService pacientesService)
        {
            _pacientesService = pacientesService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _pacientesService.GetAllViewModel());
        }

        public IActionResult Agregar()
        {
            return View("GuardarPacientes", new GuardarPacientesViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Agregar(GuardarPacientesViewModel vm)
        {
            if (ModelState.IsValid)
            {
                return View("GuardarPacientes", vm);
            }
            await _pacientesService.Agregar(vm);
            return RedirectToRoute(new { controller = "Pacientes", action = "Index" });
        }

        public async Task<IActionResult> Actualizar(int id)
        {
            return View("GuardarPacientes", _pacientesService.GetByIdGuardarViewModel(id));
        }

        public async Task<IActionResult> Actualizar(GuardarPacientesViewModel vm)
        {
            if (ModelState.IsValid)
            {
                return View("GuardarPacientes", vm);
            }

            await _pacientesService.Actualizar(vm);
            return RedirectToRoute(new { controller = "Pacientes", action = "Index" });

        }

        public async Task<IActionResult> Eliminar(int id)
        {
            return View(await _pacientesService.GetByIdGuardarViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> EliminarPorPost(int id)
        {
            await _pacientesService.Eliminar(id);
            return RedirectToRoute(new { controller = "Pacientes", action = "Index" });
        }
    }
}
