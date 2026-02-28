namespace CarCounter.Models;

public record ColourOption(string Name, string CssClass, string Emoji);

public static class AvailableColours
{
    public static readonly string[] DefaultSelection = ["Red", "Blue", "Green"];

    public static readonly IReadOnlyList<ColourOption> All =
    [
        new("Red", "btn-danger", "🚗"),
        new("Blue", "btn-primary", "🚙"),
        new("Green", "btn-success", "🚕"),
        new("Yellow", "btn-warning text-dark", "🚕"),
        new("Black", "btn-dark", "🚗"),
    ];

    public static ColourOption? Get(string name) =>
        All.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
}
