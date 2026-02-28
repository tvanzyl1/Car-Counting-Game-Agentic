namespace CarCounter.Models;

public class CarCounterViewModel
{
    public const int WinningScore = 10;

    public List<CarEntry> Cars { get; set; } = [];
    public int TotalCount => Cars.Sum(c => c.Count);
    public string? Winner { get; set; }
    public bool GameOver => Winner is not null;
}

public class CarEntry
{
    public required string ColourName { get; set; }
    public required string CssClass { get; set; }
    public required string Emoji { get; set; }
    public int Count { get; set; }
}
