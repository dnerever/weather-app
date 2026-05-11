using System.Text.Json.Serialization;

namespace WeatherApp.Models;

public class WeatherResponse
{
    public CurrentWeather? Current { get; set; }
    public CurrentWeatherUnits? CurrentUnits { get; set; }
    public DailyWeather? Daily { get; set; }
}

public class CurrentWeather
{
    [JsonPropertyName("temperature_2m")]
    public double Temperature2m { get; set; }

    [JsonPropertyName("wind_speed_10m")]
    public double WindSpeed10m { get; set; }

    [JsonPropertyName("weather_code")]
    public int WeatherCode { get; set; }
}

public class CurrentWeatherUnits
{
    [JsonPropertyName("temperature_2m")]
    public string? Temperature2m { get; set; }

    [JsonPropertyName("wind_speed_10m")]
    public string? WindSpeed10m { get; set; }
}

public class DailyWeather
{
    [JsonPropertyName("time")]
    public List<string>? Time { get; set; }
    
    [JsonPropertyName("temperature_2m_max")]
    public List<double>? Temperature2mMax { get; set; }

    [JsonPropertyName("temperature_2m_min")]
    public List<double>? Temperature2mMin { get; set; }

    [JsonPropertyName("weather_code")]
    public List<int>? WeatherCode { get; set; }
}

public static class WeatherCodeHelper
{
    private static readonly Dictionary<int, string> Descriptions = new()
    {
        { 0, "Clear sky" },
        { 1, "Mainly clear" }, { 2, "Partly cloudy" }, { 3, "Overcast" },
        { 45, "Foggy" }, { 48, "Icy fog" },
        { 51, "Light drizzle" }, { 53, "Drizzle" }, { 55, "Heavy drizzle" },
        { 61, "Slight rain" }, { 63, "Rain" }, { 65, "Heavy rain" },
        { 71, "Slight snow" }, { 73, "Snow" }, { 75, "Heavy snow" },
        { 80, "Slight showers" }, { 81, "Showers" }, { 82, "Heavy showers" },
        { 95, "Thunderstorm" }, { 96, "Thunderstorm with hail" }, { 99, "Heavy thunderstorm with hail" }
    };

    public static string GetDescription(int code)
    {
        return Descriptions.TryGetValue(code, out var description) ? description : "Unknown";
    }

    private static readonly Dictionary<int, string> Emojis = new()
    {
        { 0, "☀️" },
        { 1, "🌤️" }, { 2, "⛅" }, { 3, "☁️" },
        { 45, "🌫️" }, { 48, "🌫️" },
        { 51, "🌦️" }, { 53, "🌦️" }, { 55, "🌧️" },
        { 61, "🌧️" }, { 63, "🌧️" }, { 65, "🌧️" },
        { 71, "🌨️" }, { 73, "❄️" }, { 75, "❄️" },
        { 80, "🌦️" }, { 81, "🌧️" }, { 82, "⛈️" },
        { 95, "⛈️" }, { 96, "⛈️" }, { 99, "⛈️" }
    };

    public static string GetEmoji(int code)
    {
        return Emojis.TryGetValue(code, out var emoji) ? emoji : "🌡️";
    }
}

