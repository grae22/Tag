﻿using System;

namespace Tag.Utils.Validation
{
  internal static class StringValidationExtensions
  {
    public static void ValidateIsNotNullOrWhitespace(
      this string argument,
      in string argumentName)
    {
      if (argument == null)
      {
        throw new ArgumentNullException(argumentName);
      }

      if (string.IsNullOrWhiteSpace(argument))
      {
        throw new ArgumentException(
          "Cannot be empty or whitespace.",
          argumentName);
      }
    }
  }
}
