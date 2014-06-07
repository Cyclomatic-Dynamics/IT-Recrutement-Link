using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IT_Recrutement_Link.Domain.Entities
{
    public class User : HashingService
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        [Required(ErrorMessage="Name Required")]
        public string Name { get; set;}
        [Required]
        public string Email { get; set; }
        private string _passhash;
        [Required]
        public string PasswordHash
        {
            get { return _passhash; }
            set
            {
                _passhash = HashSet(PasswordHash); 
          
        } }
        [Required]
        public string VideoUrl { get; set; }
        [Required]
        public string SlidesUrl { get; set; }
        [Required]
        public string LogoPictureUrl { get; set; }

        public bool Authentificate(string password)
        {
            return true;
        }
    }
}
