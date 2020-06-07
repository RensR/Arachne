using System;
using Arachne.API.ASP.Models.Dto;
using Arachne.Data.Models;

namespace Arachne.API.ASP.Services.Interfaces
{
    public interface IConnectionService
    {
        PotentialConnection ProposeNewConnection(PropositionDto propositionDto, Guid from);
    }
}