using Scarso.Framework.Domain.Entities;
using Scarso.Framework.Domain.MultiTenancy.Interfaces;
using Scarso.Framework.Domain.Persistence.Attributes;

namespace Scarso.Framework.Samples.APITenantResolution.Domain.MultiTenancy.Entities;

public class Tenant : Entity, ITenant
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    protected Tenant() : base() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public Tenant(string subDomain) => SubDomain = subDomain;

    public Tenant(Guid id, string subDomain) : this(subDomain) => Id = id;

    public string SubDomain { get; set; }

    [AutoSeed]
    public static Tenant LocalHost => new(Guid.Parse("D2807306-DAAA-416D-8CAB-21FB813660FE"), "localhost");

    [AutoSeed]
    public static Tenant GitHub => new(Guid.Parse("0C7AA27D-8C92-458C-8835-C27B89538E1D"), "github");
}