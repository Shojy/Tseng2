namespace Tseng.Models;

public readonly record struct AssetMap(int ColorPalette, decimal CropXRatio, decimal CropYRatio, decimal LocationXRatio, decimal LocationYRatio, string ExtractedFile, string FileWithinLgp, string LgpArchiveFile);

public static class Assets
{
    public static AssetMap Accessory { get; } = new()
    {
        LgpArchiveFile = MenuLgp,
        ExtractedFile = "accessory.png",
        FileWithinLgp = "btl_win_c_l.tex",
        ColorPalette = 1,
        CropXRatio = IconRatio,
        CropYRatio = IconRatio,
        LocationXRatio = 7 / 8m,
        LocationYRatio = 4 / 8m,
    };

    public static AssetMap AerisPortrait { get; } = new()
    {
        LgpArchiveFile = MenuLgp,
        ExtractedFile = "character-aeris.png",
        FileWithinLgp = "earith.tex",
        ColorPalette = 0,
        CropXRatio = PortraitWidthRatio,
        CropYRatio = PortraitHeightRatio,
        LocationYRatio = 0,
        LocationXRatio = 0,
    };

    public static AssetMap Armlet { get; } = new()
    {
        LgpArchiveFile = MenuLgp,
        ExtractedFile = "armlet.png",
        FileWithinLgp = "btl_win_c_l.tex",
        ColorPalette = 1,
        CropXRatio = IconRatio,
        CropYRatio = IconRatio,
        LocationXRatio = 6 / 8m,
        LocationYRatio = 4 / 8m,
    };

    public static AssetMap BarretPortrait { get; } = new()
    {
        LgpArchiveFile = MenuLgp,
        ExtractedFile = "character-barret.png",
        FileWithinLgp = "barre.tex",
        ColorPalette = 0,
        CropXRatio = PortraitWidthRatio,
        CropYRatio = PortraitHeightRatio,
        LocationYRatio = 0,
        LocationXRatio = 0,
    };

    public static AssetMap CaitSithPortrait { get; } = new()
    {
        LgpArchiveFile = MenuLgp,
        ExtractedFile = "character-cait-sith.png",
        FileWithinLgp = "ketc.tex",
        ColorPalette = 0,
        CropXRatio = PortraitWidthRatio,
        CropYRatio = PortraitHeightRatio,
        LocationYRatio = 0,
        LocationXRatio = 0,
    };

    public static AssetMap CidPortrait { get; } = new()
    {
        LgpArchiveFile = MenuLgp,
        ExtractedFile = "character-cid.png",
        FileWithinLgp = "cido.tex",
        ColorPalette = 0,
        CropXRatio = PortraitWidthRatio,
        CropYRatio = PortraitHeightRatio,
        LocationYRatio = 0,
        LocationXRatio = 0,
    };

    public static AssetMap CloudPortrait { get; } = new()
    {
        LgpArchiveFile = MenuLgp,
        ExtractedFile = "character-cloud.png",
        FileWithinLgp = "cloud.tex",
        ColorPalette = 0,
        CropXRatio = PortraitWidthRatio,
        CropYRatio = PortraitHeightRatio,
        LocationYRatio = 0,
        LocationXRatio = 0,
    };

    public static AssetMap MateriaCommand { get; } = new()
    {
        LgpArchiveFile = MenuLgp,
        ExtractedFile = "materia-command.png",
        FileWithinLgp = "btl_win_b_l.tex",
        ColorPalette = 8,
        CropXRatio = 18 / 256m,
        CropYRatio = 18 / 256m,
        LocationXRatio = 3 / 256m,
        LocationYRatio = 67 / 256m,
    };

    public static AssetMap MateriaIndependent { get; } = new()
    {
        LgpArchiveFile = MenuLgp,
        ExtractedFile = "materia-independent.png",
        FileWithinLgp = "btl_win_b_l.tex",
        ColorPalette = 9,
        CropXRatio = 18 / 256m,
        CropYRatio = 18 / 256m,
        LocationXRatio = 3 / 256m,
        LocationYRatio = 67 / 256m,
    };

    public static AssetMap MateriaMagic { get; } = new()
    {
        LgpArchiveFile = MenuLgp,
        ExtractedFile = "materia-magic.png",
        FileWithinLgp = "btl_win_b_l.tex",
        ColorPalette = 4,
        CropXRatio = 18 / 256m,
        CropYRatio = 18 / 256m,
        LocationXRatio = 3 / 256m,
        LocationYRatio = 67 / 256m,
    };

    public static AssetMap MateriaSummon { get; } = new()
    {
        LgpArchiveFile = MenuLgp,
        ExtractedFile = "materia-summon.png",
        FileWithinLgp = "btl_win_b_l.tex",
        ColorPalette = 10,
        CropXRatio = 18 / 256m,
        CropYRatio = 18 / 256m,
        LocationXRatio = 3 / 256m,
        LocationYRatio = 67 / 256m,
    };

    public static AssetMap MateriaSupport { get; } = new()
    {
        LgpArchiveFile = MenuLgp,
        ExtractedFile = "materia-support.png",
        FileWithinLgp = "btl_win_b_l.tex",
        ColorPalette = 5,
        CropXRatio = 18 / 256m,
        CropYRatio = 18 / 256m,
        LocationXRatio = 3 / 256m,
        LocationYRatio = 67 / 256m,
    };

    public static AssetMap RedXIIIPortrait { get; } = new()
    {
        LgpArchiveFile = MenuLgp,
        ExtractedFile = "character-red-xiii.png",
        FileWithinLgp = "red.tex",
        ColorPalette = 0,
        CropXRatio = PortraitWidthRatio,
        CropYRatio = PortraitHeightRatio,
        LocationYRatio = 0,
        LocationXRatio = 0,
    };

    public static AssetMap SephirothPortrait { get; } = new()
    {
        LgpArchiveFile = MenuLgp,
        ExtractedFile = "character-sephiroth.png",
        FileWithinLgp = "pcefi.tex",
        ColorPalette = 0,
        CropXRatio = PortraitWidthRatio,
        CropYRatio = PortraitHeightRatio,
        LocationYRatio = 0,
        LocationXRatio = 0,
    };

    public static AssetMap SlotLink { get; } = new()
    {
        LgpArchiveFile = MenuLgp,
        ExtractedFile = "slot-link.png",
        FileWithinLgp = "btl_win_a_h.tex",
        ColorPalette = 1,
        CropXRatio = 14 / 256m,
        CropYRatio = 24 / 256m,
        LocationXRatio = 227 / 256m,
        LocationYRatio = 95 / 256m,
    };

    public static AssetMap SlotNormal { get; } = new()
    {
        LgpArchiveFile = MenuLgp,
        ExtractedFile = "slot-normal.png",
        FileWithinLgp = "btl_win_b_h.tex",
        ColorPalette = 1,
        CropXRatio = 24 / 256m,
        CropYRatio = 24 / 256m,
        LocationXRatio = 0,
        LocationYRatio = 95 / 256m,
    };

    public static AssetMap SlotNothing { get; } = new()
    {
        LgpArchiveFile = MenuLgp,
        ExtractedFile = "slot-nothing.png",
        FileWithinLgp = "btl_win_a_h.tex",
        ColorPalette = 1,
        CropXRatio = 24 / 256m,
        CropYRatio = 24 / 256m,
        LocationXRatio = 7 / 8m,
        LocationYRatio = 63 / 256m,
    };

    public static AssetMap TifaPortrait { get; } = new()
    {
        LgpArchiveFile = MenuLgp,
        ExtractedFile = "character-tifa.png",
        FileWithinLgp = "tifa.tex",
        ColorPalette = 0,
        CropXRatio = PortraitWidthRatio,
        CropYRatio = PortraitHeightRatio,
        LocationYRatio = 0,
        LocationXRatio = 0,
    };

    public static AssetMap VincentPortrait { get; } = new()
    {
        LgpArchiveFile = MenuLgp,
        ExtractedFile = "character-vincent.png",
        FileWithinLgp = "bins.tex",
        ColorPalette = 0,
        CropXRatio = PortraitWidthRatio,
        CropYRatio = PortraitHeightRatio,
        LocationYRatio = 0,
        LocationXRatio = 0,
    };

    public static AssetMap WeaponArm { get; } = new()
    {
        LgpArchiveFile = MenuLgp,
        ExtractedFile = "weapon-arm.png",
        FileWithinLgp = "btl_win_c_l.tex",
        ColorPalette = 1,
        CropXRatio = IconRatio,
        CropYRatio = IconRatio,
        LocationXRatio = 6 / 8m,
        LocationYRatio = 0 / 8m,
    };

    public static AssetMap WeaponGlove { get; } = new()
    {
        LgpArchiveFile = MenuLgp,
        ExtractedFile = "weapon-glove.png",
        FileWithinLgp = "btl_win_c_l.tex",
        ColorPalette = 1,
        CropXRatio = IconRatio,
        CropYRatio = IconRatio,
        LocationXRatio = 7 / 8m,
        LocationYRatio = 0 / 8m,
    };

    public static AssetMap WeaponGun { get; } = new()
    {
        LgpArchiveFile = MenuLgp,
        ExtractedFile = "weapon-gun.png",
        FileWithinLgp = "btl_win_c_l.tex",
        ColorPalette = 1,
        CropXRatio = IconRatio,
        CropYRatio = IconRatio,
        LocationXRatio = 6 / 8m,
        LocationYRatio = 3 / 8m,
    };

    public static AssetMap WeaponHairpin { get; } = new()
    {
        LgpArchiveFile = MenuLgp,
        ExtractedFile = "weapon-hairpin.png",
        FileWithinLgp = "btl_win_c_l.tex",
        ColorPalette = 1,
        CropXRatio = IconRatio,
        CropYRatio = IconRatio,
        LocationXRatio = 7 / 8m,
        LocationYRatio = 1 / 8m,
    };

    public static AssetMap WeaponMegaphone { get; } = new()
    {
        LgpArchiveFile = MenuLgp,
        ExtractedFile = "weapon-megaphone.png",
        FileWithinLgp = "btl_win_c_l.tex",
        ColorPalette = 1,
        CropXRatio = IconRatio,
        CropYRatio = IconRatio,
        LocationXRatio = 7 / 8m,
        LocationYRatio = 2 / 8m,
    };

    public static AssetMap WeaponPole { get; } = new()
    {
        LgpArchiveFile = MenuLgp,
        ExtractedFile = "weapon-pole.png",
        FileWithinLgp = "btl_win_c_l.tex",
        ColorPalette = 1,
        CropXRatio = IconRatio,
        CropYRatio = IconRatio,
        LocationXRatio = 7 / 8m,
        LocationYRatio = 3 / 8m,
    };

    public static AssetMap WeaponShuriken { get; } = new()
    {
        LgpArchiveFile = MenuLgp,
        ExtractedFile = "weapon-shuriken.png",
        FileWithinLgp = "btl_win_c_l.tex",
        ColorPalette = 1,
        CropXRatio = IconRatio,
        CropYRatio = IconRatio,
        LocationXRatio = 6 / 8m,
        LocationYRatio = 2 / 8m,
    };

    public static AssetMap WeaponStaff { get; } = new()
    {
        LgpArchiveFile = MenuLgp,
        ExtractedFile = "weapon-staff.png",
        FileWithinLgp = "btl_win_c_l.tex",
        ColorPalette = 1,
        CropXRatio = IconRatio,
        CropYRatio = IconRatio,
        LocationXRatio = 6 / 8m,
        LocationYRatio = 1 / 8m,
    };

    public static AssetMap WeaponSword { get; } = new()
    {
        LgpArchiveFile = MenuLgp,
        ExtractedFile = "weapon-sword.png",
        FileWithinLgp = "btl_win_a_l.tex",
        ColorPalette = 1,
        CropXRatio = IconRatio,
        CropYRatio = IconRatio,
        LocationXRatio = 7 / 8m,
        LocationYRatio = 7 / 8m,
    };

    public static AssetMap YoungCloudPortrait { get; } = new()
    {
        LgpArchiveFile = MenuLgp,
        ExtractedFile = "character-young-cloud.png",
        FileWithinLgp = "pcloud.tex",
        ColorPalette = 0,
        CropXRatio = PortraitWidthRatio,
        CropYRatio = PortraitHeightRatio,
        LocationYRatio = 0,
        LocationXRatio = 0,
    };

    public static AssetMap YuffiePortrait { get; } = new()
    {
        LgpArchiveFile = MenuLgp,
        ExtractedFile = "character-yuffie.png",
        FileWithinLgp = "yufi.tex",
        ColorPalette = 0,
        CropXRatio = PortraitWidthRatio,
        CropYRatio = PortraitHeightRatio,
        LocationYRatio = 0,
        LocationXRatio = 0,
    };

    private const decimal IconRatio = 1 / 8m;
    private const string MenuLgp = "data/menu/menu_us.lgp";
    private const decimal PortraitHeightRatio = 96 / 128m;
    private const decimal PortraitWidthRatio = 84 / 128m;
    public static string AssetBaseLocation { get; } = Path.Combine("wwwroot", "images");

    public static string AssetStagingLocation { get; } = Path.Combine("wwwroot", "staging");
}