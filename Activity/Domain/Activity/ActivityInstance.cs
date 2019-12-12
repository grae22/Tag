﻿// TODO: Add methods for adding/removing tags.

using System;

using TagLib;

namespace Activity.Domain.Activity
{
  internal class ActivityInstance
  {
    public ActivityType ActivityType { get; }
    public DateTime Timestamp { get; }
    public IReadOnlyTagBag Tags => _tags;

    private readonly TagBag _tags;

    public ActivityInstance(
      in ITagFactory tagFactory,
      in ActivityType activityType,
      in DateTime timestamp)
    {
      if (tagFactory == null)
      {
        throw new ArgumentNullException(nameof(tagFactory));
      }

      _tags = tagFactory.CreateTagBag();
      ActivityType = activityType ?? throw new ArgumentNullException(nameof(activityType));
      Timestamp = timestamp;

      CopyDefaultTagsFromActivityType();
    }

    private void CopyDefaultTagsFromActivityType()
    {
      foreach (Tag tag in ActivityType.DefaultTags)
      {
        _tags.AddTag(tag.Name);
      }
    }
  }
}
