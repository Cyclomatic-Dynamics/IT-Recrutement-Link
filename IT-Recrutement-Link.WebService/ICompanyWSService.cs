using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace IT_Recrutement_Link.WebService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "ICompanyWSService" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface ICompanyWSService
    {
        [WebGet(UriTemplate = "/AllCompanies",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Bare)]
        List<CompanyWS> GetAllCompanies();
        [WebGet(UriTemplate = "/Company/{id}",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Bare)]
        CompanyWS GetCompany(string id);
        [WebInvoke(UriTemplate = "/Company",
         Method="POST",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Bare)]
        void NewCompany(CompanyWS company);
        [WebInvoke(UriTemplate = "/Company",
            Method="PUT", 
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Bare)]
        void UpdateCompany(CompanyWS company);
        [WebInvoke(UriTemplate = "/Company/{id}",
            Method="DELETE",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Bare)]
        void DeleteCompany(string id);
        
    }
         
    [DataContract]
    public class CompanyWS
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string URL { get; set; }
        [DataMember]
        public string ActivitySectorName { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public string CompanySize { get; set; }
    }
}
