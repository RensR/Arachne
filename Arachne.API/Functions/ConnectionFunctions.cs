using System;
using System.Threading.Tasks;
using Arachne.API.Models.Dto;
using Arachne.API.Services;
using Arachne.API.Utilities.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace Arachne.API.Functions
{
    public class ConnectionFunctions
    {
        private readonly ConnectionService _connectionService;

        public ConnectionFunctions(ConnectionService connectionService)
        {
            _connectionService = connectionService;
        }
        
        [FunctionName("CreatePotentialConnection")]
        public async Task<IActionResult> GetUserById(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "v1/potentialconnection/create")]
            HttpRequest req)
        {
            var newPotentialConnection = req.ReadBody<PropositionDto>();
            var newConnection = _connectionService.ProposeNewConnection(newPotentialConnection, Guid.Empty);
            
            return new OkObjectResult(PotentialConnectionDto.FromDal(newConnection));
        }
    }
}