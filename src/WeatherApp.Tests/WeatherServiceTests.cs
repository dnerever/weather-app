using WeatherApp.Services;

namespace WeatherApp.Tests;

public class WeatherServiceTests
{
    private WeatherService CreateService(string json)
    {
        var handler = new MockHttpMessageHandler(json);
        var httpClient = new HttpClient(handler);
        return new WeatherService(httpClient);
    }

    [Fact]
    public async Task GetLocationAsync_ReturnsLocation_WhenCityFound()
    {
        var json = """
            {
            "results": [
                { "name": "London", "latitude": 51.5, "longitude": -0.12, "country": "UK" }
                ]
            }
            """;

        var service = CreateService(json);
        var result = await service.GetLocationAsync("London");

        Assert.NotNull(result);
        Assert.Equal("London", result.Name);
        Assert.Equal(51.5, result.Latitude);
    }

    [Fact]
    public async Task GetWeatherAsync_ReturnsWeatherData_WhenApiResponds()
    {
        var json = """
            {
                "current": {
                    "temperature_2m": 15.5,
                    "wind_speed_10m": 10.2,
                    "weather_code": 3
                }
            }
            """;
        
        var service = CreateService(json);
        var result = await service.GetWeatherAsync(51.5, -0.12);

        Assert.NotNull(result);
        Assert.NotNull(result.Current);
        Assert.Equal(15.5, result.Current.Temperature2m);
        Assert.Equal(10.2, result.Current.WindSpeed10m);
        Assert.Equal(3, result.Current.WeatherCode);
    }
}