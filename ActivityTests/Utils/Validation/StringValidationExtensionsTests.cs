using System;

using Activity.Utils.Validation;

using NUnit.Framework;

namespace ActivityTests.Utils.Validation
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

    [Test]
    public void Given_ValidString_When_Validated_Then_ArgumentExceptionIsNotRaised()
    {
      // Arrange.
      const string validString = "123";

      // Act.
      // Assert.
      Assert
        .DoesNotThrow(() =>
          validString.ValidateIsNotNullOrWhitespace(
            nameof(validString)));
    }
  }
}
