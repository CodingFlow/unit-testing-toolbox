namespace Examples;

public interface ICat
{
    string Meow(int volume, string extraSound);

    string MeowScrambled();

    string MeowScrambled(CatStats stats);
}