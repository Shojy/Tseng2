using System.Diagnostics;
using Shojy.FF7.Reno.Extensions;
using Shojy.FF7.Reno.MemoryAddresses;
using Shojy.FF7.Reno.Models;

namespace Shojy.FF7.Reno;

[PublicAPI]
public interface IFF7InteractionService
{
    Task ConnectToGame();
    bool GetData(out SaveMap saveMap, out BattleMap battleMap);

    Process? FF7 { get; }
}

public class FF7InteractionService : IFF7InteractionService
{
    private readonly IProcessAccessor _processAccessor;
    private readonly IMemoryAccessor _memoryAccessor;

    public Process? FF7 { get; private set; }

    public FF7InteractionService(IProcessAccessor processAccessor, IMemoryAccessor memoryAccessor)
    {
        _processAccessor = processAccessor;
        _memoryAccessor = memoryAccessor;
    }

    public async Task ConnectToGame()
    {
        var ff7 = await _processAccessor.ScanForProcess("ff7", "ff7_en");
        _memoryAccessor.SetProcess(ff7);
        FF7 = ff7;
    }

    public bool GetData(out SaveMap saveMap, out BattleMap battleMap)
    {
        var state = true;

        // Default these here to avoid a compile error for "not assigning them" before exiting on a fail state, even
        // though logically, there is no path that cannot assign them.
        saveMap = default;
        battleMap = default;

        try
        {
            if (_memoryAccessor.ReadMemory(MemoryLocations.SaveMap, out var saveBytes))
            {
                saveMap = saveBytes.ToType<SaveMap>();
            }
            else
            {
                state = false;
            }

            if (_memoryAccessor.ReadMemory(MemoryLocations.BattleMap, out var battleBytes))
            {
                battleMap = battleBytes.ToType<BattleMap>();
            }
            else
            {
                state = false;
            }
        }
        catch
        {
            state = false;
        }

        if (!state)
        {
            saveMap = default;
            battleMap = default;
        }

        return state;
    }
}