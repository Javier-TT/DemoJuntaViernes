using DemoJuntaViernes.IServices;
using DemoJuntaViernes.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DemoJuntaViernes.Controllers
{
    public class AlumnosController : Controller
    {
        private readonly IAlumnoService _alumnoService;
        public AlumnosController(IAlumnoService alumnoService)
        {
            _alumnoService = alumnoService;
        }

        public async Task<IActionResult> Index()
        {
            List<AlumnoViewModel> alumnos = await _alumnoService.GetAlumnos();
            return View(alumnos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AlumnoViewModel viewModel)
        {
            await _alumnoService.CreateAlumno(viewModel);
            return RedirectToAction(nameof(Index));
        }
    }
}
