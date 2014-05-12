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
    public class Company : User
    {
        [MaxLength(50)]
        [Required(ErrorMessage="Name Required")]
        public string Name { get; set;}    
        [Required]
        public string URL { get; set; }
        public string ActivitySectorName { get; set; }
        [Required]
        public string Address { get; set; }
        public string Country { get; set; }
        public string CompanySize { get; set; }

        public Company(string Name, string URL,string Address,string ActivitySectorName,string Country)
        {
                this.URL = URL;
                this.ActivitySectorName = ActivitySectorName;
                this.Name = Name;
                this.Address = Address;
                this.Country = Country;
                this.CompanySize = CompanySize;
        }
        public Job CreateJob(string jobName)
        {
            return new Job(this, jobName);
        }
    }
}
