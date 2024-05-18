using ConsoleApp.Enums;

namespace ConsoleApp.Models;

public interface IGame
{
    int Count { get; set; }
    GameState State { get; set; }
    int MaxVal { get; }
    int MinVal { get; }
    int Num { get; }
}
