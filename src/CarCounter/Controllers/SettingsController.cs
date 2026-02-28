using Microsoft.AspNetCore.Mvc;
using CarCounter.Models;

namespace CarCounter.Controllers;

public class SettingsController : Controller
{
    private static readonly string[] ColourSessionKeys =
        ["SelectedColour1", "SelectedColour2", "SelectedColour3"];

    public IActionResult Index()
    {
        var colours = GetSelectedColours();
        var model = new SettingsViewModel
        {
            Colour1 = colours[0],
            Colour2 = colours[1],
            Colour3 = colours[2],
            GameInProgress = IsGameInProgress(colours)
        };
        return View(model);
    }

    [HttpPost]
    public IActionResult Save(SettingsViewModel model)
    {
        var selected = new[] { model.Colour1, model.Colour2, model.Colour3 };

        if (selected.Distinct(StringComparer.OrdinalIgnoreCase).Count() < 3)
        {
            ModelState.AddModelError("", "Each car must be a different colour.");
            model.GameInProgress = IsGameInProgress(GetSelectedColours());
            return View("Index", model);
        }

        if (selected.Any(c => AvailableColours.Get(c) is null))
        {
            ModelState.AddModelError("", "One or more selected colours are invalid.");
            model.GameInProgress = IsGameInProgress(GetSelectedColours());
            return View("Index", model);
        }

        // Clear counts for previously selected colours
        foreach (var c in GetSelectedColours())
            HttpContext.Session.Remove(CarCounterController.CountKey(c));

        // Save new colour selections
        HttpContext.Session.SetString(ColourSessionKeys[0], selected[0]);
        HttpContext.Session.SetString(ColourSessionKeys[1], selected[1]);
        HttpContext.Session.SetString(ColourSessionKeys[2], selected[2]);

        return RedirectToAction("Index", "CarCounter");
    }

    private string[] GetSelectedColours() =>
        CarCounterController.GetSelectedColours(HttpContext.Session);

    private bool IsGameInProgress(string[] colours) =>
        colours.Any(c => (HttpContext.Session.GetInt32(CarCounterController.CountKey(c)) ?? 0) > 0);
}
