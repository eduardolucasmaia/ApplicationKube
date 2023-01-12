using maia.eduardo.webapi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace maia.eduardo.webapi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WindowsUserController : ControllerBase
    {
        private readonly ILogger<WindowsUserController> _logger;
        private readonly AppSettings _appSettings;

        public WindowsUserController(ILogger<WindowsUserController> logger, IOptions<AppSettings> options)
        {
            _appSettings = options.Value;
            _logger = logger;
        }

        [HttpGet(Name = "GetUser")]
        [Route("GetUser")]
        public IActionResult GetUser()
        {
            return Ok(User.Identity.Name);
        }

        [HttpGet(Name = "GetAppSettings")]
        [Route("GetAppSettings")]
        public IActionResult GetAppSettings()
        {
            return Ok(_appSettings.Key);
        }
    }
}
