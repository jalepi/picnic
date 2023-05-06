using Picnic.Pipelines;

namespace Tests.Picnic.Pipelines;

[TestClass]
public class UnitTest
{
    [DataTestMethod]
    [DataRow("hello world")]
    public void Pipe_TransformationSequence_ProducesResult(string input)
    {
        static string ExpectedResult(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            var base64 = Convert.ToBase64String(bytes);
            return base64;
        }

        var expected = ExpectedResult(input);
        var actual = input
                .Pipe(Encoding.UTF8.GetBytes)
                .Pipe(Convert.ToBase64String)
            ;

        Assert.AreEqual(expected, actual);
    }
}