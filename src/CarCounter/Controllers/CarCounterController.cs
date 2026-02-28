using Microsoft.AspNetCore.Mvc;
using CarCounter.Models;

namespace CarCounter.Controllers;

public class CarCounterController : Controller
{
    private static readonly string[] ColourSessionKeys =
        ["SelectedColour1", "SelectedColour2", "SelectedColour3"];

    public IActionResult Index()
    {
        var model = BuildViewModel();
        return View(model);
    }

    [HttpPost]
    public IActionResult Increment(string colour)
    {
        var model = BuildViewModel();
        if (model.GameOver)
            return RedirectToAction(nameof(Index));

        var selectedColours = GetSelectedColours();
        if (!selectedColours.Contains(colour, StringComparer.OrdinalIgnoreCase))
            return RedirectToAction(nameof(Index));

        var key = CountKey(colour);
        var current = HttpContext.Session.GetInt32(key) ?? 0;
        HttpContext.Session.SetInt32(key, current + 1);

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult Reset()
    {
        foreach (var colour in GetSelectedColours())
            HttpContext.Session.Remove(CountKey(colour));
        return RedirectToAction(nameof(Index));
    }

    internal static string[] GetSelectedColours(ISession session)
    {
        return
        [
            session.GetString(ColourSessionKeys[0]) ?? AvailableColours.DefaultSelection[0],
            session.GetString(ColourSessionKeys[1]) ?? AvailableColours.DefaultSelection[1],
            session.GetString(ColourSessionKeys[2]) ?? AvailableColours.DefaultSelection[2],
        ];
    }

    internal static string CountKey(string colour) => $"Count_{colour}";

    private string[] GetSelectedColours() => GetSelectedColours(HttpContext.Session);

    private CarCounterViewModel BuildViewModel()
    {
        var colours = GetSelectedColours();
        var cars = new List<CarEntry>();
        string? winner = null;

        foreach (var colourName in colours)
        {
            var option = AvailableColours.Get(colourName);
            if (option is null) continue;

            var count = HttpContext.Session.GetInt32(CountKey(colourName)) ?? 0;
            cars.Add(new CarEntry
            {
                ColourName = option.Name,
                CssClass = option.CssClass,
                Emoji = option.Emoji,
                Count = count
            });

            if (winner is null && count >= CarCounterViewModel.WinningScore)
                winner = option.Name;
        }

        return new CarCounterViewModel
        {
            Cars = cars,
            Winner = winner
        };
    }
}
