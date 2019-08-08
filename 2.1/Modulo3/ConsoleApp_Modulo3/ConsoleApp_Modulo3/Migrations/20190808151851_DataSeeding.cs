using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleApp_Modulo3.Migrations
{
    public partial class DataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Estudiantes",
                columns: new[] { "Id", "EstaBorrado", "FechaNacimiento", "Nombre" },
                values: new object[] { 7, false, new DateTime(1990, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert Seed" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Estudiantes",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
