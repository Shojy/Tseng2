using Shojy.FF7.Elena.Equipment;

namespace Tseng.Models.Active;

public readonly record struct Character(
    string Name,
    byte Level,
    ushort CurrentHP,
    ushort MaxHP,
    ushort CurrentMP,
    ushort MaxMP,
    Weapon Weapon,
    Armor Armor,
    Accessory? Accessory,
    string Image,
    string Row
    )
{
    public string WeaponName => Weapon.Name;

    public string ArmorName => Armor.Name;

    public string AccessoryName => Accessory?.Name ?? string.Empty;

    public bool HasAccessory => Accessory is not null;

    public bool IsDead => CurrentHP == 0;

    public bool IsLucky => CurrentHP == 7777;

    public bool IsLowHealth => CurrentHP <= MaxHP / 4;

    public string WeaponType
    {
        get
        {
            if (Weapon.EquipableBy.HasFlag(EquipableBy.Cloud) || Weapon.EquipableBy.HasFlag(EquipableBy.YoungCloud))
                return "sword";
            if (Weapon.EquipableBy.HasFlag(EquipableBy.Barret))
                return "arm";
            if (Weapon.EquipableBy.HasFlag(EquipableBy.Tifa))
                return "glove";
            if (Weapon.EquipableBy.HasFlag(EquipableBy.Aeris))
                return "staff";
            if (Weapon.EquipableBy.HasFlag(EquipableBy.RedXIII))
                return "hairpin";
            if (Weapon.EquipableBy.HasFlag(EquipableBy.Yuffie))
                return "shuriken";
            if (Weapon.EquipableBy.HasFlag(EquipableBy.CaitSith))
                return "megaphone";
            if (Weapon.EquipableBy.HasFlag(EquipableBy.Vincent))
                return "gun";
            if (Weapon.EquipableBy.HasFlag(EquipableBy.Cid))
                return "pole";


            return "other";
        }
    }

}