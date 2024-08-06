using GestorPaciente.Core.Application.Interfaces.Services;
using GestorPaciente.Core.Application.ViewModel.PruebasLaboratorio;
using Microsoft.AspNetCore.Mvc;

namespace GestorPaciente.WebApp.Controllers.PruebasLaboratorio
{
    public class PruebasLaboratorioController : Controller
    {
        private readonly IPruebasLaboratorioService _pruebasLaboratorioService;

        public PruebasLaboratorioController(IPruebasLaboratorioService pruebasLaboratorioService)
        {
            _pruebasLaboratorioService = pruebasLaboratorioService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _pruebasLaboratorioService.GetAllViewModel());
        }

        public IActionResult Agregar()
        {
            return View("GuardarPruebasLaboratorio", new GuardarPruebasLaboratorioViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Agregar(GuardarPruebasLaboratorioViewModel vm)
        {
            if (ModelState.IsValid)
            {
                return View("GuardarPruebasLaboratorio", vm);
            }

            await _pruebasLaboratorioService.Agregar(vm);
            return RedirectToRoute(new { controller = "PruebasLaboratorio", action = "Index"});

        }

        public async Task<IActionResult> Actualizar(int id)
        {
            return View("GuardarPruebasLaboratorio", await _pruebasLaboratorioService.GetByIdGuardarViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Actualizar(GuardarPruebasLaboratorioViewModel vm)
        {
            if (ModelState.IsValid)
            {
                return View("GuardarPruebasLaboratorio", vm);
            }

            await _pruebasLaboratorioService.Actualizar(vm);
            return RedirectToRoute(new { controller = "PruebasLaboratorio", action = "Index" });

        }

        public async Task<IActionResult> Eliminar(int id)
        {
            return View(await _pruebasLaboratorioService.GetByIdGuardarViewModel(id));
        }

        public async Task<IActionResult> EliminarPorPost(int id)
        {
            await _pruebasLaboratorioService.Eliminar(id);
            return RedirectToRoute(new { controller = "PruebasLaboratorio", action = "Index" });
            
        }
    }


}
