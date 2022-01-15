using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCorePeliculas.Migrations
{
    public partial class EjemploOwned : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Calle",
                table: "Cines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pais",
                table: "Cines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Provincia",
                table: "Cines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillingAddress_Calle",
                table: "Actores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillingAddress_Pais",
                table: "Actores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillingAddress_Provincia",
                table: "Actores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Calle",
                table: "Actores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pais",
                table: "Actores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Provincia",
                table: "Actores",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Calle",
                table: "Cines");

            migrationBuilder.DropColumn(
                name: "Pais",
                table: "Cines");

            migrationBuilder.DropColumn(
                name: "Provincia",
                table: "Cines");

            migrationBuilder.DropColumn(
                name: "BillingAddress_Calle",
                table: "Actores");

            migrationBuilder.DropColumn(
                name: "BillingAddress_Pais",
                table: "Actores");

            migrationBuilder.DropColumn(
                name: "BillingAddress_Provincia",
                table: "Actores");

            migrationBuilder.DropColumn(
                name: "Calle",
                table: "Actores");

            migrationBuilder.DropColumn(
                name: "Pais",
                table: "Actores");

            migrationBuilder.DropColumn(
                name: "Provincia",
                table: "Actores");
        }
    }
}
