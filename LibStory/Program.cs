using LibStory;
using LibStory.Application;
using LibStory.Application.Helpers;
using LibStory.Application.Interfaces;
using LibStory.Application.Queries;
using LibStory.Infrastructure;
using LibStory.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SQLitePCL;

public class Program
{
    public static void Main(string[] args)
    {
        Batteries.Init();
        var services = new ServiceCollection();
        services.AddLogging();
        services.AddTransient<IBookService, BookService>();
        services.AddTransient<IBookRepository, SqlLiteRepository>();
        services.AddTransient<IManager, ConsoleManager>();
        services.AddSingleton<IMainMenu, ConsoleMenu>();
        services.AddSingleton<App>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<AppLayerDummy>());
        services.AddDbContext<SqlLiteDbContext>(opt =>
            opt.UseSqlite($"Data Source={PathHelper.GetDbPath()}"));

        var serviceProvider = services.BuildServiceProvider();

        var app = serviceProvider.GetService<App>();
        var dbContext = serviceProvider.GetService<SqlLiteDbContext>();
        dbContext?.Database.EnsureCreated();
        app.Run();

    }
}