using EFCore6DemoUdemyMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore6DemoUdemyMVC
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Persona> Personas { get; set; }
    }
}
