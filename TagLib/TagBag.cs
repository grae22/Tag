using System;
using System.Collections.Generic;
using System.Linq;

using TagLib.Exceptions;

namespace TagLib
{
  public class TagBag
  {
    public IEnumerable<Tag> Tags => _tags;

    private readonly ITagFactory _tagFactory;
    private readonly List<Tag> _tags = new List<Tag>();

    public TagBag(in ITagFactory tagFactory)
    {
      _tagFactory = tagFactory ?? throw new ArgumentNullException(nameof(tagFactory));
    }

    public void AddTag(in string name)
    {
      Tag tag = _tagFactory.GetOrCreate(name);

      if (tag == null)
      {
        throw new NullTagException(name);
      }

      if (_tags.Contains(tag))
      {
        return;
      }

      _tags.Add(tag);
    }

    public void RemoveTag(in string name)
    {
      string nameCopy = name;

      Tag tag = _tags
        .FirstOrDefault(t =>
          t.Name.Equals(nameCopy, StringComparison.OrdinalIgnoreCase));

      if (tag == null)
      {
        return;
      }

      _tags.Remove(tag);
    }
  }
}
