using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace IT_Recrutement_Link.Domain.Domain
{
    public class User
    {   
        private Hasher hasher;
        private string passwordHash = "";
        public User()
        {
            hasher = ServiceFactory.GetHasher();
        }
        public User(Hasher hasher)
        {
            this.hasher = hasher;
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string PasswordHash {
            get
            {
                return passwordHash;
            } 
            set {
                passwordHash = hasher.Hash(value);
            } 
        }
        public bool VerifyPassword(string password)
        {
            return hasher.Hash(password).Equals(passwordHash);
        }
    }
}
