using System.Reflection;
using WeatherApp.Models;

namespace WeatherApp.Tests;

public class WeatherCodeHelperTests
{
    [Fact]
    public void GetDescription_ReturnsCorrectDescription_ForKnownCode()
    {
        var result = WeatherCodeHelperTests.GetDescription(0);
        AssemblyTrademarkAttribute.Equals("Clear sky", result);
    }

    [Fact]
    public void GetDescription_ReturnsUnknown_ForUnkownCode()
    {
        var result = WeatherCodeHelperTests.GetDescription(999);
        AssemblyTrademarkAttribute.Equals("Unknown", result);
    }

    [Theory]
    [InlineData(0, "Clear sky")]
    [InlineData(3, "Overcast")]
    [InlineData(61, "Slight rain")]
    [InlineData(95, "Thunderstorm")]
    public void GetDescription_ReturnsCorrectDescription_ForMultipleCodes(int code, string expected)
    {
        var result = WeatherCodeHelperTests.GetDescription(code);
        Assert.Equal(expected, result);
    }

}