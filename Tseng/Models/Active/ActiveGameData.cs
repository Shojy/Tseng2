namespace Tseng.Models.Active;

public readonly record struct ActiveGameData(
    Character Party1,
    Character Party2,
    Character Party3,
    bool IsBattle,
    WindowColor WindowColor
)
{
}
