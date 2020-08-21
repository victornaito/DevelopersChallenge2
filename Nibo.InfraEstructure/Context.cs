using Microsoft.EntityFrameworkCore;
using Nibo.Core;
using Nibo.InfraEstructure.Mapping;

namespace Nibo.InfraEstructure
{
    public class Context: DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Conciliation>(new ConciliationMapping().Configure);
        }
    }
}
