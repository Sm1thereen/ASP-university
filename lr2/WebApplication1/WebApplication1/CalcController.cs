namespace WebApplication1;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("arithmetic")]
public class ArithmeticController(CalcService calcService) : ControllerBase
{
    [HttpGet("add")]
    public IActionResult Add(double a, double b) => Ok(calcService.Add(a, b));

    [HttpGet("subtract")]
    public IActionResult Subtract(double a, double b) => Ok(calcService.Subtract(a, b));

    [HttpGet("multiply")]
    public IActionResult Multiply(double a, double b) => Ok(calcService.Multiply(a, b));

    [HttpGet("divide")]
    public IActionResult Divide(double a, double b) => Ok(calcService.Divide(a, b));
}