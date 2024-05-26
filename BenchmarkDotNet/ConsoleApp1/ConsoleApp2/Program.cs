using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Security.Cryptography;

namespace ConsoleApp2
{
    public class Md5VsSha256
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
            for (int i = 0; i < 1000; i++)
            {
                r += i;
            }
            return r;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Md5VsSha256>();
        }
    }
}
