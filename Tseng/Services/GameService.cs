using Shojy.FF7.Elena.Equipment;
using Shojy.FF7.Elena;
using Shojy.FF7.Reno;
using Shojy.FF7.Reno.Extensions;
using Shojy.FF7.Reno.MemoryAddresses;
using Shojy.FF7.Reno.MemoryAddresses.Offsets;
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
        _ff7InteractionService.GetData(new(new(SaveMapOffsets.NumberOfSecondsPlayed), 4), out var time);
        if (_ff7InteractionService.GetData(out var saveMap, out var battleMap)
            && _ff7InteractionService.GetData(MemoryLocations.ActiveBattleFlag, out var activeBattle)
            
            && _ff7InteractionService.GetData(MemoryLocations.ActiveWindowColor, out var colors))
        {
            // set active window color
            var color = MakeWindowColor(colors);
            GameData.UpdateData(saveMap, battleMap, color, activeBattle[0] == 0x01, BitConverter.ToInt32(time));
        }
    }

    private static WindowColor MakeWindowColor(byte[] colors)
    {
        var color = new WindowColor(
            TopLeft: Color.FromArgb(colors[0x2], colors[0x1], colors[0x0]),
            TopRight: Color.FromArgb(colors[0xA], colors[0x9], colors[0x8]),
            BottomLeft: Color.FromArgb(colors[0x6], colors[0x5], colors[0x4]),
            BottomRight: Color.FromArgb(colors[0xE], colors[0xD], colors[0xC])
        );
        return color;
    }
}