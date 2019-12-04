using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

using TagLib;

namespace TagLibTests
{
  [TestFixture]
  public class TagFactoryTests
  {
    [Test]
    public void Given_NoExistingTagInstance_When_GettingTag_Then_TagReturned()
    {
      // Arrange.
      const string tagName = "test";

      var testObject = new TagFactory();

      // Act.
      Tag tag = testObject.GetOrCreate(tagName);

      // Assert.
      Assert.AreEqual(tagName, tag.Name);
    }

    [Test]
    public void Given_ExistingTagInstance_When_GettingTag_Then_SameTagInstanceReturned()
    {
      // Arrange.
      const string tagName = "test";

      var testObject = new TagFactory();

      Tag returnedTag1 = testObject.GetOrCreate(tagName);

      // Act.
      Tag returnedTag2 = testObject.GetOrCreate(tagName);

      // Assert.
      Assert.AreSame(returnedTag1, returnedTag2);
    }

    [Test]
    public void Given_ExistingTagInstance_When_GettingTagWithDifferentCasing_Then_SameTagInstanceReturned()
    {
      // Arrange.
      const string tagName = "test";
      const string tagNameDifferentCasing = "TEST";

      var testObject = new TagFactory();

      Tag returnedTag1 = testObject.GetOrCreate(tagName);

      // Act.
      Tag returnedTag2 = testObject.GetOrCreate(tagNameDifferentCasing);

      // Assert.
      Assert.AreSame(returnedTag1, returnedTag2);
    }

    [Test]
    public void Given_ExistingTags_When_ListRequested_Then_TagsAreReturned()
    {
      // Arrange.
      const string tagName1 = "tag1";
      const string tagName2 = "tag2";
      const string tagName3 = "tag3";

      var testObject = new TagFactory();

      Tag tag1 = testObject.GetOrCreate(tagName1);
      Tag tag2 = testObject.GetOrCreate(tagName2);
      Tag tag3 = testObject.GetOrCreate(tagName3);

      // Act.
      IEnumerable<Tag> result = testObject.Tags;

      // Assert.
      Assert.AreEqual(3, result.Count());
      Assert.Contains(tag1, result.ToArray());
      Assert.Contains(tag2, result.ToArray());
      Assert.Contains(tag3, result.ToArray());
    }
  }
}
