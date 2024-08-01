using GestorPaciente.Core.Domain.Common;
using GestorPaciente.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestorPaciente.Infrastructure.Persistence.Contexts
{
    public class GestorPacienteContext : DbContext
    {
        public GestorPacienteContext(DbContextOptions<GestorPacienteContext> options) : base(options) { }

        public DbSet<Pacientes> Pacientes { get; set; }
        public DbSet<Medicos> Medicos { get; set; }
        public DbSet<Citas> Citas { get; set; }
        public DbSet<PruebasLaboratorio> PruebasLaboratorio { get; set; }
        public DbSet<ResultadosLaboratorio> ResultadoLaboratorio { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.FechaCreacion = DateTime.Now;
                        entry.Entity.CreadoPor = "DefaultAppUser";
                        break;

                    case EntityState.Modified:
                        entry.Entity.UltimaFechaModificacion = DateTime.Now;
                        entry.Entity.UltimaModificacionPor = "DefaultAppUser";
                        break;

                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // FLUENT API

            #region Creación de Tablas
            modelBuilder.Entity<Pacientes>()
                .ToTable("Pacientes");
            modelBuilder.Entity<Medicos>()
                .ToTable("Medicos");
            modelBuilder.Entity<Citas>()
                .ToTable("Citas");
            modelBuilder.Entity<PruebasLaboratorio>()
                .ToTable("PruebasLaboratorio");
            modelBuilder.Entity<ResultadosLaboratorio>()
                .ToTable("ResultadosLaboratorio");
            modelBuilder.Entity<Usuarios>()
                .ToTable("Usuarios");
            #endregion

            #region Primary Keys
            modelBuilder.Entity<Pacientes>()
                .HasKey(Pacientes => Pacientes.Cedula);
            modelBuilder.Entity<Medicos>()
                .HasKey(Medicos => Medicos.Cedula);
            modelBuilder.Entity<Citas>()
                .HasKey(Citas => Citas.Id);
            modelBuilder.Entity<PruebasLaboratorio>()
                .HasKey(PruebasLaboratorio => PruebasLaboratorio.Id);
            modelBuilder.Entity<ResultadosLaboratorio>()
                .HasKey(ResultadosLaboratorio => ResultadosLaboratorio.Id); 
            modelBuilder.Entity<Usuarios>()
                .HasKey(Usuarios => Usuarios.Id);
            #endregion

            #region Relaciones por Cardinalidad

            modelBuilder.Entity<Pacientes>()
                 .HasMany(Pacientes => Pacientes.ResultadosLaboratorio)
                 .WithOne(ResultadosLaboratorio => ResultadosLaboratorio.Pacientes)
                 .HasForeignKey(ResultadosLaboratorio => ResultadosLaboratorio.CedulaPaciente)
                 .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PruebasLaboratorio>()
                 .HasOne(PruebasLaboratorio => PruebasLaboratorio.ResultadosLaboratorio)
                 .WithOne(ResultadosLaboratorio => ResultadosLaboratorio.PruebasLaboratorio)
                 .HasForeignKey<ResultadosLaboratorio>(ResultadosLaboratorio => ResultadosLaboratorio.Id_PruebasLaboratorio)
                 .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Pacientes>()
                 .HasMany(Pacientes => Pacientes.Citas)
                 .WithOne(Citas => Citas.Pacientes)
                 .HasForeignKey(Citas => Citas.CedulaPaciente)
                 .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Medicos>()
                 .HasMany(Medicos => Medicos.Citas)
                 .WithOne(Citas => Citas.Medicos)
                 .HasForeignKey(Citas => Citas.CedulaMedico)
                 .OnDelete(DeleteBehavior.Cascade);

            #endregion

            #region "Configuraciones paras las Propiedades de las Entidades"

            #region Tabla Pacientes
            modelBuilder.Entity<Pacientes>()
                .Property(Pacientes => Pacientes.Cedula)
                .IsRequired()
                .HasMaxLength(11);

            modelBuilder.Entity<Pacientes>()
                .Property(Pacientes => Pacientes.Nombre)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Pacientes>()
                .Property(Pacientes => Pacientes.Apellido)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Pacientes>()
                .Property(Pacientes => Pacientes.Telefono)
                .IsRequired()
                .HasMaxLength(10);

            modelBuilder.Entity<Pacientes>()
                .Property(Pacientes => Pacientes.Direccion)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Pacientes>()
                .Property(Pacientes => Pacientes.FechaNacimiento)
                .IsRequired()
                .HasColumnType("date");

            modelBuilder.Entity<Pacientes>()
                .Property(Pacientes => Pacientes.Fumador)
                .IsRequired();

            modelBuilder.Entity<Pacientes>()
                .Property(Pacientes => Pacientes.Alergico)
                .IsRequired();

            modelBuilder.Entity<Pacientes>()
                .Property(Pacientes => Pacientes.FotoPaciente)
                .IsRequired();
            #endregion

            #region Tabla Medicos
            modelBuilder.Entity<Medicos>()
                .Property(Medicos => Medicos.Cedula)
                .IsRequired()
                .HasMaxLength(11);

            modelBuilder.Entity<Medicos>()
                .Property(Medicos => Medicos.Nombre)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Medicos>()
                .Property(Medicos => Medicos.Apellido)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Medicos>()
                .Property(Medicos => Medicos.Correo)
                .IsRequired()
                .HasMaxLength (100);

            modelBuilder.Entity<Medicos>()
                .Property(Medicos => Medicos.Telefono)
                .IsRequired()
                .HasMaxLength(10);

            modelBuilder.Entity<Medicos>()
                .Property(Medicos => Medicos.FotoMedico)
                .IsRequired();


            #endregion

            #region Tabla PruebasLaboratorio

            modelBuilder.Entity<PruebasLaboratorio>()
                .Property(PruebasLaboratorio => PruebasLaboratorio.Nombre)
                .IsRequired()
                .HasMaxLength(70);

            #endregion

            #region Tabla ResultadosLaboratorio

            modelBuilder.Entity<ResultadosLaboratorio>()
                .Property(ResultadosLaboratorio => ResultadosLaboratorio.Estatus)
                .IsRequired()
                .HasMaxLength(20);

            #endregion

            #region Tabla Citas

            modelBuilder.Entity<Citas>()
                .Property(Citas => Citas.Estatus)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<Citas>()
                .Property(Citas => Citas.FechaCita)
                .IsRequired()
                .HasColumnType("date");

            modelBuilder.Entity<Citas>()
                .Property(Citas => Citas.CausaCita)
                .IsRequired()
                .HasMaxLength(20);

            #endregion

            #region Tabla Usuarios

            modelBuilder.Entity<Usuarios>()
                .Property(Usuarios => Usuarios.Nombre)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Usuarios>()
                .Property(Usuarios => Usuarios.Apellido)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Usuarios>()
                .Property(Usuarios => Usuarios.Correo)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Usuarios>()
                .Property(Usuarios => Usuarios.NombreUsuario)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Usuarios>()
                .Property(Usuarios => Usuarios.Contrasena)
                .IsRequired()
                .HasMaxLength(150);

            modelBuilder.Entity<Usuarios>()
                .Property(Usuarios => Usuarios.TipoUsuario)
                .IsRequired()
                .HasMaxLength(20);
            #endregion


            #endregion
        }

       

    }
}

