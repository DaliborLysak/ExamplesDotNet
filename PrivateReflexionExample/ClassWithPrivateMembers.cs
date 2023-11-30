namespace PrivateReflexionExample;

public class ClassWithPrivateMembers
{
    private string privateField = "Test";

    private string GetPrivateField()
    {
        return this.privateField;
    }

}
