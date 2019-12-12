using System;

using Activity.Utils.Validation;

using TagLib;

namespace Activity.Domain.Activity
{
  internal class ActivityType
  {
    public string Name { get; }
    public IReadOnlyTagBag DefaultTags { get; }

    private readonly ITagFactory _tagFactory;

    public ActivityType(
      in ITagFactory tagFactory,
      in string name,
      in IReadOnlyTagBag defaultTags)
    {
      _tagFactory = tagFactory ?? throw new ArgumentNullException(nameof(tagFactory));

      name.ValidateIsNotNullOrWhitespace(nameof(name));

      Name = name;
      DefaultTags = defaultTags?.Clone() ?? throw new ArgumentNullException(nameof(defaultTags));
    }

    public ActivityInstance CreateInstance()
    {
      return new ActivityInstance(
        _tagFactory,
        this,
        DateTime.UtcNow);
    }
  }
}
