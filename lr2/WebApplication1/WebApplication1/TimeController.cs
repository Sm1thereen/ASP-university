using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/time")]
public class TimeOfDayController : ControllerBase
{
    private readonly TimeOfDayService _timeOfDayService;

    public TimeOfDayController(TimeOfDayService timeOfDayService)
    {
        _timeOfDayService = timeOfDayService;
    }

    [HttpGet]
    public IActionResult GetTimeOfDay()
    {
        var timeOfDay = _timeOfDayService.GetTimeOfDay();
        return Ok($"Зараз: {timeOfDay}");
    }
}