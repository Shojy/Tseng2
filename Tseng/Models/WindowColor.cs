namespace Tseng.Models;

public struct WindowColor
{
    public Color TopLeft { get; set; }

    public Color TopRight { get; set; }

    public Color BottomLeft { get; set; }

    public Color BottomRight { get; set; }

    private Color? _color;
    public Color Average => _color ??= GetAverageColor();
    
    /// <summary>
    /// Calculates the average color from the 4 positional colors. 
    /// </summary>
    /// <returns></returns>
    private Color GetAverageColor()
    {
        return Color.FromArgb(
            red: GetValueAverage(TopLeft.R, TopRight.R, BottomLeft.R, BottomRight.R),
            green: GetValueAverage(TopLeft.G, TopRight.G, BottomLeft.G, BottomRight.G),
            blue: GetValueAverage(TopLeft.B, TopRight.B, BottomLeft.B, BottomRight.B)
        );
    }

    /// <summary>
    /// Uses a 
    /// </summary>
    /// <param name="values"></param>
    /// <returns></returns>
    private static int GetValueAverage(params int[] values)
    {
        double sum = values.Sum(v => v * v);
        var mean = Math.Sqrt(sum / values.Length);
        return (int)Math.Round(mean);
    }
}