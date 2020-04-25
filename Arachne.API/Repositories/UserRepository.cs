using System;
using Arachne.API.Repositories.Interfaces;
using Arachne.Data;
using Arachne.Data.Models;

namespace Arachne.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ArachneContext _arachneContext;

        public UserRepository(ArachneContext arachneContext)
        {
            _arachneContext = arachneContext;
        }

        public User GetUserByGuid(Guid guid)
        {
            return _arachneContext.Users.Find(guid);
        }
    }
}