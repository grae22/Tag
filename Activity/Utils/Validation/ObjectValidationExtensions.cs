using System;

namespace Activity.Utils.Validation
{
  internal static class ObjectValidationExtensions
  {
    public static void ValidateIsNotNull(
      this object obj,
      in string argumentName)
    {
      if (obj == null)
      {
        throw new ArgumentNullException(argumentName);
      }
    }
  }
}
