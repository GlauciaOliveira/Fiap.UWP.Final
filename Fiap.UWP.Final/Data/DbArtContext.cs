using Fiap.UWP.Final.Model;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Fiap.UWP.Final.Data
{
    public partial class DbArtContext : DbContext
    {
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    string sqliteConnectionString = null;

            //    try
            //    {
            //        var connectionString = new SqliteConnectionStringBuilder()
            //        {
            //            DataSource = Path.Combine(ApplicationData.Current.LocalFolder.Path, "BdArtBeer.db")
            //        };
            //        sqliteConnectionString = connectionString.ToString();
            //    }
            //    catch (InvalidOperationException)
            //    {
            //        var connectionString = new SqliteConnectionStringBuilder()
            //        {
            //            DataSource = "BdArtBeer.db"
            //        };
            //        sqliteConnectionString = connectionString.ToString();
            //    }

            //    optionsBuilder.UseSqlite(sqliteConnectionString);
            //}
            optionsBuilder.UseSqlite(@"Filename= C:\Users\glauciaoliveira\AppData\Local\Packages\2b810ab5-9774-4cf3-92f2-7469e8fcf5d2_xxnf0qmtpb0m0\LocalState\DbArtBeer.mdf"); /*(@"Server=(localdb)\MSSQLLocalDB;Database=DbArtBeer;");*/
        }

        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .HasKey(x => new { x.IdUsuario });
        }
    }
}
