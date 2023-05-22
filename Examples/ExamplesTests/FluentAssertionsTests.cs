using FluentAssertions;

namespace Examples.Tests;

public class FluentAssertionsTests
{
    [SetUp]
    public void Setup() {

    }

    [Test]
    public void DeepObjectEquality() {
        var catStats = new CatStats {
            Fur = {
                Color = "brown",
                Length = 17
            },
            Sound = "meow!"
        };

        catStats.Should().BeEquivalentTo(new CatStats {
            Fur = {
                Color = "brown",
                Length = 17
            },
            Sound = "meow!"
        });
    }
}