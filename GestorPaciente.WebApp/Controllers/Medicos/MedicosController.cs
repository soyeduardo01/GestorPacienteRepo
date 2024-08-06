using GestorPaciente.Core.Application.Interfaces.Services;
using GestorPaciente.Core.Application.ViewModel.Medicos;
using Microsoft.AspNetCore.Mvc;

namespace GestorPaciente.WebApp.Controllers.Medicos
{
    public class MedicosController : Controller
    {
        private readonly  IMedicosService _medicosService;

        public MedicosController (IMedicosService medicosService)
        {
            _medicosService = medicosService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _medicosService.GetAllViewModel());
        }

        public IActionResult Agregar()
        {
            return View("GuardarMedicos", new GuardarMedicosViewModel());
;       }

        [HttpPost]
        public async Task<IActionResult> Agregar(GuardarMedicosViewModel vm)
        {
            if(ModelState.IsValid) {
                return View(vm);
            }

            await _medicosService.Agregar(vm);
            return RedirectToRoute(new { controller = "Medicos", action = "Index"});

        } 


        public async Task<IActionResult> Actualizar(int id)
        {
            return View("GuardarMedicos", await _medicosService.GetByIdGuardarViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Actualizar(GuardarMedicosViewModel vm)
        {
            if(ModelState.IsValid)
            {
                return View("GuardarPacientes", vm);
            }
            await _medicosService.Actualizar(vm);
            return RedirectToRoute(new { controller = "Medicos", action = "Index" });
        }


        public async Task<IActionResult> Eliminar(int id)
        {
            return View(await _medicosService.GetByIdGuardarViewModel(id));

        }


        public async Task<IActionResult> EliminarPorPost(int id)
        {
            await _medicosService.Eliminar(id);
            return RedirectToRoute(new { controller = "Medicos", action = "Index" });

        }

    }
}
