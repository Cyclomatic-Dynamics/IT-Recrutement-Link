using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace IT_Recrutement_Link.Domain.Domain
{
    [Table("Companies")]
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        [Required(ErrorMessage="Name Required")]
        public string Name { get; set;}
        [Required]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public string VideoUrl { get; set; }
        [Required]
        public string SlidesUrl { get; set; }
        [Required]
        public string LogoPictureUrl { get; set; }
        [Required]
        public string URL { get; set; }
        public ActivitySectorEnum ActivitySectorName { get; set; }
        [Required]
        public string Address { get; set; }
        public string Country { get; set; }
        public CompanySizeEnum CompanySize { get; set; }
        [Required]
        public DateTime? CreationDate { get; set; }
        [Required]
        public bool AcceptSpontanousApplication { get; set; }
        [Required]
        public virtual IList<string> Keywords { get; set; }
        public Company()
        {}
        public Company(string Name)
        {
            this.Name = Name;
            Keywords = new List<string>();
            AcceptSpontanousApplication = false;
        }
        public Job CreateJob(string jobName)
        {
            return new Job(this, jobName);
        }
    }
}
