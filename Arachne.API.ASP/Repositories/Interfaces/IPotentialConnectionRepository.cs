using System;
using System.Collections.Generic;
using Arachne.Data.Models;

namespace Arachne.API.ASP.Repositories.Interfaces
{
    public interface IPotentialConnectionRepository
    {
        PotentialConnection ProposeConnection(User from, User to, string introduction);

        void RemovePotentialConnection(PotentialConnection potentialConnection);

        PotentialConnection GetPotentialConnection(long id);

        List<PotentialConnection> GetAllPotentialConnectionForUser(User user);

        List<PotentialConnection> GetAllPotentialConnectionForUser(Guid userId);
    }
}