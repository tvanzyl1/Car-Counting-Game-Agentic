using CarCounter.Models;

namespace CarCounter.Tests;

public class CarCounterViewModelTests
{
    [Fact]
    public void TotalCount_Returns_Sum_Of_All_Cars()
    {
        var model = new CarCounterViewModel
        {
            Cars =
            [
                new CarEntry { ColourName = "Red", CssClass = "btn-danger", Emoji = "🚗", Count = 3 },
                new CarEntry { ColourName = "Blue", CssClass = "btn-primary", Emoji = "🚙", Count = 5 },
                new CarEntry { ColourName = "Green", CssClass = "btn-success", Emoji = "🚕", Count = 2 },
            ]
        };

        Assert.Equal(10, model.TotalCount);
    }

    [Fact]
    public void TotalCount_Returns_Zero_When_No_Cars()
    {
        var model = new CarCounterViewModel();

        Assert.Equal(0, model.TotalCount);
    }

    [Fact]
    public void GameOver_Is_False_When_No_Winner()
    {
        var model = new CarCounterViewModel
        {
            Cars =
            [
                new CarEntry { ColourName = "Red", CssClass = "btn-danger", Emoji = "🚗", Count = 5 },
            ]
        };

        Assert.Null(model.Winner);
        Assert.False(model.GameOver);
    }

    [Fact]
    public void GameOver_Is_True_When_Winner_Set()
    {
        var model = new CarCounterViewModel { Winner = "Red" };

        Assert.True(model.GameOver);
    }

    [Fact]
    public void WinningScore_Is_Ten()
    {
        Assert.Equal(10, CarCounterViewModel.WinningScore);
    }
}

public class AvailableColoursTests
{
    [Fact]
    public void All_Contains_Five_Colours()
    {
        Assert.Equal(5, AvailableColours.All.Count);
    }

    [Fact]
    public void DefaultSelection_Contains_Three_Colours()
    {
        Assert.Equal(3, AvailableColours.DefaultSelection.Length);
    }

    [Theory]
    [InlineData("Red")]
    [InlineData("Blue")]
    [InlineData("Green")]
    [InlineData("Yellow")]
    [InlineData("Black")]
    public void Get_Returns_Colour_By_Name(string name)
    {
        var colour = AvailableColours.Get(name);

        Assert.NotNull(colour);
        Assert.Equal(name, colour.Name);
    }

    [Fact]
    public void Get_Returns_Null_For_Unknown_Colour()
    {
        Assert.Null(AvailableColours.Get("Purple"));
    }

    [Fact]
    public void DefaultSelection_Colours_Are_All_Distinct()
    {
        Assert.Equal(
            AvailableColours.DefaultSelection.Length,
            AvailableColours.DefaultSelection.Distinct().Count());
    }
}
