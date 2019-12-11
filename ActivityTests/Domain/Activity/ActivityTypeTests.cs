using System.Linq;

using Activity.Domain.Activity;

using NSubstitute;

using NUnit.Framework;

using TagLib;

namespace ActivityTests.Domain.Activity
{
  [TestFixture]
  public class ActivityTypeTests
  {
    [Test]
    public void Given_NoInstance_When_Instantiated_Then_NameIsCorrect()
    {
      // Arrange.
      const string name = "TestName";

      var defaultTags = Substitute.For<IReadOnlyTagBag>();

      // Act.
      var testObject = new ActivityType(
        name,
        defaultTags);

      // Assert.
      Assert.AreEqual(name, testObject.Name);
    }

    [Test]
    public void Given_NoInstance_When_Instantiated_Then_HasSpecifiedDefaultTags()
    {
      // Arrange.
      const string name = "TestName";
      const string tagName1 = "tag1";
      const string tagName2 = "tag2";

      var tagFactory = new TagFactory();
      var defaultTags = new TagBag(tagFactory);

      defaultTags.AddTag(tagName1);
      defaultTags.AddTag(tagName2);

      // Act.
      var testObject = new ActivityType(
        name,
        defaultTags);

      // Assert.
      Assert.AreEqual(2, testObject.DefaultTags.Count());

      Tag tag1 = testObject.DefaultTags.First(t => t.Name.Equals(tagName1));
      Tag tag2 = testObject.DefaultTags.First(t => t.Name.Equals(tagName2));

      Assert.IsNotNull(tag1);
      Assert.IsNotNull(tag2);
    }
  }
}
