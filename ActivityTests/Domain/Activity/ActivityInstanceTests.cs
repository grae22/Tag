using System;
using System.Linq;

using Activity.Domain.Activity;

using NSubstitute;

using NUnit.Framework;

using TagLib;

namespace ActivityTests.Domain.Activity
{
  [TestFixture]
  public class ActivityInstanceTests
  {
    [Test]
    public void Given_NoInstance_When_Instantiated_Then_HasCorrectActivityType()
    {
      // Arrange.
      const string typeName = "TypeName";

      var tagFactory = Substitute.For<ITagFactory>();
      var tagBag = Substitute.For<IReadOnlyTagBag>();

      var activityType = new ActivityType(
        tagFactory,
        typeName,
        tagBag);

      // Act.
      var testObject = new ActivityInstance(
        tagFactory,
        activityType,
        DateTime.UtcNow);

      // Assert.
      Assert.AreSame(activityType, testObject.ActivityType);
    }

    [Test]
    public void Given_NoInstance_When_Instantiated_Then_HasCorrectTimestamp()
    {
      // Arrange.
      const string typeName = "TypeName";

      var tagFactory = Substitute.For<ITagFactory>();
      var defaultTags = Substitute.For<IReadOnlyTagBag>();

      var activityType = new ActivityType(
        tagFactory,
        typeName,
        defaultTags);

      DateTime timestamp = DateTime.Now;

      // Act.
      var testObject = new ActivityInstance(
        tagFactory,
        activityType,
        timestamp);

      // Assert.
      Assert.AreEqual(timestamp, testObject.Timestamp);
    }

    [Test]
    public void Given_NoInstance_When_Instantiated_Then_HasDefaultTagsFromActivityType()
    {
      // Arrange.
      const string typeName = "TypeName";
      const string tagName1 = "tag1";
      const string tagName2 = "tag2";

      var tagFactory = new TagFactory();
      var defaultTags = new TagBag(tagFactory);

      defaultTags.AddTag(tagName1);
      defaultTags.AddTag(tagName2);

      var activityType = new ActivityType(
        tagFactory,
        typeName,
        defaultTags);

      DateTime timestamp = DateTime.Now;

      // Act.
      var testObject = new ActivityInstance(
        tagFactory,
        activityType,
        timestamp);

      // Assert.
      Assert.IsNotNull(testObject.Tags.FirstOrDefault(t => t.Name.Equals(tagName1)));
      Assert.IsNotNull(testObject.Tags.FirstOrDefault(t => t.Name.Equals(tagName2)));
    }
  }
}
