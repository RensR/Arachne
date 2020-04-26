using System;
using Arachne.Data.Models;

namespace Arachne.API.Models.Dto
{
    public class UserDto
    {
        public Guid Guid { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public static UserDto FromDal(User user)
        {
            return user == null
                ? null
                : new UserDto
                {
                    Guid = user.Guid,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                };
        }
    }
}