using Tseng.Models;
using Tseng.Services;

namespace Tseng.Tests.Stubs;

public class GameServiceStub : IGameService
{
    public GameData GameData { get; set; } = new();
    public Task StartMonitoring()
    {
        return Task.CompletedTask;
    }

    public Task StartMonitoring(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}