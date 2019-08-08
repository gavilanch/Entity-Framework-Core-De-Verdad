using ConsoleApp_Modulo7.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp_Modulo7
{
    public class ServicioPersonas
    {
        private readonly ApplicationDbContext _dbContext;

        public ServicioPersonas(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Persona> ObtenerTodas()
        {
            return _dbContext.Personas.ToList();
        }

        public List<Persona> ObtenerPersonasConDirecciones()
        {
            return _dbContext.Personas
                .Include(p => p.Direcciones)
                .ToList();
        }
    }

}
