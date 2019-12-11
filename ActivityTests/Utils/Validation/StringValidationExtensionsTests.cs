using System;

using NUnit.Framework;

using Activity.Utils.Validation;

namespace TagTests.Utils.Validation
{
  [TestFixture]
  public class StringValidationExtensionsTests
  {
    [Test]
    public void Given_NullString_When_Validated_Then_ArgumentNullExceptionIsRaised()
    {
      // Arrange.
      const string nullString = null;

      // Act.
      // Assert.
      Assert
        .Throws<ArgumentNullException>(() =>
          nullString.ValidateIsNotNullOrWhitespace(
            nameof(nullString)));
    }

    [Test]
    public void Given_WhitespaceString_When_Validated_Then_ArgumentExceptionIsRaised()
    {
      // Arrange.
      const string whitespaceString = "  ";

      // Act.
      // Assert.
      Assert
        .Throws<ArgumentException>(() =>
          whitespaceString.ValidateIsNotNullOrWhitespace(
            nameof(whitespaceString)));
    }
  }
}
