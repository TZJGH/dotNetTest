// See https://aka.ms/new-console-template for more information


using System.Numerics;

Console.WriteLine(Add(int.Parse(args[0]), int.Parse(args[1])));

static T Add<T>(T left, T right)
    where T : INumber<T>
{
    return left + right;
}