// See https://aka.ms/new-console-template for more information
using System.Formats.Tar;
using System.IO.Compression;

//var p1 = Directory.GetCurrentDirectory();
//var p2 = Path.GetDirectoryName(typeof(Program).Assembly.Location);
//var p3 = Environment.CurrentDirectory;



//Console.WriteLine($"p1:{p1}");
//Console.WriteLine($"p2:{p2}");
//Console.WriteLine($"p3:{p3}");

var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);
var destinationPath = Path.Combine(basePath, "destination");
if (!Directory.Exists(destinationPath))
{
    Directory.CreateDirectory(destinationPath);
}

var directoryPath = Path.Combine(basePath, "source");
var tarPath = Path.Combine(destinationPath, "AA.tar");

TarFile.CreateFromDirectory(sourceDirectoryName: directoryPath, destinationFileName: tarPath, includeBaseDirectory: true);

TarFile.ExtractToDirectory(sourceFileName: tarPath, destinationDirectoryName: directoryPath, true);


