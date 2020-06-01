using System;
using Arachne.Data.Models;

namespace Arachne.API.ASP.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User GetUserByGuid(Guid guid);
    }
}