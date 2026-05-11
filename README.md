# Weather App
[![CI](https://github.com/dnerever/weather-app/actions/workflows/ci.yml/badge.svg)](https://github.com/dnerever/weather-app/actions/workflows/ci.yml)

A Blazor Server web app that takes a city name, geocodes it via the Open-Meteo API, and displays current temperature, wind speed, and weather.

## Skills Demonstrated
| Skill | Detail |
|---|---|
| **C# .NET & Blazor** | Full stack web app with interactive server rendering |
| **Dependency Injection** | Service layer registered and injected via Program.cs |
| **REST API Integration** | Geocoding and weather data from Open-Meteo |
| **Unit Testing** | xUnit with mock HTTP handler |
| **CI/CD** | GitHub Actions pipeline runs on every push |

## Tech Stack
* .NET 10
* Blazor
* Open-Meteo API
* xUnit

## Architecture Overview
Structure follows Blazor conventions and separates concerns into distinct folders. `Models` for data shapes, `Services` for API logic, and `Components/Pages` for UI. This keeps business logic out of the UI layer. 

## How to Run
**Requirements:** [.NET 10 SDK](https://dotnet.microsoft.com/download)

```
git clone git@github.com:dnerever/weather-app.git
cd weather-app
dotnet run --project src/WeatherApp
```

Then open your browser to the URL shown in the terminal (typically `https://localhost:5001/weather`)

## Running Tests
```
dotnet test src/WeatherApp.Tests
```

## GitHub Actions
GitHub Actions is configured to build and run the full test suite on every push to `main`, ensuring regressions are caught before merging.