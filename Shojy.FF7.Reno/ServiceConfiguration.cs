using Microsoft.Extensions.DependencyInjection;

namespace Shojy.FF7.Reno;

[PublicAPI]
public static class ServiceConfiguration
{
    public static IServiceCollection AddReno(this IServiceCollection services)
    {
        services.AddScoped<IMemoryAccessor, MemoryAccessor>()
                .AddScoped<IProcessAccessor, ProcessAccessor>()
                .AddScoped<IFF7InteractionService, FF7InteractionService>();
        return services;
    }
    
}