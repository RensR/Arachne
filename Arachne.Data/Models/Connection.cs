using System;
using System.ComponentModel.DataAnnotations;
using Arachne.Data.Enums;

namespace Arachne.Data.Models
{
    public class Connection
    {
        [Key]
        public long Id { get; set; }
        
        public virtual User From { get; set; }
        
        public virtual User To { get; set; }
        
        public Permission Permission { get; set; }
        
        public string Note { get; set; }
        
        public DateTime Created { get; set; }
    }
}