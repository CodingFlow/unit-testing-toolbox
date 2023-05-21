namespace Examples;

public class Cat : ICat
{
    private readonly ISoundScrambler soundScrambler;

    public Cat(ISoundScrambler soundScrambler) {
        this.soundScrambler = soundScrambler;
    }

    public string Meow(int volume, string extraSound) {
        return $"Meow{Enumerable.Repeat("!", volume)} {extraSound}";
    }

    public string MeowScrambled() {
        return soundScrambler.Scramble("meow");
    }

    public string MeowScrambled(CatStats stats) {
        return soundScrambler.Scramble(stats);
    }
}
