using ConsoleApp.Enums;
using ConsoleApp.Logic;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp;

public static class Menu
{
    public static void Show(IServiceProvider serviceProvider)
    {
        Console.WriteLine();
        Console.WriteLine("<<< Играем в игру! >>>");
        Console.WriteLine();

        while (true)
        {
            var serviceGame = serviceProvider.GetService<IGameLogic>()!;

            serviceGame.Start();
            serviceGame.Play();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Сыграем в игру еще раз (Д/Н) ?");

                var cmd = Console.ReadLine()!.Trim().ToUpper();

                if (cmd != "Д" && cmd != "Н")
                {
                    Console.WriteLine("Введите корректную команду : Д:(Да), Н:(Нет)");
                }
                else if (cmd == "Д")
                {
                    break;
                }
                else
                {
                    return;
                }
            }
        }
    }
}
