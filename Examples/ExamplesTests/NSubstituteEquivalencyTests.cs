using Examples;
using NSubstitute;
using NSubstitute.Equivalency;

namespace ExamplesTests;

public class NSubstituteEquivalencyTests
{
    private ISoundScrambler soundScrambler;
    private Cat cat;

    [SetUp]
    public void Setup() {
        soundScrambler = Substitute.For<ISoundScrambler>();

        cat = new Cat(soundScrambler);
    }

    [Test]
    public void ArgumentAssertion() {
        soundScrambler.Scramble<CatStats>(default).ReturnsForAnyArgs("meow scrambled");

        var stats = new CatStats {
            Fur = {
                Color = "red",
                Length = 3
            },
            Sound = "meow!!"
        };

        var result = cat.MeowScrambled(stats);

        Assert.That(result, Is.EqualTo("meow scrambled"));

        soundScrambler.Received(1).Scramble(ArgEx.IsEquivalentTo(new CatStats {
            Fur = {
                Color = "red",
                Length = 3
            },
            Sound = "meow!!"
        }));
    }
}