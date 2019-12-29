using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ConsoleApp_Modulo3.CodigoVideos
{
    public class QueriesArbitrarios
    {
        public void Codigo()
        {
            using (var context = new ApplicationDbContext())
            {
                context.Database.ExecuteSqlRaw("Truncate table dbo.Students");
            }

            using (var context = new ApplicationDbContext())
            {
                var students = context.Estudiantes.FromSqlRaw(@"SELECT TOP 50 PERCENT Id, FechaNacimiento 
             
                FROM Estudiantes ORDER BY FechaNacimiento DESC").IgnoreQueryFilters()
                .Select(x => new { x.Id, x.FechaNacimiento }).ToList();
            }

            var Id = 3;

            using (var context = new ApplicationDbContext())
            {
                var parameter = new SqlParameter("@Id", Id);
                var student = context.Estudiantes.FromSqlRaw("SELECT * from Students where Id = @Id",
                new SqlParameter[] { parameter }).FirstOrDefault();
            }

            using (var context = new ApplicationDbContext())
            {
                var student = context.Estudiantes.
                FromSqlRaw($"SELECT * from Students where Id = {Id}").FirstOrDefault();
            }

        }
    }
}
