using System;

namespace TagLib.Exceptions
{
  public class NullTagException : Exception
  {
    public NullTagException(in string tagName)
    :
      base($"Null tag object encountered for tag name \"{tagName}\".")
    {
    }
  }
}
