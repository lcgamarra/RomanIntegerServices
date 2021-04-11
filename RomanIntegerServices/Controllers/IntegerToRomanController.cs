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
    public class IntegerToRomanController : ControllerBase
    {
        private readonly ILogger<IntegerToRomanController> _logger;

        public IntegerToRomanController(ILogger<IntegerToRomanController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{integerString}")]
        public string Get(string integerString)
        {
            var integerValue = Int32.Parse(integerString);
            String romanString = RomanIntegersOperations.IntegerToRoman(integerValue);

            return $"result:{romanString}";
        }
    }
}
