using System;
using System.Linq;
using System.Security.Claims;
using Arachne.API.ASP.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
            var userClaims = HttpContext.User.Claims;
            var principal = HttpContext.User.Identity as ClaimsIdentity;

            var login = principal.Claims
                .SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier)
                ?.Value;

            var user = _userRepository.GetUserByGuid(Guid.Parse("AA30096F-92D2-4577-8870-275DEDE203F1"));
            var xmd = principal.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Email);
            return userClaims.Aggregate(user.FirstName, (current, userClaim) => current + (userClaim.Type + " " + userClaim.Value));
        }
    }
}