using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace IT_Recrutement_Link.Domain.Domain
{
    public class User
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public User()
        {
        
        }
    }
}
