// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var currentDateTime=DateTime.Now;

Console.WriteLine(currentDateTime.Microsecond / currentDateTime.Nanosecond);
Console.WriteLine($"currentDateTime:{currentDateTime}");
Console.WriteLine($"currentDateTime:{currentDateTime.AddMicroseconds(10)}");

TimeOnly