using Shojy.FF7.Reno;
using Tseng.Services;

namespace Tseng.Startup;

public static class DependencyRegistration
{
    private static readonly CounterService Counter = new();

    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddSingleton<ICounterService>(_ => Counter);
        services.AddSingleton<IGameService, GameService>();
        services.AddSingleton<IAssetExtractionService, AssetExtractionService>();
        services.AddReno();
        return services;
    }
}