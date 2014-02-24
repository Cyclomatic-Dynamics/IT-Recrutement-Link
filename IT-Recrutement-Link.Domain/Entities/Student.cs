using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IT_Recrutement_Link.Domain.Entities
{
    [Table("Students")] 
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        public DateTime DateNaissance { get; set; }
        [Required]
        public List<string> University { get; set; }
        [Required]
        public List<string> Diplome { get; set; }
        [Required]
        public List<string> Formation { get; set; }
        [Required]
        public List<string> Experience { get; set; }
        [Required]
        public string VideoUrl { get; set; }
        [Required]
        public string SlidesUrl { get; set; }
        [Required]
        public string ProfilePictureUrl { get; set; }
        [Required]
        public CompetenceSectorEnum CompetenceSectorName { get; set; }
        [Required]
        public virtual IList<string> Keywords { get; set; }
        public Student() { }
        public Student(string Name)
        {
            this.Name = Name;
        }
        public void Apply(Job job)
        {
            job.Register(this);
        }
    }
}
