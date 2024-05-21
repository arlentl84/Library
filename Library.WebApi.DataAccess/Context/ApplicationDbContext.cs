using Library.WebApi.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebApi.DataAccess.Context
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Autor> Autores { get; set; }
        public virtual DbSet<Libro> Libros { get; set; }
        public virtual DbSet<Revision> Revisiones { get; set; }
        public virtual DbSet<Suscripcion> Suscripciones { get; set; }
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public class ConciergeDBContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
        {
            public ApplicationDbContext CreateDbContext(string[] args)
            {

                var connectionString =
              "Data Source=localhost;Initial Catalog=Library;User ID=sa;Password=Admin123*-;Trust Server Certificate=True";

                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
               // options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
                optionsBuilder.UseSqlServer(connectionString);

                //optionsBuilder.UseSqlServer("Data Source=localhost; Initial Catalog=UserManager; User Id=prueba; Password=prueba123");

                return new ApplicationDbContext(optionsBuilder.Options);
                //return new ApplicationDbContext();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Libro>()
            .Property(a => a.Calificacion).IsConcurrencyToken();

            modelBuilder.Entity<Libro>()
                .HasOne(r => r.Autor)
                .WithMany(b => b.Libros)
                .HasForeignKey("AutorId")
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Suscripcion>()
                .HasOne(r => r.Autor)
                .WithMany(b => b.Suscritos)
                .HasForeignKey("AutorId")
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Suscripcion>()
                .HasOne(r => r.Usuario)
                .WithMany(b => b.Suscripciones)
                .HasForeignKey("UsuarioId")
                .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<Revision>()
                .HasOne(r => r.Usuario)
                .WithMany(b => b.Revisiones)
                .HasForeignKey("UsuarioId")
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Revision>()
                .HasOne(r => r.Libro)
                .WithMany(b => b.Revisiones)
                .HasForeignKey("LibroId")
                .OnDelete(DeleteBehavior.Cascade);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseNpgsql(connectionString);
            }*/
        }
    }
}
