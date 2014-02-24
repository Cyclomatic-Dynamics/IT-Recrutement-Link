using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace IT_Recrutement_Link.Domain.Entities
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage="Name Required")]
        public string Name { get; set;}
        [Required]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        
        public CountryEnum Country { get; set; }
        public string VideoUrl { get; set; }
        public string SlidesUrl { get; set; }
        public string LogoPictureUrl { get; set; }
        public ActivitySectorEnum ActivitySectorName { get; set; }
        public String Address { get; set; }
        public CompanySizeEnum CompanySize { get; set; }
        public DateTime? CreationDate { get; set; }
        public bool AcceptSpontanousApplication { get; set; }
        
        public virtual IList<string> Keywords { get; set; }
        public Company()
        {

        }
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
