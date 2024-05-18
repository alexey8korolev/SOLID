using ConsoleApp.Configuration;
using ConsoleApp.Enums;
using ConsoleApp.Logic;
using ConsoleApp.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp;

public static class AppService
{
    public static IServiceProvider Register()
    {
        var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", false);

        IConfigurationRoot configuration = builder.Build();
        var gameConfig = configuration.Get<GameConfig>();

        var serviceProvider = new ServiceCollection()
            .AddTransient<IGameLogic, GameLogic>()
            .AddTransient<IGame>(sp =>
                new Game(gameConfig!.MinVal, gameConfig.MaxVal, gameConfig.Count, GameState.Undefined))
            .BuildServiceProvider();

        return serviceProvider;
    }
}
