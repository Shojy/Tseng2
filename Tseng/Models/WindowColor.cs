namespace Tseng.Models;

public record struct WindowColor(Color TopLeft, Color TopRight, Color BottomLeft, Color BottomRight)
{
    public static WindowColor Default { get; } = new(
        Color.FromArgb(0, 0, 176),
        Color.FromArgb(0, 0, 80),
        Color.FromArgb(0, 0, 128),
        Color.FromArgb(0, 0, 32)
        );

    public Color Average => GetAverageColor();

    
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
    /// Uses a squared mean to calculate the average colour
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