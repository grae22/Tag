using System;

using Activity.Utils.Validation;

using NUnit.Framework;

namespace ActivityTests.Utils.Validation
{
  [TestFixture]
  public class ObjectValidationExtensionsTests
  {
    [Test]
    public void Given_NullObject_When_Validated_Then_ArgumentNullExceptionIsRaised()
    {
      // Arrange.
      const object nullObject = null;

      // Act.
      // Assert.
      Assert
        .Throws<ArgumentNullException>(() =>
          nullObject.ValidateIsNotNull(
            nameof(nullObject)));
    }

    [Test]
    public void Given_NonNullObject_When_Validated_Then_ArgumentExceptionIsNotRaised()
    {
      // Arrange.
      var whitespaceString = new object();

      // Act.
      // Assert.
      Assert
        .DoesNotThrow(() =>
          whitespaceString.ValidateIsNotNull(
            nameof(whitespaceString)));
    }
  }
}
