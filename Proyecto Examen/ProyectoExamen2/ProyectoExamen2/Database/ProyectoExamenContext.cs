using Microsoft.EntityFrameworkCore;
using ProyectoExamen2.Database.Entities;

namespace ProyectoExamen2.Database
{
    public class ProyectoExamenContext : DbContext
    {
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries().Where(e => 
                e.State == EntityState.Added || e.State == EntityState.Modified);

            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<ClienteEntity> Cliente { get; set; }
    }
}
