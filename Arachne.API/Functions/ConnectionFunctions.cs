using System;
using System.Net.Http;
using Arachne.API.Models.Dto;
using Arachne.API.Repositories.Interfaces;
using Arachne.API.Services.Interfaces;
using Arachne.API.Utilities.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace Arachne.API.Functions
{
    public class ConnectionFunctions
    {
        private readonly IConnectionService _connectionService;
        private readonly IPotentialConnectionRepository _potentialConnectionRepository;

        public ConnectionFunctions(IConnectionService connectionService, IPotentialConnectionRepository potentialConnectionRepository, HttpClient httpClient)
        {
            _connectionService = connectionService;
            _potentialConnectionRepository = potentialConnectionRepository;
        }
        
        [FunctionName("CreatePotentialConnection")]
        public IActionResult CreatePotentialConnection(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "v1/potentialconnection/create")]
            HttpRequest req)
        {
            var newPotentialConnection = req.ReadBody<PropositionDto>();
            var newConnection = _connectionService.ProposeNewConnection(newPotentialConnection, Guid.Empty);
            
            return new OkObjectResult(PotentialConnectionDto.FromDal(newConnection));
        }

        [FunctionName("GetPendingConnections")]
        public IActionResult GetPendingConnections(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "v1/potentialconnection/pending")]
            HttpRequest req, ILogger log)
        {
 
            var potentialConnections = _potentialConnectionRepository.GetAllPotentialConnectionForUser(Guid.Empty);
            return new OkObjectResult(potentialConnections);
        }
        
    }
}