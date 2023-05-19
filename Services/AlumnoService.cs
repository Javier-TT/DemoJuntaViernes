using DemoJuntaViernes.Data;
using DemoJuntaViernes.Data.Repositorios;
using DemoJuntaViernes.Helpers;
using DemoJuntaViernes.IServices;
using DemoJuntaViernes.Models;
using DemoJuntaViernes.Models.ViewModels;

namespace DemoJuntaViernes.Services
{
    public class AlumnoService : IAlumnoService
    {
        private readonly RepositoryGeneric<Alumno> _repositoryGeneric;

        public AlumnoService(ApplicationDbContext context)
        {
            _repositoryGeneric = new RepositoryGeneric<Alumno>(context);
        }

        public async Task<ResponseHelper> CreateAlumno(AlumnoViewModel viewModel)
        {
            ResponseHelper response = new();


            //Validar si el nombre viene vacio no guardar y retornar el objeto response con mensaje de: falta nombre
            //Validar si existe un alumno con el mismo correo, agregar propiedad a la clase, si existe retornar el objeto response con mensaje de: email repetido
            //validar si existe un alumno menos a 18, retornar el objeto response con mensaje de: menor de edad

            Alumno alumno = new()
            {
                Nombre = viewModel.Nombre,
                Apellido = viewModel.Apellido,
                Edad = viewModel.Edad,
            };

            if (await _repositoryGeneric.Create(alumno) > 0)
            {
                response.Message = "Alumno creado correctamente";
                response.IsSuccess = true;
                return response;
            }

            response.Message = "Ha ocurrido un error al crear al Alumno";
            response.IsSuccess = false;

            return response;
        }

        public async Task<List<AlumnoViewModel>> GetAlumnos()
        {
            List<AlumnoViewModel> alumnoViewModels = new();

            List<Alumno> alumnos = await _repositoryGeneric.GetAll();

            foreach (var alumno in alumnos)
            {
                alumnoViewModels.Add(new AlumnoViewModel()
                {
                    Nombre = alumno.Nombre,
                    Apellido= alumno.Apellido,
                    Edad = alumno.Edad,
                });
            }

            return alumnoViewModels;
        }
    }
}
