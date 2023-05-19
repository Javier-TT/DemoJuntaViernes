using System.ComponentModel.DataAnnotations;

namespace DemoJuntaViernes.Models
{
    public class Alumno
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
    }
}
