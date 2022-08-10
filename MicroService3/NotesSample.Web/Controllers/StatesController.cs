using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NotesSample.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatesController : ControllerBase
    {
        private readonly ILogger<StatesController> _logger;

        public StatesController(ILogger<StatesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get()
            => new[] { "Florida", "Maine", "Texas", "Wyoming" };
    }
}