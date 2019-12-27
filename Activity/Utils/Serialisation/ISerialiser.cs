namespace Activity.Utils.Serialisation
{
  internal interface ISerialiser
  {
    string Serialise<T>(in T something);
    T Deserialise<T>(in string serialisedSomething);
  }
}
