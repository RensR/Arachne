using System;
using Arachne.API.Models.Dto;
using Arachne.API.Repositories;
using Arachne.API.Services.Interfaces;
using Arachne.Data.Models;

namespace Arachne.API.Services
{
    public class ConnectionService : IConnectionService
    {
        private readonly UserRepository _userRepository;
        private readonly PotentialConnectionRepository _potentialConnectionRepository;

        public ConnectionService(UserRepository userRepository, PotentialConnectionRepository potentialConnectionRepository)
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