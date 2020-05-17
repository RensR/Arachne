using System;
using Arachne.API.Models.Dto;
using Arachne.Data.Models;

namespace Arachne.API.Services.Interfaces
{
    public interface IConnectionService
    {
        PotentialConnection ProposeNewConnection(PropositionDto propositionDto, Guid from);
    }
}