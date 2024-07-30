
namespace GestorPaciente.Infrastructure.Persistence.Contexts
{
    internal class GestorPacienteContext
    {
    }
}


//using ItlaTv.Core.Domain.Common;
//using ItlaTv.Core.Domain.Entities;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ItlaTv.Infrastructure.Persistence.Contexts
//{
//    public class ItlaTvContext : DbContext
//    {
//        public ItlaTvContext(DbContextOptions<ItlaTvContext> options) : base(options) { }

//        public DbSet<Serie> Series { get; set; }
//        public DbSet<Productora> Productoras { get; set; }
//        public DbSet<Genero> Generos { get; set; }
//        public DbSet<Usuario> Usuarios { get; set; }


//        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
//        {
//            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
//            {
//                switch (entry.State)
//                {
//                    case EntityState.Added:
//                        entry.Entity.Created = DateTime.Now;
//                        entry.Entity.CreatedBy = "DefaultAppUser";
//                        break;

//                    case EntityState.Modified:
//                        entry.Entity.LastModified = DateTime.Now;
//                        entry.Entity.LastModifiedBy = "DefaultAppUser";
//                        break;

//                }
//            }

//            return await base.SaveChangesAsync(cancellationToken);
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            // FLUENT API

//            #region tables
//            modelBuilder.Entity<Serie>()
//                .ToTable("Series");
//            modelBuilder.Entity<Productora>()
//                .ToTable("Productoras");
//            modelBuilder.Entity<Genero>()
//                .ToTable("Generos");
//            modelBuilder.Entity<Usuario>()
//                .ToTable("Usuarios");
//            #endregion

//            #region "primary keys"
//            modelBuilder.Entity<Serie>()
//                .HasKey(Serie => Serie.Id);
//            modelBuilder.Entity<Productora>()
//                .HasKey(Productora => Productora.Id);
//            modelBuilder.Entity<Genero>()
//                .HasKey(Genero => Genero.Id);
//            modelBuilder.Entity<Usuario>()
//                .HasKey(Usuario => Usuario.Id);
//            #endregion

//            #region "Relationships"

//            modelBuilder.Entity<Usuario>()
//            .HasMany<Serie>(Usuario => Usuario.Series)
//            .WithOne(Serie => Serie.Usuario)
//            .HasForeignKey(Serie => Serie.Id_usuario)
//            .OnDelete(DeleteBehavior.Restrict);


//            modelBuilder.Entity<Usuario>()
//            .HasMany<Genero>(Usuario => Usuario.Generos)
//            .WithOne(Genero => Genero.Usuario)
//            .HasForeignKey(Genero => Genero.Id_usuario)
//            .OnDelete(DeleteBehavior.Restrict);


//            modelBuilder.Entity<Usuario>()
//            .HasMany<Productora>(Usuario => Usuario.Productoras)
//            .WithOne(Productora => Productora.Usuario)
//            .HasForeignKey(Productora => Productora.Id_usuario)
//            .OnDelete(DeleteBehavior.Restrict);


//            modelBuilder.Entity<Productora>()
//            .HasMany<Serie>(Productora => Productora.Series)
//            .WithOne(Serie => Serie.Productoras)
//            .HasForeignKey(Serie => Serie.Id_productora)
//            .OnDelete(DeleteBehavior.Cascade);


//            modelBuilder.Entity<Genero>()
//            .HasMany<Serie>(Genero => Genero.Series)
//            .WithOne(Serie => Serie.Genero)
//            .HasForeignKey(Serie => Serie.Id_genero)
//            .OnDelete(DeleteBehavior.Cascade);


//            #endregion

//            #region "Properties Configurations"

//            #region "Series"
//            modelBuilder.Entity<Serie>()
//                .Property(Serie => Serie.Nombre)
//                .IsRequired()
//                .HasMaxLength(100);

//            modelBuilder.Entity<Serie>()
//                .Property(Serie => Serie.Url_imagen)
//                .IsRequired();

//            modelBuilder.Entity<Serie>()
//                .Property(Serie => Serie.Url_video)
//                .IsRequired();
//            #endregion

//            #region "Productora"
//            modelBuilder.Entity<Productora>()
//                .Property(Productora => Productora.Nombre)
//                .IsRequired()
//                .HasMaxLength(100);
//            #endregion

//            #region "Genero"
//            modelBuilder.Entity<Genero>()
//                .Property(Genero => Genero.Nombre)
//                .IsRequired()
//                .HasMaxLength(100);
//            #endregion

//            #region "Usuario"
//            modelBuilder.Entity<Usuario>()
//                .Property(Usuario => Usuario.NombreUsuario)
//                .IsRequired()
//                .HasMaxLength(100);

//            modelBuilder.Entity<Usuario>()
//                .Property(Usuario => Usuario.Contrasena)
//                .IsRequired();

//            modelBuilder.Entity<Usuario>()
//                .Property(Usuario => Usuario.NombrePropio)
//                .IsRequired()
//                .HasMaxLength(100);

//            modelBuilder.Entity<Usuario>()
//                .Property(Usuario => Usuario.Correo)
//                .IsRequired();

//            modelBuilder.Entity<Usuario>()
//                .Property(Usuario => Usuario.Telefono)
//                .IsRequired();

//            #endregion

//            #endregion
//        }

//    }
//}

