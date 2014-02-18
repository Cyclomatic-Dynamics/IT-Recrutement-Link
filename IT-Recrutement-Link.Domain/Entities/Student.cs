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
        public string LastName { get; set; }
        public DateTime DateNaissance { get; set; }
        public List<string> University { get; set; }
        public List<string> Diplome { get; set; }
        public List<string> Formation { get; set; }        
        public List<string> Experience { get; set; }
        public string VideoUrl { get; set; }
        public string SlidesUrl { get; set; }
        public string ProfilePictureUrl { get; set; }
        public CompetenceSectorEnum CompetenceSectorName { get; set; }
        public virtual IList<string> Keywords { get; set; }
    }
}
