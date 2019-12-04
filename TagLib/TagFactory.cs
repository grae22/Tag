using System;
using System.Collections.Generic;

namespace TagLib
{
  public class TagFactory : ITagFactory
  {
    public IEnumerable<Tag> Tags => _tags.Values;

    private readonly Dictionary<string, Tag> _tags = new Dictionary<string, Tag>(StringComparer.OrdinalIgnoreCase);

    public Tag GetOrCreate(
      in string name)
    {
      Tag tag;

      if (_tags.ContainsKey(name))
      {
        tag = _tags[name];
      }
      else
      {
        tag = new Tag(name);

        _tags.Add(
          tag.Name,
          tag);
      }

      return tag;
    }
  }
}
