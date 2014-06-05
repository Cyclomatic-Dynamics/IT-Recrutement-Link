using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace IT_Recrutement_Link.Domain.Domain
{
    [Table("Jobs")]
    public class Job
    {
        [Key] 
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Company company { get;  set; }
        [Required]
        public IList<Student> registeredStudents { get;  set; }
        public Job() { }
        public Job(Company company, string Name)
        {
            registeredStudents = new List<Student>();
            this.Name = Name;
            this.company = company;
        }

        public void Register(Student student)
        {
            registeredStudents.Add(student);
        }
    }
}
