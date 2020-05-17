using System;
using System.ComponentModel.DataAnnotations;

namespace Arachne.Data.Models
{
    public class PotentialConnection
    {
        [Key]
        public long Id { get; set; }
        
        public DateTime Created { get; set; }
        
        public virtual User From { get; set; }
        
        public virtual User To { get; set; }
        
        public string Introduction { get; set; }
    }
}