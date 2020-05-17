using System;

namespace Arachne.API.Models.Dto
{
    public class PropositionDto
    {
        public Guid ToUserGuid { get; set; }
        
        public string Introduction { get; set; } = string.Empty;
    }
}