using Shojy.FF7.Elena.Converters;
using Shojy.FF7.Elena;
using System.Drawing.Imaging;
using Shojy.FF7.Reno;
using Tseng.Models;

namespace Tseng.Services;

public interface IAssetExtractionService
{
    Task ExtractAllAssets();
}

public class AssetExtractionService : IAssetExtractionService
{
    private readonly IFF7InteractionService _ff7InteractionService;

    public AssetExtractionService(IFF7InteractionService ff7InteractionService)
    {
        _ff7InteractionService = ff7InteractionService;
    }

    public async Task ExtractAllAssets()
    {

        var ff7 = await _ff7InteractionService.ConnectToGame();
        var ff7Folder = Path.GetDirectoryName(ff7.MainModule!.FileName)!;

        AssetExtractor.ExtractAssets(ff7Folder);
    }
}

public static class AssetExtractor
{
    private static readonly string AssetBaseLocation = Path.Combine("wwwroot", "images");
    private static readonly string AssetStagingLocation = Path.Combine("wwwroot", "staging");

    private static readonly AssetMap[] RequiredAssets =
    {
            Assets.CloudPortrait,
            Assets.BarretPortrait,
            Assets.TifaPortrait,
            Assets.AerisPortrait,
            Assets.RedXIIIPortrait,
            Assets.YuffiePortrait,
            Assets.CaitSithPortrait,
            Assets.VincentPortrait,
            Assets.CidPortrait,
            Assets.YoungCloudPortrait,
            Assets.SephirothPortrait,

            Assets.WeaponSword,
            Assets.WeaponArm,
            Assets.WeaponGlove,
            Assets.WeaponStaff,
            Assets.WeaponHairpin,
            Assets.WeaponShuriken,
            Assets.WeaponMegaphone,
            Assets.WeaponGun,
            Assets.WeaponPole,

            Assets.Armlet,
            Assets.Accessory,

            Assets.MateriaMagic,
            Assets.MateriaSupport,
            Assets.MateriaSummon,
            Assets.MateriaCommand,
            Assets.MateriaIndependent,

            Assets.SlotNormal,
            Assets.SlotNothing,
            Assets.SlotLink,
        };


    public static List<AssetMap> IsAssetExtractionRequired()
    {
        return RequiredAssets
            .Where(asset => !File.Exists(Path.Combine(AssetBaseLocation, asset.ExtractedFile)))
            .ToList();
    }

    public static void ExtractAssets(string ff7Path, IReadOnlyList<AssetMap>? requiredAssets = null)
    {
        requiredAssets ??= RequiredAssets;

        // Ensure containing directory is present
        Directory.CreateDirectory(AssetBaseLocation);

        // Group by containing archive
        var archiveGroup = requiredAssets
            .GroupBy(a => a.LgpArchiveFile)
            .ToDictionary(g => g.Key, g => g.ToList());


        foreach (var archive in archiveGroup)
        {
            // Group by containing file
            var fileGroup = archive.Value
                .GroupBy(f => f.FileWithinLgp)
                .ToDictionary(g => g.Key, g => g.ToList());

            using var lgp = new LgpReader(Path.Combine(ff7Path, archive.Key));

            foreach (var file in fileGroup)
            {
                ProcessPalettesInFile(file, lgp);
            }
        }
    }

    private static void ProcessPalettesInFile(KeyValuePair<string, List<AssetMap>> file, LgpReader lgp)
    {
        // Group by palette
        var paletteGroup = file.Value
            .GroupBy(p => p.ColorPalette)
            .ToDictionary(p => p.Key, p => p.ToList());


        using var dataStream = lgp.ExtractFile(file.Key);

        foreach (var palette in paletteGroup)
        {
            ProcessFileContents(dataStream, palette);
        }
    }

    private static void ProcessFileContents(Stream dataStream, KeyValuePair<int, List<AssetMap>> palette)
    {
        var bmp = TexConverter.ToBitmap(dataStream, palette.Key);

        foreach (var asset in palette.Value)
        {
            using var fileWriter = new StreamWriter(Path.Combine(AssetBaseLocation, asset.ExtractedFile));

            var croppedBmp = ExtractSegment(asset, bmp);

            croppedBmp.Save(fileWriter.BaseStream, ImageFormat.Png);
        }
    }

    [Pure]
    private static Bitmap ExtractSegment(AssetMap asset, Image bmp)
    {
        // Crop and save
        using var fileWriter = new StreamWriter(Path.Combine(AssetBaseLocation, asset.ExtractedFile));

        var croppedWidth = (int)(bmp.Width * asset.CropXRatio);
        var croppedHeight = (int)(bmp.Height * asset.CropYRatio);

        var crop = new Rectangle(
            (int)(bmp.Width * asset.LocationXRatio),
            (int)(bmp.Height * asset.LocationYRatio),
            croppedWidth,
            croppedHeight);
        Bitmap croppedBmp = new(croppedWidth, croppedHeight);

        using var g = Graphics.FromImage(croppedBmp);

        g.DrawImage(
            bmp,
            new Rectangle(0, 0, croppedBmp.Width, croppedBmp.Height),
            crop,
            GraphicsUnit.Pixel);

        return croppedBmp;
    }
}
