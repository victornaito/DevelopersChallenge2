using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nibo.Core;

namespace Nibo.InfraEstructure.Mapping
{
    public class ConciliationMapping : IEntityTypeConfiguration<Conciliation>
    {
        public void Configure(EntityTypeBuilder<Conciliation> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.DatePosted).IsRequired();
            builder.Property(s => s.TransactionAmount).IsRequired();
            builder.Property(s => s.TransactionDescription).IsRequired();
            builder.Property(s => s.TransactionType).IsRequired();
        }
    }
}
