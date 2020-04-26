using System;
using System.ComponentModel.DataAnnotations;

namespace Arachne.Data.Models
{
    public class User
    {
        [Key]
        public Guid Guid { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
    }
}