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
    public class RomanSumController : ControllerBase
    {
        private readonly ILogger<RomanSumController> _logger;

        public RomanSumController(ILogger<RomanSumController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{roman1}&{roman2}")]
        public string Get(string roman1, string roman2)
        {
            String romanString = RomanIntegersOperations.RomanSum(roman1, roman2);

            return $"result:{romanString}";
        }
    }
}
