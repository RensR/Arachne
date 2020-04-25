using System;
using Arachne.Data.Models;

namespace Arachne.API.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User GetUserByGuid(Guid guid);
    }
}