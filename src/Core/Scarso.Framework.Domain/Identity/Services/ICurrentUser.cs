using Scarso.Framework.Domain.Identity.Interfaces;

namespace Scarso.Framework.Domain.Identity.Services;

public interface ICurrentUser
{
    public IUser? User { get; }
}
