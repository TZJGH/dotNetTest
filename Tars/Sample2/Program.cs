// See https://aka.ms/new-console-template for more information
using System.Formats.Tar;


var basePath = Directory.GetCurrentDirectory();

var sourceDirectory = Path.Combine(basePath, "source");
var destinationDirectory = Path.Combine(basePath, "destination");
if (!Directory.Exists(sourceDirectory))
{
    Directory.CreateDirectory(sourceDirectory);
}
if (!Directory.Exists(destinationDirectory))
{
    Directory.CreateDirectory(destinationDirectory);
}

using (MemoryStream archiveStream = new())
{
    TarFile.CreateFromDirectory(sourceDirectoryName: sourceDirectory, destination: archiveStream, includeBaseDirectory: true);

    TarFile.ExtractToDirectory(source: archiveStream, destinationDirectoryName: destinationDirectory, overwriteFiles: true);
}

