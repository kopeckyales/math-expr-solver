using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MathExprSolver.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComputeController : ControllerBase
    {
        private readonly ILogger<ComputeController> _logger;

        public ComputeController(ILogger<ComputeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public float Get(string expr)
        {
            return 0f;
        }
    }
}