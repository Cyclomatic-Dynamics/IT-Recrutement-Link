using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using IT_Recrutement_Link.Service;
using IT_Recrutement_Link.Domain.Domain;
using IT_Recrutement_Link.DataAccess;
namespace IT_Recrutement_Link.WebService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class StudentWSService : IStudentWSService
    {
        public List<StudentWS> GetAllStudents()
        {
            StudentService service = new StudentService(new Context());
            IList<Student> allStudents = service.ViewAllStudents();
            return convertDomainToDataContractMany(allStudents);
        }
        private List<StudentWS> convertDomainToDataContractMany(IList<Student> students)
        {
            List<StudentWS> studentsWS = new List<StudentWS>();
            foreach (Student student in students)
            {
                studentsWS.Add(convertDomainToDataContractOne(student));
            }
            return studentsWS;
        }
        private StudentWS convertDomainToDataContractOne(Student student)
        {
            return new StudentWS
            {
                Id = student.Id,
                Email = student.Email,
                BirthDate = student.BirthDate,
                Name = student.Name,
                LastName = student.LastName,
                Diplomas = student.Diplomas,
                Experiences = student.Experiences,

            };
        }

    }
}
