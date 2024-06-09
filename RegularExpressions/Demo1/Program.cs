// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Text.RegularExpressions;
string pattern = "^(a+)+$";
string input = "aaaaaaaaaaaaaaaaaaaaaaaaaa!"; 

Stopwatch stopwatch = Stopwatch.StartNew();
Console.WriteLine(Regex.IsMatch(input, pattern, RegexOptions.NonBacktracking));
stopwatch.Stop();
Console.WriteLine(stopwatch.ElapsedMilliseconds);

stopwatch.Restart();
Console.WriteLine(Regex.IsMatch(input, pattern,RegexOptions.RightToLeft));
stopwatch.Stop();
Console.WriteLine(stopwatch.ElapsedMilliseconds);

stopwatch.Restart();
Console.WriteLine(Regex.IsMatch(input, pattern,RegexOptions.Compiled));
stopwatch.Stop();
Console.WriteLine(stopwatch.ElapsedMilliseconds);
