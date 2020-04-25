using System;
using System.Threading.Tasks;
using Arachne.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace Arachne.API.Functions
{
    public class UserFunctions
    {
        private readonly UserRepository _userRepository;

        public UserFunctions(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [FunctionName("GetUserById")]
        public async Task<IActionResult> GetUserById(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "v1/users/{id}")]
            HttpRequest req,
            Guid id)
        {
            return new OkObjectResult(_userRepository.GetUserByGuid(id));
        }
    }
}