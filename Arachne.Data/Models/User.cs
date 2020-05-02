using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arachne.Data.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Guid { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public DateTime Created { get; set; }
        
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
            return Guid.Equals(other.Guid) && 
                   FirstName == other.FirstName && 
                   LastName == other.LastName && 
                   Created.Equals(other.Created);
        }

        public static bool operator ==(User first, User second) => first.Equals(second);
        
        public static bool operator !=(User first, User second) => !(first == second);

        public override int GetHashCode()
        {
            return HashCode.Combine(Guid, FirstName, LastName, Created);
        }
    }
}