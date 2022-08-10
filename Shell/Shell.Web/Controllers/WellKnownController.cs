using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Shell.Web.Configuration;

namespace Shell.Web.Controllers
{
    /// <summary>
    ///   Hosts well-known endpoints used by the web app.
    /// </summary>
    [ApiController]
    [Produces("application/json")]
    [Route(".well-known")]
    public class WellknownController : Controller
    {
        private readonly IConfiguration configuration;

        /// <summary>
        ///   Initializes a new instance of the <see cref="WellknownController"/> class.
        /// </summary>
        /// <param name="configuration">
        ///   The <see cref="IConfiguration"/> containing the configuration settings for the application.
        /// </param>
        public WellknownController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        /// <summary>
        ///   Gets the Shell configuration, which includes the tenant identifier and authentication provider url.
        /// </summary>
        /// <returns>Returns an <see cref="IActionResult"/>.</returns>
        [HttpGet("shell-config")]
        [ProducesResponseType(typeof(ShellConfiguration), 200)]
        [ProducesResponseType(typeof(void), 500)]
        public IActionResult ShellConfiguration()
        {
            try
            {
                var shellConfig = new ShellConfiguration(configuration);
                return Ok(shellConfig);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}