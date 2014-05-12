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
        [WebGet(UriTemplate = "/GetAllCompanies",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Bare)]
        List<CompanyWS> GetAllCompanies();
        [WebInvoke(UriTemplate = "/GetCompany",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Bare)]
        CompanyWS GetCompany(int id);
        [WebInvoke(UriTemplate = "/NewCompany",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Bare)]
        void NewCompany(CompanyWS company);
        [WebInvoke(UriTemplate = "/UpdateCompany",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Bare)]
        void UpdateCompany(CompanyWS company);
        [WebInvoke(UriTemplate = "/DeleteCompany",
         RequestFormat = WebMessageFormat.Json,
         ResponseFormat = WebMessageFormat.Json,
         BodyStyle = WebMessageBodyStyle.Bare)]
        void DeleteCompany(CompanyWS company);
        
    }
         
    [DataContract]
    public class CompanyWS
    {
        [DataMember]
        public int Id { get; set; }
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
