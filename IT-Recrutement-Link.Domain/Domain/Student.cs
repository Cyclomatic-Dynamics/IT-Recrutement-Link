using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IT_Recrutement_Link.Domain.Domain
{
    [Table("Students")] 
    public class Student : User
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string Diplomas { get; set; }
        [Required]
        public string Experiences { get; set; }
        public Student(string Name, string Email, string LastName, DateTime BirthDate, string Diplomas, string Experiences)
        {
                this.Name = Name;
                this.Email = Email;
                this.LastName = LastName;
                this.BirthDate = BirthDate;
                this.Diplomas = Diplomas;
                this.Experiences = Experiences;
        }
        public Student()
        {

        }
    }
}
