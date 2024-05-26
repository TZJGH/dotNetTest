// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;


#if true
//BenchmarkRunner.Run(typeof(Test));
BenchmarkSwitcher.FromAssembly(typeof(Test).Assembly).Run(args);

[HideColumns("Error")]
[DisassemblyDiagnoser]
public class Test
{
    [Benchmark]
    public int Sum() => Sum(1000);


    public static int Sum(int count)
    {
        var r = 0;
        for (int i = 1; i <= count; i++)
        {
            r += i;
        }
        return r;
    }
}
#endif

