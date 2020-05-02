using System;

namespace Arachne.Data.Models
{
    public class PotentialConnection
    {
        public DateTime Created { get; set; }
        
        public virtual User From { get; set; }
        
        public virtual User To { get; set; }
        
        public string Introduction { get; set; }
    }
}