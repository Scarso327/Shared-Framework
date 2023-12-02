namespace Scarso.Framework.Domain.Common.Exceptions;

public class MissingConfigException : DomainException
{
    public MissingConfigException(string? message) : base(message) { }

    public MissingConfigException(Type type) : base($"Missing Config Of Type '{type.FullName}'") { }
}
