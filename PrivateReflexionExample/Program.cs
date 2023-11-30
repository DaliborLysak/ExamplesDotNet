using System.Reflection;
using PrivateReflexionExample;

var classWithPrivateMembers = new ClassWithPrivateMembers();

var methodResult = typeof(ClassWithPrivateMembers)
  .GetMethod("GetPrivateField", BindingFlags.Instance | BindingFlags.NonPublic)
  .Invoke(classWithPrivateMembers, Array.Empty<object>());

var fieldResult = typeof(ClassWithPrivateMembers)
  .GetField("privateField", BindingFlags.Instance | BindingFlags.NonPublic)
  .GetValue(classWithPrivateMembers);

Console.WriteLine($"Method test: {methodResult}");
Console.WriteLine($"Field test: {fieldResult}");
