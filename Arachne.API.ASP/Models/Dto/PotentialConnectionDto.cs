using System;
using System.Collections.Generic;
using Arachne.Data.Models;
using SomeNone;
using SomeNone.Extensions;

namespace Arachne.API.ASP.Models.Dto
{
    public class PotentialConnectionDto
    {
        public long Id { get; set; }

        public DateTime Created { get; set; }

        public Guid From { get; set; }

        public Guid To { get; set; }

        public string Introduction { get; set; } = string.Empty;

        public static Option<PotentialConnectionDto> FromDal(PotentialConnection potentialConnection)
        {
            return potentialConnection
                .NoneIfNull()
                .Map(dal =>
                new PotentialConnectionDto
                {
                    Id = potentialConnection.Id,
                    Created = potentialConnection.Created,
                    From = potentialConnection.From.Guid,
                    To = potentialConnection.To.Guid,
                    Introduction = potentialConnection.Introduction
                });
        }

        public IEnumerable<PotentialConnectionDto> FromDal(IEnumerable<PotentialConnection> potentialConnections)
        {
            return potentialConnections.SelectOptional(FromDal);
        }
    }
}