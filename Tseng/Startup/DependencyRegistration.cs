using Tseng.Services;

namespace Tseng.Startup;

public static class DependencyRegistration
{
    private static readonly CounterService Counter = new();
    private static ServiceCollection _sharedServices;
    public static IServiceCollection SharedServiceCollection => _sharedServices ??= new ServiceCollection();

    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddSingleton<ICounterService>(_ => Counter);

        return services;
    }
}