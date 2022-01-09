using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCorePeliculas.Migrations
{
    public partial class VistaConteoPeliculas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
CREATE VIEW [dbo].[PeliculasConConteos]
AS
Select Id, Titulo,
(Select count(*)
from GeneroPelicula
WHERE PeliculasId = Peliculas.Id) as CantidadGeneros,
(Select count(distinct CineId)
FROM PeliculaSalaDeCine
INNER JOIN SalasDeCine
ON SalasDeCine.Id = PeliculaSalaDeCine.SalasDeCineId
WHERE PeliculasId = Peliculas.Id) as CantidadCines,
(
Select count(*)
FROM PeliculasActores
where PeliculaId = Peliculas.Id) as CantidadActores
FROM Peliculas
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW [dbo].[PeliculasConConteos]");
        }
    }
}
