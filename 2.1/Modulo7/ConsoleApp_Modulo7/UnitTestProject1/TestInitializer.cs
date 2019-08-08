using ConsoleApp_Modulo7;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace UnitTestProject1
{
    [TestClass]
    public class TestInitializer
    {
        private static readonly string _dbName = "PruebasDeIntegracion";

        [AssemblyInitialize]
        public static void Inicio(TestContext testContext)
        {
            BorrarDB();
            CrearDB();
        }

        [AssemblyCleanup]
        public static void Fin()
        {
            BorrarDB();
        }

        public static ApplicationDbContext ObtenerDataContext(bool beginTransaction = true)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer($"Data Source=(localdb)\\mssqllocaldb;Initial Catalog={_dbName};Integrated Security=True")
                .Options;
            var context = new ApplicationDbContext(options);
            if (beginTransaction)
            {
                context.Database.BeginTransaction();
            }
            return context;
        }

        private static void CrearDB()
        {
            EjecutarComando(Master, $@"
                CREATE DATABASE [{_dbName}]
                ON (NAME = '{_dbName}',
                FILENAME = '{Filename}')");

            using (var context = ObtenerDataContext(beginTransaction: false))
            {
                context.Database.Migrate();
                // Este es un buen lugar para colocar data
                // de prueba en la BDs
                context.SaveChanges();
            }
        }

        static void BorrarDB()
        {
            var fileNames = ObtenerArchivosDeBD(Master, $@"
                SELECT [physical_name] FROM [sys].[master_files]
                WHERE [database_id] = DB_ID('{_dbName}')",
                "physical_name");

            if (fileNames.Any())
            {
                EjecutarComando(Master, $@"
                    ALTER DATABASE [{_dbName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                    EXEC sp_detach_db '{_dbName}'");

                foreach (var filename in fileNames)
                {
                    File.Delete(filename);
                }
            }
        }

        static void EjecutarComando(string connectionString, string query)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        static IEnumerable<string> ObtenerArchivosDeBD(
           string connectionString,
           string query,
           string nombreColumna)
        {
            IEnumerable<string> archivos;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var cmd = new SqlCommand(query, connection))
                {
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        var dt = new DataTable();
                        da.Fill(dt);
                        archivos = from DataRow myRow in dt.Rows
                                   select (string)myRow["physical_name"];
                    }
                }
            }
            return archivos;
        }

        static string Master =>
           new SqlConnectionStringBuilder
           {
               DataSource = @"(LocalDB)\MSSQLLocalDB",
               InitialCatalog = "master",
               IntegratedSecurity = true
           }.ConnectionString;

        static string Filename => Path.Combine(
           Path.GetDirectoryName(
               typeof(TestInitializer).GetTypeInfo().Assembly.Location),
           $"{_dbName}.mdf");
    }

}
