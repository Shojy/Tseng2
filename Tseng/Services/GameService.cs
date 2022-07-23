using Shojy.FF7.Elena.Equipment;
using Shojy.FF7.Elena;
using Shojy.FF7.Reno;
using Tseng.Models;
using Tseng.Models.Enums;
using Timer = System.Threading.Timer;

namespace Tseng.Services;

public interface IGameService
{
    GameData GameData { get; }

    Task StartMonitoring();

    Task StartMonitoring(CancellationToken cancellationToken);
}

[UsedImplicitly]
public class GameService : IGameService
{
    private readonly IFF7InteractionService _ff7InteractionService;

    private CancellationToken _cancellationToken;

    private Timer? _timer;

    public GameService(IFF7InteractionService ff7InteractionService)
    {
        _ff7InteractionService = ff7InteractionService;
    }

    public GameData GameData { get; } = new();

    public Task StartMonitoring() => StartMonitoring(default);

    public async Task StartMonitoring(CancellationToken cancellationToken)
    {

        GameData.UpdateGameState(GameState.Searching);

        _cancellationToken = cancellationToken;
        var ff7 = await _ff7InteractionService.ConnectToGame();
        var ff7Folder = Path.GetDirectoryName(ff7.MainModule!.FileName)!;
        var path = Path.Combine(ff7Folder, "data", "lang-en", "kernel");
        // Read Kernel Data
        var elena = new KernelReader(Path.Combine(path, "KERNEL.BIN"))
            .MergeKernel2Data(Path.Combine(path, "kernel2.bin"));

        GameData.Init(elena.ItemData.Items, elena.WeaponData.Weapons, elena.ArmorData.Armors, elena.AccessoryData.Accessories, elena.MateriaData.Materias);

        ConfigureTimer();

        GameData.UpdateGameState(GameState.Connected);
    }

    private void ConfigureTimer()
    {
        if (_timer is not null)
        {
            KillTimer();
        }
        _timer = new Timer(ScanGame, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(100));
        _cancellationToken.Register(KillTimer);
    }

    private void KillTimer()
    {
        if (_timer is null) return;

        _timer.Change(Timeout.Infinite, Timeout.Infinite);
        _timer.Dispose();
        _timer = null;
    }

    private void ScanGame(object? _)
    {
        if (_ff7InteractionService.GetData(out var saveMap, out var battleMap))
        {
            GameData.UpdateData(saveMap, battleMap);
        }
    }
}