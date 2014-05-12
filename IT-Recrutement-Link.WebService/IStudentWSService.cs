using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace IT_Recrutement_Link.WebService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IStudentWSService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/AllStudents",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Bare)]
        List<StudentWS> GetAllStudents();
        [OperationContract]
        [WebGet(UriTemplate = "/Student/{id}",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Bare)]
        StudentWS GetStudent(string id);
        [OperationContract]
        [WebInvoke(UriTemplate = "/Student",
            Method="POST",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Bare)]
        void NewStudent(StudentWS student);
        [OperationContract]
        [WebInvoke(UriTemplate = "/Student",
            Method="PUT",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Bare)]
        void UpdateStudent(StudentWS student);
        [OperationContract]
        [WebInvoke(UriTemplate = "/Student/{id}",
            Method="DELETE",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Bare)]
        void DeleteStudent(string id);
    }


    // Utilisez un contrat de données comme indiqué dans l'exemple ci-après pour ajouter les types composites aux opérations de service.
    [DataContract]
    public class StudentWS
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public DateTime BirthDate { get; set; }
        [DataMember]
        public string Diplomas { get; set; }
        [DataMember]
        public string Experiences { get; set; }
    }
}
