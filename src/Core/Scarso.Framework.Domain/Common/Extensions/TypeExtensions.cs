namespace Scarso.Framework.Domain.Common.Extensions;

public static class TypeExtensions
{
	public static bool HasInterface(this Type type, Type @interface, bool ignoreCase = false)
	{
		if (!@interface.IsInterface)
			throw new ArgumentException("Provided type must be an interface");

		return type.GetInterface(@interface.Name, ignoreCase) is not null;
	}

	public static bool HasInterface<TInterfaceType>(this Type type, bool ignoreCase = false)
		=> type.HasInterface(typeof(TInterfaceType), ignoreCase);
}
