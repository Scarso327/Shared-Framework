using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Scarso.Framework.Samples.APITenantResolution.Domain.MultiTenancy.Entities;

namespace Scarso.Framework.Samples.APITenantResolution.Infrastructure.Persistence.Configuration.MultiTenancy;

internal class TenantConfig : IEntityTypeConfiguration<Tenant>
{
    public void Configure(EntityTypeBuilder<Tenant> builder)
    {
        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd();

        builder.Property(e => e.SubDomain)
            .HasMaxLength(16);

        builder.HasIndex(e => e.SubDomain)
            .IsUnique();
    }
}
