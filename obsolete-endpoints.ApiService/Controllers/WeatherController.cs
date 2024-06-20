using Microsoft.AspNetCore.Mvc;

namespace ObsoleteEndpoints.ApiService.Controllers;

[Tags("Controller")]
[Route("api/[controller]")]
public class WeatherController : ControllerBase
{
    [HttpGet]
    [Obsolete]
    public IActionResult GetWeather()
    {
        return Ok(WeatherGenerator.Generate());
    }
}