using System;
using System.Collections.Generic;
using System.Linq;
using Arachne.API.Repositories.Interfaces;
using Arachne.Data;
using Arachne.Data.Models;

namespace Arachne.API.Repositories
{
    public class PotentialConnectionRepository : IPotentialConnectionRepository
    {
        private readonly ArachneContext _arachneContext;

        public PotentialConnectionRepository(ArachneContext arachneContext)
        {
            _arachneContext = arachneContext;
        }

        public PotentialConnection ProposeConnection(User from, User to, string introduction)
        {
            var potentialConnection = new PotentialConnection
            {
                From = from,
                To = to,
                Introduction = introduction,
                Created = DateTime.UtcNow
            };
            _arachneContext.PotentialConnections.Add(potentialConnection);
            _arachneContext.SaveChanges();
            return potentialConnection;
        }

        public void RemovePotentialConnection(PotentialConnection potentialConnection)
        {
            _arachneContext.Remove(potentialConnection);
            _arachneContext.SaveChanges();
        }

        public PotentialConnection GetPotentialConnection(long id)
        {
            return _arachneContext.PotentialConnections.Find(id);
        }

        public List<PotentialConnection> GetAllPotentialConnectionForUser(User user)
        {
            return _arachneContext.PotentialConnections.Where(pot => pot.To == user).ToList();
        }

        public List<PotentialConnection> GetAllPotentialConnectionForUser(Guid userId)
        {
            return _arachneContext.PotentialConnections.Where(pot => pot.To.Guid == userId).ToList();
        }
    }
}