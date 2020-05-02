using System;
using Arachne.Data.Models;

namespace Arachne.API.Models.Dto
{
    public class PotentialConnectionDto
    {
        public long Id { get; set; }
        
        public DateTime Created { get; set; }
        
        public Guid From { get; set; }
        
        public Guid To { get; set; }
        
        public string Introduction { get; set; } = string.Empty;

        public static PotentialConnectionDto? FromDal(PotentialConnection potentialConnection)
        {
            return potentialConnection == null
                ? null
                : new PotentialConnectionDto
                {
                    Id = potentialConnection.Id,
                    Created = potentialConnection.Created,
                    From = potentialConnection.From.Guid,
                    To = potentialConnection.To.Guid,
                    Introduction = potentialConnection.Introduction
                };
        }
    }
}