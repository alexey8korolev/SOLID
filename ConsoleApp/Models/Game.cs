using ConsoleApp.Enums;

namespace ConsoleApp.Models;

public class Game : IGame
{
    public int Count { get; set; }

    public int MinVal { get; }

    public int MaxVal { get; }

    public int Num { get; }

    public GameState State { get; set; }

    public Game(int minVal, int maxVal, int count, GameState state)
    {
        MinVal = minVal;
        MaxVal = maxVal;
        Count = count;
        Num = Generate(minVal, maxVal);
        State = state;
    }

    private static int Generate(int minVal, int maxVal)
    {
        return Random.Shared.Next(minVal, maxVal);
    }
}
