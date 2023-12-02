namespace Scarso.Framework.Domain.MultiTenancy.Configuration;

public record MultiTenancyConfig
{
    public bool IsRequired { get; set; }

    public List<Type> ResolverTypes { get; set; } = [];
}
