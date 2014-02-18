using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Recrutement_Link.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
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
