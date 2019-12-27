// TODO: This class currently provides no way for Activity Types to be given "default tags" on instantiation.

using System;
using System.Collections.Generic;

using TagLib;

namespace Activity.Domain.Activity
{
  internal class ActivityFactory
  {
    private readonly ITagFactory _tagFactory;
    private readonly Dictionary<string, ActivityType> _activitiesByName = new Dictionary<string, ActivityType>(StringComparer.OrdinalIgnoreCase);

    public ActivityFactory(
      in ITagFactory tagFactory)
    {
      _tagFactory = tagFactory ?? throw new ArgumentNullException(nameof(tagFactory));
    }

    public ActivityType GetOrCreate(
      in string name)
    {
      if (_activitiesByName.ContainsKey(name))
      {
        return _activitiesByName[name];
      }

      IReadOnlyTagBag defaultTags = _tagFactory.CreateTagBag();

      var newActivity = new ActivityType(
        _tagFactory,
        name,
        defaultTags);

      _activitiesByName.Add(name, newActivity);

      return newActivity;
    }
  }
}
