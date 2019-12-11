using System.Collections.Generic;

namespace TagLib
{
  public interface IReadOnlyTagBag : IEnumerable<Tag>
  {
    IReadOnlyTagBag Clone();
  }
}
