using System;
using Arachne.Data.Enums;

namespace Arachne.Data.Models
{
    public class Connection
    {
        public virtual User From { get; set; }
        
        public virtual User To { get; set; }
        
        public Permission Permission { get; set; }
        
        public string Note { get; set; }
        
        public DateTime Created { get; set; }
    }
}