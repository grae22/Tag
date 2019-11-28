using System;

using NUnit.Framework;

using TagLib;

namespace TagLibTests
{
  [TestFixture]
  public class TagTests
  {
    [Test]
    public void Given_NoExistingObject_When_InstantiatedWithName_Then_NameIsSetCorrectly()
    {
      // Arrange.
      const string name = "Test";

      // Act.
      var testObject = new Tag(name);

      // Assert.
      Assert.AreEqual(name, testObject.Name);
    }

    [Test]
    public void Given_NoExistingObject_When_InstantiatedWithNullName_Then_ArgumentNullExceptionIsRaised()
    {
      // Arrange.
      const string name = null;

      // Act.
      // Assert.
      Assert
        .Throws<ArgumentNullException>(() =>
          new Tag(name));
    }

    [Test]
    public void Given_NoExistingObject_When_InstantiatedWithEmptyName_Then_ArgumentExceptionIsRaised()
    {
      // Arrange.
      const string name = "   ";

      // Act.
      // Assert.
      Assert
        .Throws<ArgumentException>(() =>
          new Tag(name));
    }
  }
}
