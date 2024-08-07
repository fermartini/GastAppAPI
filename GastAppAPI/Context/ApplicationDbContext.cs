using GastAppAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GastAppAPI.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Gasto> Gastos { get; set; }
        public DbSet<Ingreso> Ingresos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<NombreGasto> NombreGastos { get; set; }
        public DbSet<TipoGasto> TipoGastos { get; set; }
        public DbSet<NombreIngreso> NombreIngresos { get; set; }
        public DbSet<TipoIngreso> TipoIngresos { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Usuario>()
                .Property(u => u.Id)
                .HasColumnType("nvarchar")
                .ValueGeneratedNever();  // Esto indica que el valor no será generado automáticamente

            // Configuración adicional si es necesaria
        }


    }
}
