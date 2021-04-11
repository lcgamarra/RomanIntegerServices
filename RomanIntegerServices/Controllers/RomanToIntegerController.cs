using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RomanIntegerServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RomanToIntegerController : ControllerBase
    {

        private readonly ILogger<RomanToIntegerController> _logger;

        public RomanToIntegerController(ILogger<RomanToIntegerController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{roman}")]
        public string Get(string roman)
        {
            int integerNumber = RomanIntegersOperations.RomanToInteger(roman);

            if (!integerNumber.Equals(0))
            {
                return "{result:" + $"{integerNumber}" + "}";
            }
            else
            {
                return "{result:formatError}";
            }
        }
    }
}
