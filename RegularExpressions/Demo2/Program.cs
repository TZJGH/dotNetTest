using System.Text.RegularExpressions;

ReadOnlySpan<char> text = "Shall I compare thee to a summer’s day";

foreach (ValueMatch m in MyRegex().EnumerateMatches(text))
{
    Console.WriteLine($"Word: {text.Slice(m.Index, m.Length)}");
}

Console.WriteLine($"Count:{MyRegex().Count(text)}");

Console.WriteLine($"IsMatch:{MyRegex().IsMatch(text)}");

partial class Program
{
    [GeneratedRegex(@"\b\w+\b")]
    private static partial Regex MyRegex();
}
