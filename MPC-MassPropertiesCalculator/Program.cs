using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MPCDataManagerLibrary.Models;

class Program
{

    static void Main(string[] args)
    {
        MainMenu();
        // Dependency Insction ref https://youtu.be/GAOCe-2nXqc 25:06
        var host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddSingleton<IMassPropItem, MassPropItem>();
                services.AddSingleton<IMassPropTotal,MassPropTotal>();
            })
            .Build();
    }
}

