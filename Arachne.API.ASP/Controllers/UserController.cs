using Arachne.API.ASP.Models.Dto;
using Arachne.API.ASP.Repositories.Interfaces;
using Arachne.API.ASP.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Arachne.API.ASP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            var claims = HttpContext.User.Claims.ReadClaims();
            var user = _userRepository.GetOrCreateUserByEmail(claims);

            return new OkObjectResult(UserDto.FromDal(user));
        }
    }
}