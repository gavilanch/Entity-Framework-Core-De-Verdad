using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCorePeliculas.Migrations
{
    public partial class EjemploConversion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TipoSalaDeCine",
                table: "SalasDeCine",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "DosDimensiones",
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.UpdateData(
                table: "SalasDeCine",
                keyColumn: "Id",
                keyValue: 1,
                column: "TipoSalaDeCine",
                value: "DosDimensiones");

            migrationBuilder.UpdateData(
                table: "SalasDeCine",
                keyColumn: "Id",
                keyValue: 2,
                column: "TipoSalaDeCine",
                value: "TresDimensiones");

            migrationBuilder.UpdateData(
                table: "SalasDeCine",
                keyColumn: "Id",
                keyValue: 3,
                column: "TipoSalaDeCine",
                value: "DosDimensiones");

            migrationBuilder.UpdateData(
                table: "SalasDeCine",
                keyColumn: "Id",
                keyValue: 4,
                column: "TipoSalaDeCine",
                value: "TresDimensiones");

            migrationBuilder.UpdateData(
                table: "SalasDeCine",
                keyColumn: "Id",
                keyValue: 5,
                column: "TipoSalaDeCine",
                value: "DosDimensiones");

            migrationBuilder.UpdateData(
                table: "SalasDeCine",
                keyColumn: "Id",
                keyValue: 6,
                column: "TipoSalaDeCine",
                value: "TresDimensiones");

            migrationBuilder.UpdateData(
                table: "SalasDeCine",
                keyColumn: "Id",
                keyValue: 7,
                column: "TipoSalaDeCine",
                value: "CXC");

            migrationBuilder.UpdateData(
                table: "SalasDeCine",
                keyColumn: "Id",
                keyValue: 8,
                column: "TipoSalaDeCine",
                value: "DosDimensiones");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TipoSalaDeCine",
                table: "SalasDeCine",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "DosDimensiones");

            migrationBuilder.UpdateData(
                table: "SalasDeCine",
                keyColumn: "Id",
                keyValue: 1,
                column: "TipoSalaDeCine",
                value: 1);

            migrationBuilder.UpdateData(
                table: "SalasDeCine",
                keyColumn: "Id",
                keyValue: 2,
                column: "TipoSalaDeCine",
                value: 2);

            migrationBuilder.UpdateData(
                table: "SalasDeCine",
                keyColumn: "Id",
                keyValue: 3,
                column: "TipoSalaDeCine",
                value: 1);

            migrationBuilder.UpdateData(
                table: "SalasDeCine",
                keyColumn: "Id",
                keyValue: 4,
                column: "TipoSalaDeCine",
                value: 2);

            migrationBuilder.UpdateData(
                table: "SalasDeCine",
                keyColumn: "Id",
                keyValue: 5,
                column: "TipoSalaDeCine",
                value: 1);

            migrationBuilder.UpdateData(
                table: "SalasDeCine",
                keyColumn: "Id",
                keyValue: 6,
                column: "TipoSalaDeCine",
                value: 2);

            migrationBuilder.UpdateData(
                table: "SalasDeCine",
                keyColumn: "Id",
                keyValue: 7,
                column: "TipoSalaDeCine",
                value: 3);

            migrationBuilder.UpdateData(
                table: "SalasDeCine",
                keyColumn: "Id",
                keyValue: 8,
                column: "TipoSalaDeCine",
                value: 1);
        }
    }
}
