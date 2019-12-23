using System;

namespace Activity.Utils.Validation
{
  internal static class StringValidationExtensions
  {
    public static void ValidateIsNotNullOrWhitespace(
      this string argument,
      in string argumentName)
    {
      argument.ValidateIsNotNull(argumentName);

      if (string.IsNullOrWhiteSpace(argument))
      {
        throw new ArgumentException(
          "Cannot be empty or whitespace.",
          argumentName);
      }
    }
  }
}
