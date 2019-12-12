namespace TagLib
{
  public interface ITagFactory
  {
    Tag GetOrCreate(
      in string name);

    TagBag CreateTagBag();
  }
}
