using System;
using System.Linq;
using Arachne.API.ASP.Models;
using Arachne.API.ASP.Repositories.Interfaces;
using Arachne.Data;
using Arachne.Data.Models;

namespace Arachne.API.ASP.Repositories
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

        public User GetOrCreateUserByEmail(OktaResponseValues user)
        {
            User foundUser = _arachneContext.Users.FirstOrDefault(u => u.Email == user.Email);
            if(foundUser == null)
            {
                foundUser = new User
                {
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Created = DateTime.UtcNow,
                };

                _arachneContext.Users.Add(foundUser);
                _arachneContext.SaveChanges();
            }

            return foundUser;
        }
    }
}