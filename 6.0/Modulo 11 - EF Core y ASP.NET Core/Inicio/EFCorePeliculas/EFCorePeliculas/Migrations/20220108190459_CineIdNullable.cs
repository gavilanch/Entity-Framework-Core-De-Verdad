using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCorePeliculas.Migrations
{
    public partial class CineIdNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CinesOfertas_Cines_CineId",
                table: "CinesOfertas");

            migrationBuilder.DropIndex(
                name: "IX_CinesOfertas_CineId",
                table: "CinesOfertas");

            migrationBuilder.AlterColumn<int>(
                name: "CineId",
                table: "CinesOfertas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "CinesOfertas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaFin", "FechaInicio" },
                values: new object[] { new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 1, 8, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CinesOfertas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaFin", "FechaInicio" },
                values: new object[] { new DateTime(2022, 1, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 1, 8, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaEstreno",
                value: new DateTime(2022, 1, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.CreateIndex(
                name: "IX_CinesOfertas_CineId",
                table: "CinesOfertas",
                column: "CineId",
                unique: true,
                filter: "[CineId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_CinesOfertas_Cines_CineId",
                table: "CinesOfertas",
                column: "CineId",
                principalTable: "Cines",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CinesOfertas_Cines_CineId",
                table: "CinesOfertas");

            migrationBuilder.DropIndex(
                name: "IX_CinesOfertas_CineId",
                table: "CinesOfertas");

            migrationBuilder.AlterColumn<int>(
                name: "CineId",
                table: "CinesOfertas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "CinesOfertas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaFin", "FechaInicio" },
                values: new object[] { new DateTime(2022, 1, 14, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CinesOfertas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaFin", "FechaInicio" },
                values: new object[] { new DateTime(2022, 1, 12, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaEstreno",
                value: new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.CreateIndex(
                name: "IX_CinesOfertas_CineId",
                table: "CinesOfertas",
                column: "CineId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CinesOfertas_Cines_CineId",
                table: "CinesOfertas",
                column: "CineId",
                principalTable: "Cines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
