using System;
using Arachne.API.ASP.Models;
using Arachne.Data.Models;

namespace Arachne.API.ASP.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User GetUserByGuid(Guid guid);

        User GetOrCreateUserByEmail(OktaResponseValues user);
    }
}