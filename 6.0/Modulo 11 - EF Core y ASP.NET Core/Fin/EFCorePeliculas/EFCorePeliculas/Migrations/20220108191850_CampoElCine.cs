using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCorePeliculas.Migrations
{
    public partial class CampoElCine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalasDeCine_Cines_CineId",
                table: "SalasDeCine");

            migrationBuilder.RenameColumn(
                name: "CineId",
                table: "SalasDeCine",
                newName: "ElCine");

            migrationBuilder.RenameIndex(
                name: "IX_SalasDeCine_CineId",
                table: "SalasDeCine",
                newName: "IX_SalasDeCine_ElCine");

            migrationBuilder.AddForeignKey(
                name: "FK_SalasDeCine_Cines_ElCine",
                table: "SalasDeCine",
                column: "ElCine",
                principalTable: "Cines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalasDeCine_Cines_ElCine",
                table: "SalasDeCine");

            migrationBuilder.RenameColumn(
                name: "ElCine",
                table: "SalasDeCine",
                newName: "CineId");

            migrationBuilder.RenameIndex(
                name: "IX_SalasDeCine_ElCine",
                table: "SalasDeCine",
                newName: "IX_SalasDeCine_CineId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalasDeCine_Cines_CineId",
                table: "SalasDeCine",
                column: "CineId",
                principalTable: "Cines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
