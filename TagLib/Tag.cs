using System;

namespace TagLib
{
  public class Tag
  {
    public string Name { get; }

    public Tag(
      in string name)
    {
      Name = SanitiseName(name);
    }

    private static string SanitiseName(
      in string name)
    {
      string sanitisedName = name ?? throw new ArgumentNullException(nameof(name));

      sanitisedName = sanitisedName.Trim();

      if (sanitisedName.Length == 0)
      {
        throw new ArgumentException("Name cannot be blank.");
      }

      return sanitisedName;
    }
  }
}
