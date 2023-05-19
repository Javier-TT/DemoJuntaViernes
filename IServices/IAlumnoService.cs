using DemoJuntaViernes.Helpers;
using DemoJuntaViernes.Models.ViewModels;

namespace DemoJuntaViernes.IServices
{
    public interface IAlumnoService
    {
        Task<List<AlumnoViewModel>> GetAlumnos();
        Task<ResponseHelper> CreateAlumno(AlumnoViewModel viewModel);
    }
}
