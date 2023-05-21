namespace Examples;

public class Cat : ICat
{
    public string Meow(int volume, string extraSound) {
        return $"Meow{Enumerable.Repeat("!", volume)} {extraSound}";
    }
}
