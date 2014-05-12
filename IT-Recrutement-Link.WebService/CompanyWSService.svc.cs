using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using IT_Recrutement_Link.Service;
using IT_Recrutement_Link.Domain.Domain;
using IT_Recrutement_Link.DataAccess;

namespace IT_Recrutement_Link.WebService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "CompanyWSService" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez CompanyWSService.svc ou CompanyWSService.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class CompanyWSService : ICompanyWSService
    {
        private CompanyService companyService;
        public CompanyWSService()
        {
            companyService = new CompanyService(new Context());
        }
        public List<CompanyWS> GetAllCompanies()
        {
           // CompanyService companyService = new CompanyService(new Context());
            IList<Company> companies = companyService.ViewAllCompanies();
            return convertDomainToDataContractMany(companies);
        }
        private List<CompanyWS> convertDomainToDataContractMany(IList<Company> companies)
        {
            List<CompanyWS> companiesWS = new List<CompanyWS>();
            foreach (Company company in companies)
            {
                companiesWS.Add(convertDomainToDataContractOne(company));
            }
            return companiesWS;
        }
        private CompanyWS convertDomainToDataContractOne(Company company)
        {
            return new CompanyWS
            {
                Id = company.Id,
                Email = company.Email,
                URL = company.URL,
                ActivitySectorName = company.ActivitySectorName,
                Name = company.Name,
                Address = company.Address,
                Country = company.Country,
                CompanySize = company.CompanySize,

            };
        }
        public CompanyWS GetCompany(string id)
        {
            int intId = Convert.ToInt32(id);
            //CompanyService companyService = new CompanyService(new Context());
            Company cp = companyService.ViewCompany(intId);
            return convertDomainToDataContractOne(cp);
        }
        public void NewCompany(CompanyWS company)
        {
            //CompanyService companyService = new CompanyService(new Context());
            Company company1 = new Company(company.Id, company.Email, company.Name, company.URL, company.Address, company.ActivitySectorName, company.Country);
            companyService.AddCompany(company1);
        }
        public void UpdateCompany(CompanyWS company)
        {
            //CompanyService companyService = new CompanyService(new Context());
            Company company1 = new Company(company.Id, company.Email, company.Name, company.URL, company.Address, company.ActivitySectorName, company.Country);
            companyService.ModifyCompany(company1);
        }
        public void DeleteCompany(string id)
        {
            //CompanyService companyService = new CompanyService(new Context());
            int intId = Convert.ToInt32(id);
            companyService.RemoveCompany(companyService.ViewCompany(intId));
        }

    }
    
}
