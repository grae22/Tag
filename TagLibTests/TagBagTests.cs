using System.Linq;

using NSubstitute;

using NUnit.Framework;

using TagLib;
using TagLib.Exceptions;

namespace TagLibTests
{
  [TestFixture]
  public class TagBagTests
  {
    [Test]
    public void Given_NoBag_When_BagInstantiated_Then_BagShouldBeEmpty()
    {
      // Arrange.
      var tagFactory = Substitute.For<ITagFactory>();

      // Act.
      var testObject = new TagBag(tagFactory);

      // Assert.
      Assert.IsFalse(testObject.Tags.Any());
    }

    [Test]
    public void Given_EmptyBag_When_TagIsAdded_Then_BagShouldContainTag()
    {
      // Arrange.
      const string tagName = "tag";

      var tagFactory = Substitute.For<ITagFactory>();

      tagFactory
        .GetOrCreate(tagName)
        .Returns(new Tag(tagName));

      var testObject = new TagBag(tagFactory);

      // Act.
      testObject.AddTag(tagName);

      // Assert.
      Tag tag = testObject
        .Tags
        .FirstOrDefault(t => t.Name.Equals(tagName));

      Assert.IsNotNull(tag);
    }

    [Test]
    public void Given_Bag_When_TagIsAddedAndFactoryReturnsNull_Then_ExceptionShouldBeRaised()
    {
      // Arrange.
      const string tagName = "tag";

      var tagFactory = Substitute.For<ITagFactory>();

      tagFactory
        .GetOrCreate(tagName)
        .Returns((Tag)null);

      var testObject = new TagBag(tagFactory);

      // Act.
      // Assert.
      Assert.Throws<NullTagException>(() => testObject.AddTag(tagName));
    }

    [Test]
    public void Given_BagWithTag_When_SameTagIsAddedAgain_Then_BagShouldNotContainDuplicateTags()
    {
      // Arrange.
      const string tagName = "tag";

      var tagFactory = Substitute.For<ITagFactory>();

      tagFactory
        .GetOrCreate(tagName)
        .Returns(new Tag(tagName));

      var testObject = new TagBag(tagFactory);

      testObject.AddTag(tagName);

      // Act.
      testObject.AddTag(tagName);

      // Assert.
      Assert.AreEqual(1, testObject.Tags.Count());
    }

    [Test]
    public void Given_BagWithTags_When_SameTagIsRemoved_Then_BagShouldNotContainTag()
    {
      // Arrange.
      const string tagName1 = "tag1";
      const string tagName2 = "tag2";
      const string tagName3 = "tag3";

      var tagFactory = Substitute.For<ITagFactory>();

      tagFactory
        .GetOrCreate(tagName1)
        .Returns(new Tag(tagName1));

      tagFactory
        .GetOrCreate(tagName2)
        .Returns(new Tag(tagName2));

      tagFactory
        .GetOrCreate(tagName3)
        .Returns(new Tag(tagName3));

      var testObject = new TagBag(tagFactory);

      testObject.AddTag(tagName1);
      testObject.AddTag(tagName2);
      testObject.AddTag(tagName3);

      // Act.
      testObject.RemoveTag(tagName2);

      // Assert.
      Assert.IsNull(
        testObject
          .Tags
          .FirstOrDefault(t => t.Name.Equals(tagName2)));

      Assert.AreEqual(2, testObject.Tags.Count());
    }

    [Test]
    public void Given_BagWithTags_When_SameTagIsRemovedUsingDifferentNameCasing_Then_BagShouldNotContainTag()
    {
      // Arrange.
      const string tagName1 = "tag1";
      const string tagName2 = "tag2";
      const string tagName3 = "tag3";

      var tagFactory = Substitute.For<ITagFactory>();

      tagFactory
        .GetOrCreate(tagName1)
        .Returns(new Tag(tagName1));

      tagFactory
        .GetOrCreate(tagName2)
        .Returns(new Tag(tagName2));

      tagFactory
        .GetOrCreate(tagName3)
        .Returns(new Tag(tagName3));

      var testObject = new TagBag(tagFactory);

      testObject.AddTag(tagName1);
      testObject.AddTag(tagName2);
      testObject.AddTag(tagName3);

      // Act.
      testObject.RemoveTag(tagName2.ToUpper());

      // Assert.
      Assert.IsNull(
        testObject
          .Tags
          .FirstOrDefault(t => t.Name.Equals(tagName2)));

      Assert.AreEqual(2, testObject.Tags.Count());
    }

    [Test]
    public void Given_BagWithTags_When_SomeOtherTagIsRemoved_Then_BagShouldNotChange()
    {
      // Arrange.
      const string tagName1 = "tag1";
      const string tagName2 = "tag2";
      const string tagName3 = "tag3";

      var tagFactory = Substitute.For<ITagFactory>();

      tagFactory
        .GetOrCreate(tagName1)
        .Returns(new Tag(tagName1));

      tagFactory
        .GetOrCreate(tagName2)
        .Returns(new Tag(tagName2));

      tagFactory
        .GetOrCreate(tagName3)
        .Returns(new Tag(tagName3));

      var testObject = new TagBag(tagFactory);

      testObject.AddTag(tagName1);
      testObject.AddTag(tagName2);
      testObject.AddTag(tagName3);

      // Act.
      testObject.RemoveTag("someOtherTag");

      // Assert.
      Assert.AreEqual(3, testObject.Tags.Count());
    }
  }
}
