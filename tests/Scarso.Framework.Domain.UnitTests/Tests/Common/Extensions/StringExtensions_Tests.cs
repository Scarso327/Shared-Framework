using Scarso.Framework.Domain.Common.Extensions;

namespace Scarso.Framework.Domain.UnitTests.Tests.Common.Extensions;

internal class StringExtensions_Tests
{
	[Test]
	public void IsNullOrEmpty_EmptyString_ReturnsTrue()
	{
		string input = string.Empty;
		Assert.That(input.IsNullOrEmpty(), Is.True);
	}

	[Test]
	public void IsNullOrEmpty_NullString_ReturnsTrue()
	{
		string? input = null;
		Assert.That(input.IsNullOrEmpty(), Is.True);
	}

	[Test]
	public void IsNullOrEmpty_StringWithValue_ReturnsFalse()
	{
		string input = "Hello World";
		Assert.That(input.IsNullOrEmpty(), Is.False);
	}

	[Test]
	public void IsNullOrWhiteSpace_EmptyString_ReturnsTrue()
	{
		string input = string.Empty;
		Assert.That(input.IsNullOrWhiteSpace(), Is.True);
	}

	[Test]
	public void IsNullOrWhiteSpace_NullString_ReturnsTrue()
	{
		string? input = null;
		Assert.That(input.IsNullOrWhiteSpace(), Is.True);
	}

	[Test]
	public void IsNullOrWhiteSpace_StringWithValue_ReturnsFalse()
	{
		string input = "Hello World";
		Assert.That(input.IsNullOrWhiteSpace(), Is.False);
	}

	[Test]
	public void IsNullOrWhiteSpace_StringWithNothingButWhiteSpace_ReturnsTrue()
	{
		string input = "  ";
		Assert.That(input.IsNullOrWhiteSpace(), Is.True);
	}
}
