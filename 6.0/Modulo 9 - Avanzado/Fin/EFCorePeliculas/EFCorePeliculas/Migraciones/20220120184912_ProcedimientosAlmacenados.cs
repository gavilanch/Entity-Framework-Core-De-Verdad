using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCorePeliculas.Migraciones
{
    public partial class ProcedimientosAlmacenados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE Generos_ObtenerPorId
@id int
AS
BEGIN
SET NOCOUNT ON;

SELECT *
FROM Generos
WHERE Identificador = @id;
END");

            migrationBuilder.Sql(@"CREATE PROCEDURE Generos_Insertar
@nombre nvarchar(150),
@id int OUTPUT
AS
BEGIN
SET NOCOUNT ON;

INSERT INTO Generos(Nombre)
VALUES (@nombre);

SELECT @id = SCOPE_IDENTITY();
END");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE [dbo].[Generos_ObtenerPorId]");
            migrationBuilder.Sql("DROP PROCEDURE [dbo].[Generos_Insertar]");

        }
    }
}
