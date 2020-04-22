using Microsoft.EntityFrameworkCore.Migrations;

namespace EntidadesDePropiedad.Migrations
{
    public partial class DatosEstudiante : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Estudiantes",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { 1, "Felipe" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Estudiantes",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
