using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCorePeliculas.Migrations
{
    public partial class NoPodemosBorrarCineConSalasDeCine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalasDeCine_Cines_ElCine",
                table: "SalasDeCine");

            migrationBuilder.AddForeignKey(
                name: "FK_SalasDeCine_Cines_ElCine",
                table: "SalasDeCine",
                column: "ElCine",
                principalTable: "Cines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalasDeCine_Cines_ElCine",
                table: "SalasDeCine");

            migrationBuilder.AddForeignKey(
                name: "FK_SalasDeCine_Cines_ElCine",
                table: "SalasDeCine",
                column: "ElCine",
                principalTable: "Cines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
