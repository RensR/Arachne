using System;
using Arachne.API.ASP.Models.Dto;
using Arachne.API.ASP.Repositories.Interfaces;
using Arachne.API.ASP.Services.Interfaces;
using Arachne.Data.Models;

namespace Arachne.API.ASP.Services
{
    public class ConnectionService : IConnectionService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPotentialConnectionRepository _potentialConnectionRepository;

        public ConnectionService(IUserRepository userRepository, IPotentialConnectionRepository potentialConnectionRepository)
        {
            _userRepository = userRepository;
            _potentialConnectionRepository = potentialConnectionRepository;
        }

        public PotentialConnection ProposeNewConnection(PropositionDto propositionDto, Guid from)
        {
            var fromUser = _userRepository.GetUserByGuid(from);
            var toUser = _userRepository.GetUserByGuid(propositionDto.ToUserGuid);
            
            return _potentialConnectionRepository.ProposeConnection(fromUser, toUser, propositionDto.Introduction);
        }
    }
}