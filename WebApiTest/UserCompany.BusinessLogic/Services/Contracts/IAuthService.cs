
using UserCompany.Model.Models;

namespace UserCompany.BusinessLogic.Services.Contracts
{
    public interface IAuthService
    {
        string Post(User user);
        User GetUser(string email, string password);
    }
}
