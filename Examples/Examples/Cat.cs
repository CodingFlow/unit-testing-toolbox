﻿namespace Examples;

public class Cat : ICat
{
    private readonly ISoundScrambler soundScrambler;

    public Cat(ISoundScrambler soundScrambler) {
        this.soundScrambler = soundScrambler;
    }

    public string Meow(int volume, string extraSound) {
        return $"Meow{string.Join("", Enumerable.Repeat("!", volume))} {extraSound}".TrimEnd();
    }

    public string MeowFromStats(CatStats stats) {
        return stats.Sound;
    }

    public string MeowScrambled() {
        return soundScrambler.Scramble("meow");
    }

    public string MeowScrambled(CatStats stats) {
        return soundScrambler.Scramble(stats);
    }
}
