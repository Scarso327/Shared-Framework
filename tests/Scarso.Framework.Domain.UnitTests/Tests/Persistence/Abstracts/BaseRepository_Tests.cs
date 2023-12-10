using Moq;
using Scarso.Framework.Domain.Entities;
using Scarso.Framework.Domain.Entities.Auditing.Interfaces;
using Scarso.Framework.Domain.Persistence.Abstracts;

namespace Scarso.Framework.Domain.UnitTests.Tests.Persistence.Abstracts;

public class NormalEntity : Entity;

public class SoftDeleteEntity : Entity, ISoftDelete
{
	public Guid? DeletedByUserId { get; set; }
	public bool IsDeleted { get; set; }
}

internal class BaseRepository_Tests
{
	[Test]
	public void Delete_ISoftDeleteEntity_SetsPropertiesAndCallsUpdate()
	{
		// Arrange
		var repositoryMoq = new Mock<BaseRepository<SoftDeleteEntity>>();
		repositoryMoq.Setup(e => e.Delete(It.IsAny<SoftDeleteEntity>())).CallBase();

		var repository = repositoryMoq.Object;
		var entity = new SoftDeleteEntity();

		// Act
		repository.Delete(entity);

		// Assert
		repositoryMoq.Verify(e => e.Update(It.IsAny<SoftDeleteEntity>()), Times.Once);

		Assert.That(entity.IsDeleted, Is.True);
	}

	[Test]
	public void Delete_NormalEntity_DoesNotCallUpdate()
	{
		// Arrange
		var repositoryMoq = new Mock<BaseRepository<NormalEntity>>();
		repositoryMoq.Setup(e => e.Delete(It.IsAny<NormalEntity>())).CallBase();

		var repository = repositoryMoq.Object;
		var entity = new NormalEntity();

		// Act
		repository.Delete(entity);

		// Assert
		repositoryMoq.Verify(e => e.Update(It.IsAny<NormalEntity>()), Times.Never);
	}
}
