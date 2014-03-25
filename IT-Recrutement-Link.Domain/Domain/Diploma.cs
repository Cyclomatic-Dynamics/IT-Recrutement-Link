using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace IT_Recrutement_Link.Domain.Domain
{
    public class Diploma
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public string University { get; set; }
        public DateTime BeginDate { get; set; }
        public string Honors { get; set; }
        
    }
}
