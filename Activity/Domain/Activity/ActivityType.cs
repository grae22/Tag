using System;

using Activity.Utils.Validation;

using TagLib;

namespace Activity.Domain.Activity
{
  internal class ActivityType
  {
    public string Name { get; }
    public ITagBagReader DefaultTags { get; }

    public ActivityType(
      in string name,
      in ITagBagReader defaultTags)
    {
      name.ValidateIsNotNullOrWhitespace(nameof(name));

      Name = name;
      DefaultTags = defaultTags ?? throw new ArgumentNullException(nameof(defaultTags));
    }
  }
}
