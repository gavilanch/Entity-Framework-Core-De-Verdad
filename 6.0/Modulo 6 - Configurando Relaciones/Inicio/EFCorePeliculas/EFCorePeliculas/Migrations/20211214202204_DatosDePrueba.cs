using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace EFCorePeliculas.Migrations
{
    public partial class DatosDePrueba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Actores",
                columns: new[] { "Id", "Biografia", "FechaNacimiento", "Nombre" },
                values: new object[,]
                {
                    { 1, "Thomas Stanley Holland (Kingston upon Thames, Londres; 1 de junio de 1996), conocido simplemente como Tom Holland, es un actor, actor de voz y bailarín británico.", new DateTime(1996, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tom Holland" },
                    { 2, "Samuel Leroy Jackson (Washington D. C., 21 de diciembre de 1948), conocido como Samuel L. Jackson, es un actor y productor de cine, televisión y teatro estadounidense. Ha sido candidato al premio Óscar, a los Globos de Oro y al Premio del Sindicato de Actores, así como ganador de un BAFTA al mejor actor de reparto.", new DateTime(1948, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Samuel L. Jackson" },
                    { 3, "Robert John Downey Jr. (Nueva York, 4 de abril de 1965) es un actor, actor de voz, productor y cantante estadounidense. Inició su carrera como actor a temprana edad apareciendo en varios filmes dirigidos por su padre, Robert Downey Sr., y en su infancia estudió actuación en varias academias de Nueva York.", new DateTime(1965, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert Downey Jr." },
                    { 4, null, new DateTime(1981, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chris Evans" },
                    { 5, null, new DateTime(1972, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dwayne Johnson" },
                    { 6, null, new DateTime(2000, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Auli'i Cravalho" },
                    { 7, null, new DateTime(1984, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Scarlett Johansson" },
                    { 8, null, new DateTime(1964, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Keanu Reeves" }
                });

            migrationBuilder.InsertData(
                table: "Cines",
                columns: new[] { "Id", "Nombre", "Ubicacion" },
                values: new object[,]
                {
                    { 1, "Agora Mall", (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-69.9388777 18.4839233)") },
                    { 2, "Sambil", (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-69.911582 18.482455)") },
                    { 3, "Megacentro", (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-69.856309 18.506662)") },
                    { 4, "Acropolis", (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-69.939248 18.469649)") }
                });

            migrationBuilder.InsertData(
                table: "Generos",
                columns: new[] { "Identificador", "Nombre" },
                values: new object[,]
                {
                    { 1, "Acción" },
                    { 2, "Animación" },
                    { 3, "Comedia" },
                    { 4, "Ciencia ficción" },
                    { 5, "Drama" }
                });

            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "Id", "EnCartelera", "FechaEstreno", "PosterURL", "Titulo" },
                values: new object[,]
                {
                    { 1, false, new DateTime(2012, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://upload.wikimedia.org/wikipedia/en/8/8a/The_Avengers_%282012_film%29_poster.jpg", "Avengers" },
                    { 2, false, new DateTime(2017, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://upload.wikimedia.org/wikipedia/en/9/98/Coco_%282017_film%29_poster.jpg", "Coco" },
                    { 3, false, new DateTime(2021, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg", "Spider-Man: No way home" },
                    { 4, false, new DateTime(2019, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg", "Spider-Man: Far From Home" },
                    { 5, true, new DateTime(2021, 12, 14, 0, 0, 0, 0, DateTimeKind.Local), "https://upload.wikimedia.org/wikipedia/en/5/50/The_Matrix_Resurrections.jpg", "The Matrix Resurrections" }
                });

            migrationBuilder.InsertData(
                table: "CinesOfertas",
                columns: new[] { "Id", "CineId", "FechaFin", "FechaInicio", "PorcentajeDescuento" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 12, 21, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 12, 14, 0, 0, 0, 0, DateTimeKind.Local), 10m },
                    { 2, 4, new DateTime(2021, 12, 19, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 12, 14, 0, 0, 0, 0, DateTimeKind.Local), 15m }
                });

            migrationBuilder.InsertData(
                table: "GeneroPelicula",
                columns: new[] { "GenerosIdentificador", "PeliculasId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 2, 2 },
                    { 3, 3 },
                    { 3, 4 },
                    { 4, 1 },
                    { 4, 3 },
                    { 4, 4 },
                    { 4, 5 },
                    { 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "PeliculasActores",
                columns: new[] { "ActorId", "PeliculaId", "Orden", "Personaje" },
                values: new object[,]
                {
                    { 3, 1, 2, "Iron Man" },
                    { 4, 1, 1, "Capitán América" },
                    { 7, 1, 3, "Black Widow" },
                    { 1, 3, 1, "Peter Parker" },
                    { 1, 4, 1, "Peter Parker" },
                    { 2, 4, 2, "Samuel L. Jackson" },
                    { 8, 5, 1, "Neo" }
                });

            migrationBuilder.InsertData(
                table: "SalasDeCine",
                columns: new[] { "Id", "CineId", "Precio", "TipoSalaDeCine" },
                values: new object[,]
                {
                    { 1, 1, 220m, 1 },
                    { 2, 1, 320m, 2 },
                    { 3, 2, 200m, 1 },
                    { 4, 2, 290m, 2 },
                    { 5, 3, 250m, 1 },
                    { 6, 3, 330m, 2 },
                    { 7, 3, 450m, 3 },
                    { 8, 4, 250m, 1 }
                });

            migrationBuilder.InsertData(
                table: "PeliculaSalaDeCine",
                columns: new[] { "PeliculasId", "SalasDeCineId" },
                values: new object[,]
                {
                    { 5, 1 },
                    { 5, 2 },
                    { 5, 3 },
                    { 5, 4 },
                    { 5, 5 },
                    { 5, 6 },
                    { 5, 7 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Actores",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Actores",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CinesOfertas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CinesOfertas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GeneroPelicula",
                keyColumns: new[] { "GenerosIdentificador", "PeliculasId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "GeneroPelicula",
                keyColumns: new[] { "GenerosIdentificador", "PeliculasId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "GeneroPelicula",
                keyColumns: new[] { "GenerosIdentificador", "PeliculasId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "GeneroPelicula",
                keyColumns: new[] { "GenerosIdentificador", "PeliculasId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "GeneroPelicula",
                keyColumns: new[] { "GenerosIdentificador", "PeliculasId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "GeneroPelicula",
                keyColumns: new[] { "GenerosIdentificador", "PeliculasId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "GeneroPelicula",
                keyColumns: new[] { "GenerosIdentificador", "PeliculasId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "GeneroPelicula",
                keyColumns: new[] { "GenerosIdentificador", "PeliculasId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "GeneroPelicula",
                keyColumns: new[] { "GenerosIdentificador", "PeliculasId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "GeneroPelicula",
                keyColumns: new[] { "GenerosIdentificador", "PeliculasId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "GeneroPelicula",
                keyColumns: new[] { "GenerosIdentificador", "PeliculasId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "GeneroPelicula",
                keyColumns: new[] { "GenerosIdentificador", "PeliculasId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "PeliculaSalaDeCine",
                keyColumns: new[] { "PeliculasId", "SalasDeCineId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "PeliculaSalaDeCine",
                keyColumns: new[] { "PeliculasId", "SalasDeCineId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "PeliculaSalaDeCine",
                keyColumns: new[] { "PeliculasId", "SalasDeCineId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "PeliculaSalaDeCine",
                keyColumns: new[] { "PeliculasId", "SalasDeCineId" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "PeliculaSalaDeCine",
                keyColumns: new[] { "PeliculasId", "SalasDeCineId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "PeliculaSalaDeCine",
                keyColumns: new[] { "PeliculasId", "SalasDeCineId" },
                keyValues: new object[] { 5, 6 });

            migrationBuilder.DeleteData(
                table: "PeliculaSalaDeCine",
                keyColumns: new[] { "PeliculasId", "SalasDeCineId" },
                keyValues: new object[] { 5, 7 });

            migrationBuilder.DeleteData(
                table: "PeliculasActores",
                keyColumns: new[] { "ActorId", "PeliculaId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "PeliculasActores",
                keyColumns: new[] { "ActorId", "PeliculaId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "PeliculasActores",
                keyColumns: new[] { "ActorId", "PeliculaId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "PeliculasActores",
                keyColumns: new[] { "ActorId", "PeliculaId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "PeliculasActores",
                keyColumns: new[] { "ActorId", "PeliculaId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "PeliculasActores",
                keyColumns: new[] { "ActorId", "PeliculaId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "PeliculasActores",
                keyColumns: new[] { "ActorId", "PeliculaId" },
                keyValues: new object[] { 8, 5 });

            migrationBuilder.DeleteData(
                table: "SalasDeCine",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Actores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Actores",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Actores",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Actores",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Actores",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Actores",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Cines",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Generos",
                keyColumn: "Identificador",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Generos",
                keyColumn: "Identificador",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Generos",
                keyColumn: "Identificador",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Generos",
                keyColumn: "Identificador",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Generos",
                keyColumn: "Identificador",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SalasDeCine",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SalasDeCine",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SalasDeCine",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SalasDeCine",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SalasDeCine",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SalasDeCine",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SalasDeCine",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cines",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cines",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cines",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
