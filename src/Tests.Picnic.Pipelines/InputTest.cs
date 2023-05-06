using Picnic.Pipelines;

namespace Tests.Picnic.Pipelines;

[TestClass]
public class InputTest
{
    [DataTestMethod]
    [DataRow("hello world")]
    public void Input_Sequence_ProducesResult(string input)
    {
        static string ExpectedResult(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            var base64 = Convert.ToBase64String(bytes);
            return base64;
        }

        var expected = ExpectedResult(input);

        var pipe = Pipe.Of<string>()
            .Connect(Encoding.UTF8.GetBytes)
            .Connect(Convert.ToBase64String)
            ;
        var actual = pipe.Send(input);

        Assert.AreEqual(actual, expected);
    }
}
