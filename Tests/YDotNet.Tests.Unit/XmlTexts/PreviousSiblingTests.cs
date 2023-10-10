using NUnit.Framework;
using YDotNet.Document;
using YDotNet.Document.Types.XmlElements;

namespace YDotNet.Tests.Unit.XmlTexts;

public class PreviousSiblingTests
{
    [Test]
    public void GetsPreviousSiblingAtBeginning()
    {
        // Arrange
        var (doc, xmlElement) = ArrangeDoc();

        // Act
        var transaction = doc.ReadTransaction();
        var target = xmlElement.Get(transaction, index: 0).ResolveXmlText();
        var sibling = target.PreviousSibling(transaction);
        transaction.Commit();

        // Assert
        Assert.That(sibling, Is.Null);
    }

    [Test]
    public void GetsPreviousSiblingAtMiddle()
    {
        // Arrange
        var (doc, xmlElement) = ArrangeDoc();

        // Act
        var transaction = doc.ReadTransaction();
        var target = xmlElement.Get(transaction, index: 2).ResolveXmlText();
        var sibling = target.PreviousSibling(transaction);
        transaction.Commit();

        // Assert
        Assert.That(sibling.ResolveXmlElement(), Is.Not.Null);
    }

    [Test]
    public void GetsPreviousSiblingAtEnding()
    {
        // Arrange
        var (doc, xmlElement) = ArrangeDoc();

        // Act
        var transaction = doc.ReadTransaction();
        var target = xmlElement.Get(transaction, index: 4).ResolveXmlText();
        var sibling = target.PreviousSibling(transaction);
        transaction.Commit();

        // Assert
        Assert.That(sibling.ResolveXmlElement(), Is.Not.Null);
    }

    private (Doc, XmlElement) ArrangeDoc()
    {
        var doc = new Doc();
        var xmlElement = doc.XmlElement("xml-element");

        var transaction = doc.WriteTransaction();
        xmlElement.InsertText(transaction, index: 0);
        xmlElement.InsertElement(transaction, index: 1, "width");
        xmlElement.InsertText(transaction, index: 2);
        xmlElement.InsertElement(transaction, index: 3, "color");
        xmlElement.InsertText(transaction, index: 4);
        transaction.Commit();

        return (doc, xmlElement);
    }
}
