using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Utilities;

namespace RestWithAspNETUdemy.Controllers
{
    [Route("api/[controller]")]
    public class CalculatorController : Controller
    {
        // GET api/Sum/values/5
        [HttpGet("Sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
            => ExecuteCalculation(firstNumber, secondNumber, (a, b) => a + b);

        // GET api/Sub/values/5
        [HttpGet("Sub/{firstNumber}/{secondNumber}")]
        public IActionResult Sub(string firstNumber, string secondNumber)
            => ExecuteCalculation(firstNumber, secondNumber, (a, b) => a - b);

        // GET api/Div/values/5
        [HttpGet("Div/{firstNumber}/{secondNumber}")]
        public IActionResult Div(string firstNumber, string secondNumber)
            => ExecuteCalculation(firstNumber, secondNumber, (a, b) => a/(b == 0 ? 1 : b));

        // GET api/Times/values/5
        [HttpGet("Times/{firstNumber}/{secondNumber}")]
        public IActionResult Times(string firstNumber, string secondNumber)
            => ExecuteCalculation(firstNumber, secondNumber, (a, b) => a * b);

        // GET api/Avg/values/5
        [HttpGet("Avg/{firstNumber}/{secondNumber}")]
        public IActionResult Avg(string firstNumber, string secondNumber)
            => ExecuteCalculation(firstNumber, secondNumber, (a, b) =>  (a+b)/2);

        // GET api/Sqr/values/5
        [HttpGet("Sqr/{number}")]
        public IActionResult Square(string number)
            => ExecuteCalculation(number, a => (decimal)Math.Sqrt(Convert.ToDouble(a)));

        #region private
        private IActionResult ExecuteCalculation(string firstNumber, string secondNumber, Func<decimal, decimal, decimal> calculator)
        {
            if (firstNumber.IsNumeric() && secondNumber.IsNumeric())
            {
                var sum = calculator(firstNumber.ConvertToDecimal(), secondNumber.ConvertToDecimal());
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        private IActionResult ExecuteCalculation(string number, Func<decimal, decimal> calculator)
        {
            if (number.IsNumeric())
            {
                var sum = calculator(number.ConvertToDecimal());
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }
        #endregion
    }
}
