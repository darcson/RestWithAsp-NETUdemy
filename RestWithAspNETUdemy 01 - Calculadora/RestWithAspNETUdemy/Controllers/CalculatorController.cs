using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RestWithAspNETUdemy.Controllers
{
    [Route("api/[controller]")]
    public class CalculatorController : Controller
    {
        // GET api/values/5
        [HttpGet("Sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
            => ExecuteCalculation(firstNumber, secondNumber, (a, b) => a + b);

        [HttpGet("Sub/{firstNumber}/{secondNumber}")]
        public IActionResult Sub(string firstNumber, string secondNumber)
            => ExecuteCalculation(firstNumber, secondNumber, (a, b) => a - b);

        [HttpGet("Div/{firstNumber}/{secondNumber}")]
        public IActionResult Div(string firstNumber, string secondNumber)
            => ExecuteCalculation(firstNumber, secondNumber, (a, b) => a/(b == 0 ? 1 : b));

        [HttpGet("Times/{firstNumber}/{secondNumber}")]
        public IActionResult Times(string firstNumber, string secondNumber)
            => ExecuteCalculation(firstNumber, secondNumber, (a, b) => a * b);

        [HttpGet("Avg/{firstNumber}/{secondNumber}")]
        public IActionResult Avg(string firstNumber, string secondNumber)
            => ExecuteCalculation(firstNumber, secondNumber, (a, b) =>  (a+b)/2);

        [HttpGet("Sqr/{number}")]
        public IActionResult Square(string number)
            => ExecuteCalculation(number, a => (decimal)Math.Sqrt(Convert.ToDouble(a)));

        #region private
        private IActionResult ExecuteCalculation(string firstNumber, string secondNumber, Func<decimal, decimal, decimal> calculator)
        {
            if (IsNumeric(firstNumber) && (IsNumeric(secondNumber)))
            {
                var sum = calculator(ConvertToDecimal(firstNumber), ConvertToDecimal(secondNumber));
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        private IActionResult ExecuteCalculation(string number, Func<decimal, decimal> calculator)
        {
            if (IsNumeric(number))
            {
                var sum = calculator(ConvertToDecimal(number));
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        private decimal ConvertToDecimal(string strValue)
        {
            var decimalValue = 0m;
            return decimal.TryParse(strValue, out decimalValue)
                ? decimalValue
                : 0m;
        }

        private bool IsNumeric(string strValue)
        {
            var temp = 0.0;
            return !string.IsNullOrEmpty(strValue.Trim()) && double.TryParse(strValue, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo,out temp);
        }
        #endregion
    }
}
