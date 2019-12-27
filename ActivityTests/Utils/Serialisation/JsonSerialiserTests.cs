using Activity.Utils.Serialisation;

using NUnit.Framework;

namespace ActivityTests.Utils.Serialisation
{
  [TestFixture]
  public class JsonSerialiserTests
  {
    [Test]
    public void Given_ExistingStringObject_When_Serialised_Then_IsValidJson()
    {
      // Arrange.
      const string someObject = "123";

      var testObject = new JsonSerialiser();

      // Act.
      string serialisedObject = testObject.Serialise(someObject);

      // Assert.
      Assert.AreEqual("\"123\"", serialisedObject);
    }

    [Test]
    public void Given_ExistingStringObject_When_SerialisedAndDeserialised_Then_PropertiesHaveCorrectValues()
    {
      // Arrange.
      const string someObject = "123";

      var testObject = new JsonSerialiser();

      // Act.
      string serialisedObject = testObject.Serialise(someObject);

      var deserialisedObject = testObject.Deserialise<string>(serialisedObject);

      // Assert.
      Assert.AreEqual(someObject, deserialisedObject);
    }

    [Test]
    public void Given_ExistingComplexObject_When_Serialised_Then_IsValidJson()
    {
      // Arrange.
      const int classValue = 123;
      const string otherClassValue = "123";

      var otherObject = new SomeOtherClass(otherClassValue);
      var obj = new SomeClass(classValue, otherObject);

      var testObject = new JsonSerialiser();

      // Act.
      string serialisedObject = testObject.Serialise(obj);

      // Assert.
      Assert.AreEqual(
        "{\"SomeValue\":123,\"SomeNestedObject\":{\"SomeValue\":\"123\"}}",
        serialisedObject);
    }

    [Test]
    public void Given_ExistingComplexObject_When_SerialisedAndDeserialised_Then_PropertiesHaveCorrectValues()
    {
      // Arrange.
      const int classValue = 123;
      const string otherClassValue = "123";

      var otherObject = new SomeOtherClass(otherClassValue);
      var obj = new SomeClass(classValue, otherObject);

      var testObject = new JsonSerialiser();

      // Act.
      string serialisedObject = testObject.Serialise(obj);

      var deserialisedObject = testObject.Deserialise<SomeClass>(serialisedObject);

      // Assert.
      Assert.AreEqual(classValue, deserialisedObject.SomeValue);
      Assert.AreEqual(otherClassValue, deserialisedObject.SomeNestedObject.SomeValue);
    }

    private class SomeClass
    {
      public int SomeValue { get; }

      public SomeOtherClass SomeNestedObject { get; }

      public SomeClass(
        in int someValue,
        in SomeOtherClass someNestedObject)
      {
        SomeValue = someValue;
        SomeNestedObject = someNestedObject;
      }
    }

    private class SomeOtherClass
    {
      public string SomeValue { get; }

      public SomeOtherClass(
        in string someValue)
      {
        SomeValue = someValue;
      }
    }
  }
}
