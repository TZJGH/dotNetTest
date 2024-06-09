// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Text.RegularExpressions;

Stopwatch sw = Stopwatch.StartNew();
SourceGeneratorsTest.EvaluateText("aaaaaaaaaaaaaaaaaaaaaaaaaa!");
sw.Stop();
Console.WriteLine(sw.ElapsedMilliseconds);

sw.Restart();
SourceGeneratorsTest.EvaluateText("aaaaaaaaaaaaaaaaaaaaaaaaaa");
sw.Stop();
Console.WriteLine(sw.ElapsedMilliseconds);

public partial class SourceGeneratorsTest
{
    [GeneratedRegex(@"^(a+)+$", RegexOptions.IgnoreCase | RegexOptions.Compiled)]
    private static partial Regex AbcOrDefGeneratedRegex();

    public static void EvaluateText(string text)
    {
        if (AbcOrDefGeneratedRegex().IsMatch(text))
        {
            Console.WriteLine($"{text} 合法");
        }
        else
        {
            Console.WriteLine($"{text} 不合法");
        }
    }

}
