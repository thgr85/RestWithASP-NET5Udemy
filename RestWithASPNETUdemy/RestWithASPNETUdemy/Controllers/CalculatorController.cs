using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNETUdemy.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculatorController : ControllerBase
{
    private readonly ILogger<CalculatorController> _logger;

    public CalculatorController(ILogger<CalculatorController> logger)
    {
        _logger = logger;
    }

    [HttpGet("sum/{firstNumber}/{secondNumber}")]
    public IActionResult Sum(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
            return Ok(sum.ToString());
        }
        return BadRequest("Invalid input");
    }

    [HttpGet("square-root/{number}")]
    public IActionResult SquareRoot(string number)
    {
        if (IsNumeric(number))
        {
            var squareRoot = Math.Sqrt((double)ConvertToDecimal(number));
            return Ok(squareRoot.ToString());
        }
        return BadRequest("Invalid input");
    }

    private decimal ConvertToDecimal(string strNumber)
    {
        decimal decimalValue;
        if (decimal.TryParse(strNumber.Replace('.', ','), out decimalValue)) { return decimalValue; }
        return 0.0M;
    }

    private bool IsNumeric(string strNumber)
    {
        double number;
        bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);
        return isNumber;
    }
}
