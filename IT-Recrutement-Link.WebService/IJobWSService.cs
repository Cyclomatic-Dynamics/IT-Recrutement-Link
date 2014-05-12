using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using IT_Recrutement_Link.Domain.Domain;


namespace IT_Recrutement_Link.WebService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IJobWSService" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IJobWSService
    {
        [WebGet(UriTemplate = "/GetAllJobs",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Bare)]
        List<JobWS> GetAllJobs();
        [WebInvoke(UriTemplate = "/GetJob",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Bare)]
        JobWS GetJob(int id);
        [WebInvoke(UriTemplate = "/GetOwnJob",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Bare)]
        List<JobWS> GetOwnJob(CompanyWS cp);
        [WebInvoke(UriTemplate = "/NewJob",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Bare)]
        void NewJob(JobWS job);
        [WebInvoke(UriTemplate = "/UpdateJob",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Bare)]
        void UpdateJob(JobWS job);
        [WebInvoke(UriTemplate = "/DeleteJob",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Bare)]
        void DeleteJob(JobWS job);
    }
    [DataContract]
    public class JobWS
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public Company company { get; private set; }
        [DataMember]
        public IList<Student> registeredStudents { get; private set; }
        
    }
}
