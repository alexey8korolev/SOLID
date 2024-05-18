using ConsoleApp;

IServiceProvider serviceProvider = AppService.Register();

Menu.Show(serviceProvider);
