// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<Tests>();

[MemoryDiagnoser]
[DisassemblyDiagnoser]
[ThreadingDiagnoser]
[JsonExporter]
public class Tests
{
    //private const int N = 10000;
    //private readonly byte[] data;

    //private readonly SHA256 sha256 = SHA256.Create();
    //private readonly MD5 md5 = MD5.Create();

    //public Md5VsSha256()
    //{
    //    data = new byte[N];
    //    new Random(42).NextBytes(data);
    //}

    //[Benchmark]
    //public byte[] Sha256() => sha256.ComputeHash(data);

    //[Benchmark]
    //public byte[] Md5() => md5.ComputeHash(data);


    [Benchmark]
    public int Sum()
    {
        int r = 0;
        for (int i = 1; i <= 1000; i++)
        {
            r += i;
        }
        return r;
    }

    [Benchmark]
    public int Sum2()
    {
        return (1 + 1000) * 1000 / 2;
    }
}