using System.Diagnostics;
using Shojy.FF7.Elena;

namespace Tseng.Services;

public interface IElenaService
{
    object ReadGameData(Process ff7);
    object ReadGameData(string ff7Folder);
}


[UsedImplicitly]
public class ElenaService : IElenaService
{
    public object ReadGameData(Process ff7) => ReadGameData(ff7.MainModule!.FileName!);

    public object ReadGameData(string ff7Folder)
    {
        var path = Path.Combine(ff7Folder, "data", "lang-en", "kernel");

        var elena = new KernelReader(Path.Combine(path, "KERNEL.BIN"))
            .MergeKernel2Data(Path.Combine(path, "kernel2.bin"));

        return elena.KeyItemNames.Strings;
    }
    
}