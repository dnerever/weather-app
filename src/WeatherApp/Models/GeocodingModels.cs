namespace WeatherApp.Models;

public class GeocodingResponse
{
    public List<GeocodingResult>? Results { get; set; }
}

public class GeocodingResult
{
    public string Name { get; set; } = "";
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string? Country { get; set; }
}
