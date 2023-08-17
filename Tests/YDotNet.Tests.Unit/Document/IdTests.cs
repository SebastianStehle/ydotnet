using NUnit.Framework;
using YDotNet.Document;

namespace YDotNet.Tests.Unit.Document;

public class IdTests
{
    [Test]
    public void IsGreaterThanZeroByDefault()
    {
        // Arrange
        var doc = new Doc();

        // Act
        var id = doc.Id;

        // Assert
        Assert.That(id, Is.GreaterThan(expected: 0));
    }
}
