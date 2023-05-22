namespace Examples;

public interface ICat
{
    string Meow(int volume, string extraSound);
    string MeowFromStats(CatStats stats);
    string MeowScrambled();

    string MeowScrambled(CatStats stats);
}