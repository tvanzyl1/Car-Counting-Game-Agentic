namespace CarCounter.Models;

public class SettingsViewModel
{
    public string Colour1 { get; set; } = AvailableColours.DefaultSelection[0];
    public string Colour2 { get; set; } = AvailableColours.DefaultSelection[1];
    public string Colour3 { get; set; } = AvailableColours.DefaultSelection[2];
    public bool GameInProgress { get; set; }
}
