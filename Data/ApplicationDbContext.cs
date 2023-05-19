using DemoJuntaViernes.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoJuntaViernes.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public virtual DbSet<Alumno> Alumnos { get; set; }
    }
}
