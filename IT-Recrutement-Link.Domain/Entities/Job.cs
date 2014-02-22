using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IT_Recrutement_Link.Domain.Entities;



namespace IT_Recrutement_Link.Domain.Entities
{
    public class Job
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Company company { get;private set; }
        public IList<Student> registeredStudents { get; private set; }
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
