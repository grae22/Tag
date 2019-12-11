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

      var defaultTags = Substitute.For<ITagBagReader>();

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
      const string tag1 = "tag1";
      const string tag2 = "tag2";

      var defaultTags = Substitute.For<ITagBagReader>();

      defaultTags
        .GetEnumerator()
        .Returns(new[]
          {
            new TagLib.Tag(tag1), // TODO: Having to use the full namespace coz the main project is called Tag... :(
            new TagLib.Tag(tag2)
          }
          .ToList()
          .GetEnumerator());

      // Act.
      var testObject = new ActivityType(
        name,
        defaultTags);

      // Assert.
      Assert.AreEqual(2, testObject.DefaultTags.Count());
    }
  }
}
