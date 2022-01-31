using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
using NetTopologySuite.Geometries;

namespace EFCorePeliculas.Entidades.Seeding
{
    public static class SeedingModuloConsulta
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var acción = new Genero { Identificador = 1, Nombre = "Acción" };
            var animación = new Genero { Identificador = 2, Nombre = "Animación" };
            var comedia = new Genero { Identificador = 3, Nombre = "Comedia" };
            var cienciaFicción = new Genero { Identificador = 4, Nombre = "Ciencia ficción" };
            var drama = new Genero { Identificador = 5, Nombre = "Drama" };

            modelBuilder.Entity<Genero>().HasData(acción, animación, comedia, cienciaFicción, drama);

            var tomHolland = new Actor() { Id = 1, Nombre = "Tom Holland", FechaNacimiento = new DateTime(1996, 6, 1), Biografia = "Thomas Stanley Holland (Kingston upon Thames, Londres; 1 de junio de 1996), conocido simplemente como Tom Holland, es un actor, actor de voz y bailarín británico." };
            var samuelJackson = new Actor() { Id = 2, Nombre = "Samuel L. Jackson", FechaNacimiento = new DateTime(1948, 12, 21), Biografia = "Samuel Leroy Jackson (Washington D. C., 21 de diciembre de 1948), conocido como Samuel L. Jackson, es un actor y productor de cine, televisión y teatro estadounidense. Ha sido candidato al premio Óscar, a los Globos de Oro y al Premio del Sindicato de Actores, así como ganador de un BAFTA al mejor actor de reparto." };
            var robertDowney = new Actor() { Id = 3, Nombre = "Robert Downey Jr.", FechaNacimiento = new DateTime(1965, 4, 4), Biografia = "Robert John Downey Jr. (Nueva York, 4 de abril de 1965) es un actor, actor de voz, productor y cantante estadounidense. Inició su carrera como actor a temprana edad apareciendo en varios filmes dirigidos por su padre, Robert Downey Sr., y en su infancia estudió actuación en varias academias de Nueva York." };
            var chrisEvans = new Actor() { Id = 4, Nombre = "Chris Evans", FechaNacimiento = new DateTime(1981, 06, 13) };
            var laRoca = new Actor() { Id = 5, Nombre = "Dwayne Johnson", FechaNacimiento = new DateTime(1972, 5, 2) };
            var auliCravalho = new Actor() { Id = 6, Nombre = "Auli'i Cravalho", FechaNacimiento = new DateTime(2000, 11, 22) };
            var scarlettJohansson = new Actor() { Id = 7, Nombre = "Scarlett Johansson", FechaNacimiento = new DateTime(1984, 11, 22) };
            var keanuReeves = new Actor() { Id = 8, Nombre = "Keanu Reeves", FechaNacimiento = new DateTime(1964, 9, 2) };

            modelBuilder.Entity<Actor>().HasData(tomHolland, samuelJackson,
                            robertDowney, chrisEvans, laRoca, auliCravalho, scarlettJohansson, keanuReeves);
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

            var agora = new Cine() { Id = 1, Nombre = "Agora Mall", Ubicacion = geometryFactory.CreatePoint(new Coordinate(-69.9388777, 18.4839233)) };
            var sambil = new Cine() { Id = 2, Nombre = "Sambil", Ubicacion = geometryFactory.CreatePoint(new Coordinate(-69.911582, 18.482455)) };
            var megacentro = new Cine() { Id = 3, Nombre = "Megacentro", Ubicacion = geometryFactory.CreatePoint(new Coordinate(-69.856309, 18.506662)) };
            var acropolis = new Cine() { Id = 4, Nombre = "Acropolis", Ubicacion = geometryFactory.CreatePoint(new Coordinate(-69.939248, 18.469649)) };

            var agoraCineOferta = new CineOferta { Id = 1, CineId = agora.Id, FechaInicio = DateTime.Today, FechaFin = DateTime.Today.AddDays(7), PorcentajeDescuento = 10 };

            var salaDeCine2DAgora = new SalaDeCine()
            {
                Id = 1,
                ElCine = agora.Id,
                Precio = 220,
                TipoSalaDeCine = TipoSalaDeCine.DosDimensiones
            };
            var salaDeCine3DAgora = new SalaDeCine()
            {
                Id = 2,
                ElCine = agora.Id,
                Precio = 320,
                TipoSalaDeCine = TipoSalaDeCine.TresDimensiones
            };

            var salaDeCine2DSambil = new SalaDeCine()
            {
                Id = 3,
                ElCine = sambil.Id,
                Precio = 200,
                TipoSalaDeCine = TipoSalaDeCine.DosDimensiones
            };
            var salaDeCine3DSambil = new SalaDeCine()
            {
                Id = 4,
                ElCine = sambil.Id,
                Precio = 290,
                TipoSalaDeCine = TipoSalaDeCine.TresDimensiones
            };


            var salaDeCine2DMegacentro = new SalaDeCine()
            {
                Id = 5,
                ElCine = megacentro.Id,
                Precio = 250,
                TipoSalaDeCine = TipoSalaDeCine.DosDimensiones
            };
            var salaDeCine3DMegacentro = new SalaDeCine()
            {
                Id = 6,
                ElCine = megacentro.Id,
                Precio = 330,
                TipoSalaDeCine = TipoSalaDeCine.TresDimensiones
            };
            var salaDeCineCXCMegacentro = new SalaDeCine()
            {
                Id = 7,
                ElCine = megacentro.Id,
                Precio = 450,
                TipoSalaDeCine = TipoSalaDeCine.CXC
            };

            var salaDeCine2DAcropolis = new SalaDeCine()
            {
                Id = 8,
                ElCine = acropolis.Id,
                Precio = 250,
                TipoSalaDeCine = TipoSalaDeCine.DosDimensiones
            };

            var acropolisCineOferta = new CineOferta { Id = 2, CineId = acropolis.Id, FechaInicio = DateTime.Today, FechaFin = DateTime.Today.AddDays(5), PorcentajeDescuento = 15 };

            modelBuilder.Entity<Cine>().HasData(acropolis, sambil, megacentro, agora);
            modelBuilder.Entity<CineOferta>().HasData(acropolisCineOferta, agoraCineOferta);
            modelBuilder.Entity<SalaDeCine>().HasData(salaDeCine2DMegacentro, salaDeCine3DMegacentro, salaDeCineCXCMegacentro, salaDeCine2DAcropolis, salaDeCine2DAgora, salaDeCine3DAgora, salaDeCine2DSambil, salaDeCine3DSambil);


            var avengers = new Pelicula()
            {
                Id = 1,
                Titulo = "Avengers",
                EnCartelera = false,
                FechaEstreno = new DateTime(2012, 4, 11),
                PosterURL = "https://upload.wikimedia.org/wikipedia/en/8/8a/The_Avengers_%282012_film%29_poster.jpg",
            };

            var entidadGeneroPelicula = "GeneroPelicula";
            var generoIdPropiedad = "GenerosIdentificador";
            var peliculaIdPropiedad = "PeliculasId";

            var entidadSalaDeCinePelicula = "PeliculaSalaDeCine";
            var salaDeCineIdPropiedad = "SalasDeCineId";

            modelBuilder.Entity(entidadGeneroPelicula).HasData(
                new Dictionary<string, object> { [generoIdPropiedad] = acción.Identificador, [peliculaIdPropiedad] = avengers.Id },
                new Dictionary<string, object> { [generoIdPropiedad] = cienciaFicción.Identificador, [peliculaIdPropiedad] = avengers.Id }
            );

            var coco = new Pelicula()
            {
                Id = 2,
                Titulo = "Coco",
                EnCartelera = false,
                FechaEstreno = new DateTime(2017, 11, 22),
                PosterURL = "https://upload.wikimedia.org/wikipedia/en/9/98/Coco_%282017_film%29_poster.jpg"
            };

            modelBuilder.Entity(entidadGeneroPelicula).HasData(
               new Dictionary<string, object> { [generoIdPropiedad] = animación.Identificador, [peliculaIdPropiedad] = coco.Id }
           );

            var noWayHome = new Pelicula()
            {
                Id = 3,
                Titulo = "Spider-Man: No way home",
                EnCartelera = false,
                FechaEstreno = new DateTime(2021, 12, 17),
                PosterURL = "https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg"
            };

            modelBuilder.Entity(entidadGeneroPelicula).HasData(
               new Dictionary<string, object> { [generoIdPropiedad] = cienciaFicción.Identificador, [peliculaIdPropiedad] = noWayHome.Id },
               new Dictionary<string, object> { [generoIdPropiedad] = acción.Identificador, [peliculaIdPropiedad] = noWayHome.Id },
               new Dictionary<string, object> { [generoIdPropiedad] = comedia.Identificador, [peliculaIdPropiedad] = noWayHome.Id }
           );

            var farFromHome = new Pelicula()
            {
                Id = 4,
                Titulo = "Spider-Man: Far From Home",
                EnCartelera = false,
                FechaEstreno = new DateTime(2019, 7, 2),
                PosterURL = "https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg"
            };

            modelBuilder.Entity(entidadGeneroPelicula).HasData(
               new Dictionary<string, object> { [generoIdPropiedad] = cienciaFicción.Identificador, [peliculaIdPropiedad] = farFromHome.Id },
               new Dictionary<string, object> { [generoIdPropiedad] = acción.Identificador, [peliculaIdPropiedad] = farFromHome.Id },
               new Dictionary<string, object> { [generoIdPropiedad] = comedia.Identificador, [peliculaIdPropiedad] = farFromHome.Id }
           );

            var theMatrixResurrections = new Pelicula()
            {
                Id = 5,
                Titulo = "The Matrix Resurrections",
                EnCartelera = true,
                FechaEstreno = DateTime.Today,
                PosterURL = "https://upload.wikimedia.org/wikipedia/en/5/50/The_Matrix_Resurrections.jpg",
            };

            modelBuilder.Entity(entidadGeneroPelicula).HasData(
              new Dictionary<string, object> { [generoIdPropiedad] = cienciaFicción.Identificador, [peliculaIdPropiedad] = theMatrixResurrections.Id },
              new Dictionary<string, object> { [generoIdPropiedad] = acción.Identificador, [peliculaIdPropiedad] = theMatrixResurrections.Id },
              new Dictionary<string, object> { [generoIdPropiedad] = drama.Identificador, [peliculaIdPropiedad] = theMatrixResurrections.Id }
          );

            modelBuilder.Entity(entidadSalaDeCinePelicula).HasData(
             new Dictionary<string, object> { [salaDeCineIdPropiedad] = salaDeCine2DSambil.Id, [peliculaIdPropiedad] = theMatrixResurrections.Id },
             new Dictionary<string, object> { [salaDeCineIdPropiedad] = salaDeCine3DSambil.Id, [peliculaIdPropiedad] = theMatrixResurrections.Id },
             new Dictionary<string, object> { [salaDeCineIdPropiedad] = salaDeCine2DAgora.Id, [peliculaIdPropiedad] = theMatrixResurrections.Id },
             new Dictionary<string, object> { [salaDeCineIdPropiedad] = salaDeCine3DAgora.Id, [peliculaIdPropiedad] = theMatrixResurrections.Id },
             new Dictionary<string, object> { [salaDeCineIdPropiedad] = salaDeCine2DMegacentro.Id, [peliculaIdPropiedad] = theMatrixResurrections.Id },
             new Dictionary<string, object> { [salaDeCineIdPropiedad] = salaDeCine3DMegacentro.Id, [peliculaIdPropiedad] = theMatrixResurrections.Id },
             new Dictionary<string, object> { [salaDeCineIdPropiedad] = salaDeCineCXCMegacentro.Id, [peliculaIdPropiedad] = theMatrixResurrections.Id }
         );


            var keanuReevesMatrix = new PeliculaActor
            {
                ActorId = keanuReeves.Id,
                PeliculaId = theMatrixResurrections.Id,
                Orden = 1,
                Personaje = "Neo"
            };

            var avengersChrisEvans = new PeliculaActor
            {
                ActorId = chrisEvans.Id,
                PeliculaId = avengers.Id,
                Orden = 1,
                Personaje = "Capitán América"
            };

            var avengersRobertDowney = new PeliculaActor
            {
                ActorId = robertDowney.Id,
                PeliculaId = avengers.Id,
                Orden = 2,
                Personaje = "Iron Man"
            };

            var avengersScarlettJohansson = new PeliculaActor
            {
                ActorId = scarlettJohansson.Id,
                PeliculaId = avengers.Id,
                Orden = 3,
                Personaje = "Black Widow"
            };

            var tomHollandFFH = new PeliculaActor
            {
                ActorId = tomHolland.Id,
                PeliculaId = farFromHome.Id,
                Orden = 1,
                Personaje = "Peter Parker"
            };

            var tomHollandNWH = new PeliculaActor
            {
                ActorId = tomHolland.Id,
                PeliculaId = noWayHome.Id,
                Orden = 1,
                Personaje = "Peter Parker"
            };

            var samuelJacksonFFH = new PeliculaActor
            {
                ActorId = samuelJackson.Id,
                PeliculaId = farFromHome.Id,
                Orden = 2,
                Personaje = "Samuel L. Jackson"
            };

            modelBuilder.Entity<Pelicula>().HasData(avengers, coco, noWayHome, farFromHome, theMatrixResurrections);
            modelBuilder.Entity<PeliculaActor>().HasData(samuelJacksonFFH, tomHollandFFH, tomHollandNWH, avengersRobertDowney, avengersScarlettJohansson,
                avengersChrisEvans, keanuReevesMatrix);

        }
    }
}
