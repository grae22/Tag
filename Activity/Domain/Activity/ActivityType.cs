using System;

using Activity.Utils.Validation;

using TagLib;

namespace Activity.Domain.Activity
{
  internal class ActivityType
  {
    public string Name { get; }
    public IReadOnlyTagBag DefaultTags { get; }

    public ActivityType(
      in string name,
      in IReadOnlyTagBag defaultTags)
    {
      name.ValidateIsNotNullOrWhitespace(nameof(name));

      Name = name;
      DefaultTags = defaultTags?.Clone() ?? throw new ArgumentNullException(nameof(defaultTags));
    }
  }
}
