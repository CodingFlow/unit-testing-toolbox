namespace Examples;

public interface ISoundScrambler
{
    string Scramble(string sound);

    string Scramble<T>(T stats);
}