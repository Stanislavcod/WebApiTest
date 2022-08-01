

using UserCompany.Model.Models;
using UserCompany.Model.ViewModels;

namespace UserCompany.BusinessLogic.Services.Contracts
{
    public interface IUserService
    {
        public bool Register(RegisterDto registerDto);
        public bool UserExists(string login);
    }
}
