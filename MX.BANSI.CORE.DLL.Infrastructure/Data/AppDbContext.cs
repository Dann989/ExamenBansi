// -----------------------------------------------------------------------
// <copyright file="AppDbContext.cs" company="BANSI">
// Copyright (c) BANSI. Todos los derechos reservados.
// </copyright>
// -----------------------------------------------------------------------

namespace MX.BANSI.CORE.DLL.Infrastructure.Data
{
    using Microsoft.EntityFrameworkCore;
    using DOMAIN.Entities;

    /// <summary>
    /// Representa el contexto de la base de datos para la aplicación,
    /// proporcionando acceso a las entidades y configuraciones de la base de datos.
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Obtiene o establece el conjunto de datos para la entidad Examen.
        /// </summary>
        /// <value>El conjunto de datos que representa la entidad Examen en la base de datos.</value>
        public DbSet<Examen> Examenes { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AppDbContext"/> con las opciones especificadas.
        /// </summary>
        /// <param name="options">Las opciones para configurar el contexto de la base de datos.</param>
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Configura las relaciones y restricciones del modelo utilizando el <see cref="ModelBuilder"/>.
        /// </summary>
        /// <param name="modelBuilder">El generador de modelos usado para configurar las entidades.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configura la entidad Examen para que se mapee a la tabla tblExamen
            modelBuilder.Entity<Examen>().ToTable("tblExamen");

            // Configura la clave primaria de la entidad Examen
            modelBuilder.Entity<Examen>()
                .HasKey(e => e.Id);

            // Configura la propiedad Id para que sea generada automáticamente
            modelBuilder.Entity<Examen>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            // Configura la propiedad Nombre como requerida y con un máximo de 100 caracteres
            modelBuilder.Entity<Examen>()
                .Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            // Configura la propiedad Descripcion con un máximo de 255 caracteres
            modelBuilder.Entity<Examen>()
                .Property(e => e.Descripcion)
                .HasMaxLength(255);
        }
    }
}