using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using WeatherApp.Models;

namespace WeatherApp.Services;
public class WeatherService
{
    private readonly HttpClient _httpClient;

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
    };

    public WeatherService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<GeocodingResult?> GetLocationAsync(string cityName)
    {
        var url = $"https://geocoding-api.open-meteo.com/v1/search?name={Uri.EscapeDataString(cityName)}&count=1";
        var response = await _httpClient.GetFromJsonAsync<GeocodingResponse>(url, JsonOptions);
        return response?.Results?.FirstOrDefault();
    }

    public async Task<WeatherResponse?> GetWeatherAsync(double latitude, double longitude)
    {
        var url = $"https://api.open-meteo.com/v1/forecast" +
            $"?latitude={latitude}&longitude={longitude}" +
            $"&current=temperature_2m,wind_speed_10m,weather_code" +
            $"&daily=temperature_2m_max,temperature_2m_min,weather_code" +
            $"&timezone=auto";
        return await _httpClient.GetFromJsonAsync<WeatherResponse>(url, JsonOptions);
    }
}