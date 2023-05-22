using Examples;
using NSubstitute;
using System.IO.Abstractions;

namespace ExamplesTests;

public class FileSystemTests
{
    private IFileSystem fileSystem;
    private FileCat fileCat;

    [SetUp]
    public void Setup() {
        fileSystem = Substitute.For<IFileSystem>();

        fileCat = new FileCat(fileSystem);
    }

    [Test]
    public async Task MockDependencyAsync() {
        fileSystem.File.ReadAllTextAsync(default).ReturnsForAnyArgs("meow");

        var result = await fileCat.Meow();

        Assert.That(result, Is.EqualTo("meow"));

        await fileSystem.File.Received(1).ReadAllTextAsync("catsound.txt");
    }
}