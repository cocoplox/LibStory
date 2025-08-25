using LibStory;
using LibStory.Application.Interfaces;
using LibStory.Application.Queries;
using LibStory.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    public static void Main(string[] args)
    {
        var services = new ServiceCollection();
        services.AddLogging(); 
        services.AddTransient<IBookService, BookService>();
        services.AddTransient<IBookRepository, FileRepository>();
        services.AddTransient<IManager, ConsoleManager>();
        services.AddSingleton<IMainMenu, ConsoleMenu>();
        services.AddSingleton<App>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<AddBookQuery>());
        var serviceProvider = services.BuildServiceProvider();

        var app = serviceProvider.GetService<App>();
        app.Run();

    }
}