using Microsoft.EntityFrameworkCore;
using ProyectoExamen2.Database.Entities;

namespace ProyectoExamen2.Database
{
    public class ProyectoExamenContext : DbContext
    {

        public ProyectoExamenContext(DbContextOptions options) : base(options) { }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries().Where(e => 
                e.State == EntityState.Added || e.State == EntityState.Modified);

            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<ClienteEntity> Cliente { get; set; }
        public DbSet<LoanEntity> Loan { get; set; }
        public DbSet<AmortizationPlanEntity> AmortizationPlan { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurar la precisión y escala para las propiedades decimal
            modelBuilder.Entity<LoanEntity>(entity =>
            {
                entity.Property(e => e.InterestRate).HasPrecision(5, 2);
                entity.Property(e => e.Amount).HasPrecision(18, 2);
            });

            modelBuilder.Entity<AmortizationPlanEntity>(entity =>
            {
                entity.Property(e => e.Interest).HasPrecision(18, 2);
                entity.Property(e => e.Principal).HasPrecision(18, 2);
                entity.Property(e => e.PagoNiveladoSinSVSD).HasPrecision(18, 2);
                entity.Property(e => e.PagoNiveladoConSVSD).HasPrecision(18, 2);
                entity.Property(e => e.SaldoDePrincipal).HasPrecision(18, 2);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
