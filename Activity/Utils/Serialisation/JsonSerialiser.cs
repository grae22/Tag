using Newtonsoft.Json;

namespace Activity.Utils.Serialisation
{
  internal class JsonSerialiser : ISerialiser
  {
    public string Serialise<T>(
      in T something)
    {
      return JsonConvert.SerializeObject(something);
    }

    public T Deserialise<T>(
      in string serialisedSomething)
    {
      return JsonConvert.DeserializeObject<T>(serialisedSomething);
    }
  }
}
