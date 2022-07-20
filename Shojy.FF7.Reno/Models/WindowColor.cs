using System.Runtime.InteropServices;

namespace Shojy.FF7.Reno.Models;

[PublicAPI]
[StructLayout(LayoutKind.Explicit, Size = 0xC)]
public record struct WindowColor
{
    [FieldOffset(0x0)]
    public FFColor TopLeft;

    [FieldOffset(0x3)]
    public FFColor TopRight;

    [FieldOffset(0x6)]
    public FFColor BottomLeft;

    [FieldOffset(0x9)]
    public FFColor BottomRight;
}