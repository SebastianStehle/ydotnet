using NUnit.Framework;
using YDotNet.Document;
using YDotNet.Document.Cells;

namespace YDotNet.Tests.Unit.XmlTexts;

public class LengthTests
{
    [Test]
    public void LengthIsInitiallyZero()
    {
        // Arrange
        var doc = new Doc();
        var xmlText = doc.XmlText("xml-text");

        // Act
        var transaction = doc.WriteTransaction();
        var length = xmlText.Length(transaction);
        transaction.Commit();

        // Assert
        Assert.That(length, Is.EqualTo(expected: 0));
    }

    [Test]
    public void LengthIncreasesWhenTextIsAdded()
    {
        // Arrange
        var doc = new Doc();
        var xmlText = doc.XmlText("xml-text");

        // Act
        var transaction = doc.WriteTransaction();
        xmlText.Insert(transaction, index: 0, "Greetings");
        var length = xmlText.Length(transaction);
        transaction.Commit();

        // Assert
        Assert.That(length, Is.EqualTo(expected: 9));

        // Act
        transaction = doc.WriteTransaction();
        xmlText.Insert(
            transaction,
            index: 9,
            ", universe!",
            Input.Object(
                new Dictionary<string, Input>
                {
                    { "color", Input.String("red") }
                }));
        length = xmlText.Length(transaction);
        transaction.Commit();

        // Assert
        Assert.That(length, Is.EqualTo(expected: 20));

        // Act
        transaction = doc.WriteTransaction();
        xmlText.Insert(transaction, index: 0, " 🔭");
        length = xmlText.Length(transaction);
        transaction.Commit();

        // Assert
        Assert.That(length, Is.EqualTo(expected: 23));
    }
}
