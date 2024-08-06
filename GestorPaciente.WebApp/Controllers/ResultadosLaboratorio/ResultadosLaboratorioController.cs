using GestorPaciente.Core.Application.Interfaces.Services;
using GestorPaciente.Core.Application.Services;
using GestorPaciente.Core.Application.ViewModel.PruebasLaboratorio;
using GestorPaciente.Core.Application.ViewModel.ResultadosLaboratorio;
using Microsoft.AspNetCore.Mvc;

namespace GestorPaciente.WebApp.Controllers.ResultadosLaboratorio
{
    public class ResultadosLaboratorioController : Controller
    {
        private readonly IResultadosLaboratorioService _resultadosLaboratorioService;

        public ResultadosLaboratorioController (IResultadosLaboratorioService resultadosLaboratorioService)
        {
            _resultadosLaboratorioService = resultadosLaboratorioService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _resultadosLaboratorioService.GetAllViewModel());
        }

        public IActionResult Agregar()
        {
            return View("GuardarResultadosLaboratorio", new GuardarResultadosLaboratorioViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Agregar(GuardarResultadosLaboratorioViewModel vm)
        {
            if (ModelState.IsValid)
            {
                return View("GuardarResultadosLaboratorio", vm);
            }

            await _resultadosLaboratorioService.Agregar(vm);
            return RedirectToRoute(new { controller = "ResultadosLaboratorio", action = "Index" });
        }

        public async Task<IActionResult> Actualizar(int id)
        {
            return View("GuardarResultadosLaboratorio", await _resultadosLaboratorioService.GetByIdGuardarViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Actualizar(GuardarResultadosLaboratorioViewModel vm)
        {
            if (ModelState.IsValid)
            {
                return View("GuardarResultadosLaboratorio", vm);
            }

            await _resultadosLaboratorioService.Actualizar(vm);
            return RedirectToRoute(new { controller = "ResultadosLaboratorio", action = "Index" });
        }

        public async Task<IActionResult> Eliminar(int id)
        {
            return View(await _resultadosLaboratorioService.GetByIdGuardarViewModel(id));
        }

        public async Task<IActionResult> EliminarPorPost(int id)
        {
            await _resultadosLaboratorioService.Eliminar(id);
            return RedirectToRoute(new { controller = "ResultadosLaboratorio", action = "Index" });

        }
    }
}
