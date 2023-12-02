namespace Scarso.Framework.Domain.Identity.Interfaces;

public interface IUser
{
    public Guid Id { get; set; }

    public string Forename { get; set; }

    public string Surname { get; set; }

    public string Email { get; set; }
}
