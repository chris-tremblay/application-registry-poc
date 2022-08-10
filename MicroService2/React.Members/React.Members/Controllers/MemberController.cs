using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using React.Members.Models;

namespace React.Members.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MemberController : ControllerBase
    {
        private readonly ILogger<MemberController> _logger;

        public MemberController(ILogger<MemberController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public MemberDetail Get()
            => new MemberDetail
            {
                FirstName = "Tony",
                LastName = "Stark",
                BirthDate = new DateTime(1975),
                PlanNumber = "BCG-749730-G",
            };
    }
}