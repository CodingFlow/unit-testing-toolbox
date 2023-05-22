using System.IO.Abstractions;

namespace Examples;
public class FileCat : IFileCat
{
    private readonly IFileSystem fileSystem;

    public FileCat(IFileSystem fileSystem) {
        this.fileSystem = fileSystem;
    }

    public async Task<string> Meow() {
        return await fileSystem.File.ReadAllTextAsync("catsound.txt");
    }
}
