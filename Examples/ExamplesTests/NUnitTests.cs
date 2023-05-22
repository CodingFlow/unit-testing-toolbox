using Examples;
using NSubstitute;

namespace ExamplesTests;

public class NUnitTests
{
    private ISoundScrambler soundScrambler;
    private Cat cat;

    [SetUp]
    public void Setup() {
        soundScrambler = Substitute.For<ISoundScrambler>();

        cat = new Cat(soundScrambler);
    }

    [TestCase(0, "", "Meow")]
    [TestCase(1, "", "Meow!")]
    [TestCase(2, "", "Meow!!")]
    [TestCase(0, " ", "Meow")]
    [TestCase(0, "something", "Meow something")]
    [TestCase(1, "something", "Meow! something")]
    public void DifferentInputs(int volume, string sound, string expected) {
        var result = cat.Meow(volume, sound);

        Assert.That(result, Is.EqualTo(expected));
    }

    private static List<TestCaseData> DifferentInputs_Source = new() {
        new(new CatStats {
            Fur = { },
            Sound = ""
        }, ""),
        new(new CatStats {
            Fur = { },
            Sound = "some sound"
        }, "some sound")
    };

    [TestCaseSource(nameof(DifferentInputs_Source))]
    public void DifferentInputsDynamic(CatStats stats, string expected) {
        var result = cat.MeowFromStats(stats);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Exception() {
        var exception = Assert.Throws<Exception>(() => cat.MeowError());

        Assert.That(exception, Has.Message.EqualTo("Meow error!"));
        Assert.That(exception, Has.InnerException.Message.EqualTo("Inner meow error!"));
    }
}
