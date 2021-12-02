using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEFCore6Udemy
{
    public class ApplicationDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(
                "Server=LAPTOP-4KBFRF57;Database=DemoEFCore6Udemy;Integrated Security=True");
        }

        public DbSet<Persona> Personas { get; set; }
    }
}
