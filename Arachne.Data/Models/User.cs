using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arachne.Data.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Guid { get; set; }
        
        public string Email { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public DateTime Created { get; set; }
        
        public virtual List<PotentialConnection> PotentialConnectionsFrom { get; set; } = new List<PotentialConnection>();
        
        public virtual List<Connection> ConnectionsFrom { get; set; } = new List<Connection>();
        
        public virtual List<PotentialConnection> PotentialConnectionsTo { get; set; } = new List<PotentialConnection>();
        
        public virtual List<Connection> ConnectionsTo { get; set; } = new List<Connection>();
        
        public override bool Equals(object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }

            return Equals((User) obj);
        }

        protected bool Equals(User other)
        {
            if (other == null)
                return false;
            return Guid.Equals(other.Guid) && 
                   Email.Equals(other.Email) &&
                   FirstName == other.FirstName && 
                   LastName == other.LastName && 
                   Created.Equals(other.Created);
        }

        public static bool operator ==(User first, User second)
        {
            // If left hand side is null...
            if (ReferenceEquals(first, null))
            {
                // return true if both are equal and false if right is not null
                return ReferenceEquals(second, null);
            }

            // Return true if the fields match:
            return first.Equals(second);
        }

        public static bool operator !=(User first, User second) => !(first == second);

        public override int GetHashCode()
        {
            return HashCode.Combine(Guid, Email, FirstName, LastName, Created);
        }
    }
}