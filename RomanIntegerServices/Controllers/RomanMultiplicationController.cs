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
    public class RomanDivisionController : ControllerBase
    {
        private readonly ILogger<RomanDivisionController> _logger;

        public RomanDivisionController(ILogger<RomanDivisionController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{roman1}&{roman2}")]
        public string Get(string roman1, string roman2)
        {
            String romanString = RomanIntegersOperations.RomanDivision(roman1, roman2);

            return $"result:{romanString}";
        }
    }
}
