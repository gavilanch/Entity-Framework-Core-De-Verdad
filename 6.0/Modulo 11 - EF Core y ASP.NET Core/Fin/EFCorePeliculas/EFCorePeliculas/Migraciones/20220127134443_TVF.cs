using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCorePeliculas.Migraciones
{
    public partial class TVF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql(@"CREATE FUNCTION PeliculaConConteos
(
@peliculaId int
)
RETURNS TABLE 
AS
RETURN 
(
-- Add the SELECT statement with parameter references here
SeLeCt Id, Titulo,
	(Select count(*)
	from GeneroPelicula
	WHERE PeliculasId = Peliculas.Id) as CantidadGeneros,
	(Select count(distinct ElCine)
	FROM PeliculaSalaDeCine
	INNER JOIN SalasDeCine
	ON SalasDeCine.Id = PeliculaSalaDeCine.SalasDeCineId
	WHERE PeliculasId = Peliculas.Id) as CantidadCines,
	(
	Select count(*)
	FROM PeliculasActores
	where PeliculaId = Peliculas.Id) as CantidadActores
	FROM Peliculas
	where Id = @peliculaId
)");

		}

		protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql("DROP FUNCTION [dbo].[PeliculaConConteo]");
		}
    }
}
