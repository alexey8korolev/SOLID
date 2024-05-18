using ConsoleApp.Enums;
using ConsoleApp.Models;

namespace ConsoleApp.Logic;

public class GameLogic : IGameLogic
{
    private readonly IGame _curGame;

    public GameLogic(IGame curGame)
    {
        _curGame = curGame;
    }

    public void Start()
    {
        Console.WriteLine();
        Console.WriteLine("<<< Угадай число! >>>");
        Console.WriteLine("--> Начинается новая игра... >>>");
        Console.WriteLine();

        _curGame.State = GameState.Play;
    }

    public void Play()
    {
        if (_curGame.State != GameState.Play)
        {
            Console.WriteLine(@"Игра ""Угадай число"" некорректное состояние");
            return;
        };

        while (true)
        {

            Console.WriteLine(@$"Введите число в диапазоне от {_curGame.MinVal} до {_curGame.MaxVal}.
Количество попыток равно {_curGame.Count}:              загадано {_curGame.Num}");

            var curNumStr = Console.ReadLine()!;

            if (curNumStr.Any(char.IsLetter))
            {
                Console.WriteLine($"Необходимо задать число!");
                continue;
            }

            var curNum = Convert.ToInt32(curNumStr);

            _curGame.Count--;

            if (curNum == _curGame.Num)
            {
                _curGame.State = GameState.Win;
                Console.WriteLine($"Вы выиграли!!! Правильно это число {curNum}");
                break;

            }

            if (_curGame.Count > 0)
            {
                if (curNum > _curGame.Num)
                {
                    _curGame.State = GameState.More;
                    Console.WriteLine($"Число {curNum} больше загаданного");
                }
                else
                {
                    _curGame.State = GameState.Less;
                    Console.WriteLine($"Число {curNum} меньше загаданного");
                }
            }
            else
            {
                _curGame.State = GameState.Fail;
                Console.WriteLine($"Вы проиграли. Было загадано число {_curGame.Num}");
                break;
            }
        }
    }
}
