using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using XUnitTutorial.API.Interfaces;

namespace XUnitTutorial.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController : ControllerBase
    {
        public ICalculatorService _calc { get; set; }

        public CalculatorController(ICalculatorService calc)
        {
            _calc = calc ?? throw new NullReferenceException(nameof(calc));
        }

        [HttpPost("add/{value}")]
        public ActionResult<double> Add([FromRoute] double value)
        {
            return Ok(_calc.Add(value));
        }

        [HttpPost("subtract/{value}")]
        public ActionResult<double> Subtract([FromRoute] double value)
        {
            return Ok(_calc.Subtract(value));
        }

        [HttpPost("multiply/{value}")]
        public ActionResult<double> Multiply([FromRoute] double value)
        {
            return Ok(_calc.Multiply(value));
        }

        [HttpPost("divide/{value}")]
        public ActionResult<double> Divide([FromRoute] double value)
        {
            return Ok(_calc.Divide(value));
        }

        [HttpPost("clear")]
        public ActionResult<double> Clear()
        {
            _calc.ClearResult();
            return Ok(0);
        }
    }
}
