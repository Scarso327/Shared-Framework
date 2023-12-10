using Scarso.Framework.Domain.Common.Extensions;

namespace Scarso.Framework.Domain.UnitTests.Tests.Common.Extensions;

internal class TypeExtensions_Tests
{
	private interface TestInterface;
	private class TypeWithInterface : TestInterface;
	private class TypeInheritingTypeWithInterface : TestInterface;
	private class TypeWithOutInterface;

	[Test]
	public void HasInterface_TypeWithInterface_ReturnsTrue()
	{
		var type = typeof(TypeWithInterface);
		Assert.That(type.HasInterface(typeof(TestInterface)), Is.True);
	}

	[Test]
	public void HasInterfaceWithGeneric_TypeWithInterface_ReturnsTrue()
	{
		var type = typeof(TypeWithInterface);
		Assert.That(type.HasInterface<TestInterface>(), Is.True);
	}

	[Test]
	public void HasInterface_TypeWithOutInterface_ReturnsFalse()
	{
		var type = typeof(TypeWithOutInterface);
		Assert.That(type.HasInterface(typeof(TestInterface)), Is.False);
	}

	[Test]
	public void HasInterfaceWithGeneric_TypeWithOutInterface_ReturnsFalse()
	{
		var type = typeof(TypeWithOutInterface);
		Assert.That(type.HasInterface<TestInterface>(), Is.False);
	}

	[Test]
	public void HasInterface_TypeInheritingTypeWithInterface_ReturnsTrue()
	{
		var type = typeof(TypeInheritingTypeWithInterface);
		Assert.That(type.HasInterface(typeof(TestInterface)), Is.True);
	}

	[Test]
	public void HasInterfaceWithGeneric_TypeInheritingTypeWithInterface_ReturnsTrue()
	{
		var type = typeof(TypeInheritingTypeWithInterface);
		Assert.That(type.HasInterface<TestInterface>(), Is.True);
	}
}
