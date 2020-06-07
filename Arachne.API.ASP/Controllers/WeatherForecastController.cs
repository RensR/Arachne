using Arachne.API.ASP.Repositories.Interfaces;
using Arachne.API.ASP.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Arachne.API.ASP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        [HttpGet]
        [Authorize]
        public string Get()
        {
            var claims = HttpContext.User.Claims.ReadClaims();

            var user = _userRepository.GetOrCreateUserByEmail(claims);

            return JsonConvert.SerializeObject(user);
        }
    }
}