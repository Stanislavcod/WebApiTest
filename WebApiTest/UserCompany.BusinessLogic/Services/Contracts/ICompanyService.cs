using UserCompany.Model.Models;

namespace UserCompany.BusinessLogic.Services.Contracts
{
    internal interface ICompanyService
    {
        IEnumerable<Company> GetCompanies();
        void AddAllCompanies();
    }
}
