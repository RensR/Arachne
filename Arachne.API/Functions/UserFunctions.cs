using System;
using System.Threading.Tasks;
using Arachne.API.Models.Dto;
using Arachne.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace Arachne.API.Functions
{
    public class UserFunctions
    {
        private readonly IUserRepository _userRepository;

        public UserFunctions(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [FunctionName("GetUserById")]
        public async Task<IActionResult> GetUserById(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "v1/users/{id}")]
            HttpRequest req,
            Guid id)
        {
            var user = UserDto.FromDal(_userRepository.GetUserByGuid(id));
            
            if(user == null)
                return new NotFoundResult();
            
            return new OkObjectResult(user);
        }
    }
}