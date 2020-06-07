using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Arachne.API.ASP.Models;

namespace Arachne.API.ASP.Utilities
{
    public static class OktaUtilities
    {
        public static OktaResponseValues ReadClaims(this IEnumerable<Claim> claims)
        {
            var email = claims
                .SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier)
                ?.Value;
            var firstName = claims.SingleOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value;
            var lastName = claims.SingleOrDefault(c => c.Type == ClaimTypes.Surname)?.Value;

            return new OktaResponseValues
            {
                Email = email,
                FirstName = firstName,
                LastName = lastName,
            };
        }
    }
}