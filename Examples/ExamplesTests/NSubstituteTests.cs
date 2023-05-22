using NSubstitute;

namespace Examples.Tests;

public class NSubstituteTests
{
    private ISoundScrambler soundScrambler;
    private Cat cat;

    [SetUp]
    public void Setup() {
        soundScrambler = Substitute.For<ISoundScrambler>();

        cat = new Cat(soundScrambler);
    }

    [Test]
    public void MockDependency() {
        soundScrambler.Scramble(default).ReturnsForAnyArgs("meow scrambled");

        var result = cat.MeowScrambled();

        Assert.That(result, Is.EqualTo("meow scrambled"));

        soundScrambler.Received(1).Scramble("meow");
    }
}