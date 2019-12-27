using Activity.Domain.Activity;

using NUnit.Framework;

using TagLib;

namespace ActivityTests.Domain.Activity
{
  [TestFixture]
  public class ActivityFactoryTests
  {
    [Test]
    public void Given_NoActivitiesCreated_When_ActivityIsCreated_Then_ActivityInstanceIsReturned()
    {
      // Arrange.
      const string activityName = "activity";

      var tagFactory = new TagFactory();
      var testObject = new ActivityFactory(tagFactory);

      // Act.
      ActivityType result = testObject.GetOrCreate(activityName);

      // Assert.
      Assert.IsNotNull(result);
    }

    [Test]
    public void Given_ActivityCreatedPreviously_When_ActivityIsCreatedAgain_Then_SameActivityInstanceIsReturned()
    {
      // Arrange.
      const string activityName = "activity";

      var tagFactory = new TagFactory();
      var testObject = new ActivityFactory(tagFactory);

      ActivityType activity1 = testObject.GetOrCreate(activityName);

      // Act.
      ActivityType activity2 = testObject.GetOrCreate(activityName);

      // Assert.
      Assert.AreSame(activity1, activity2);
    }
  }
}
