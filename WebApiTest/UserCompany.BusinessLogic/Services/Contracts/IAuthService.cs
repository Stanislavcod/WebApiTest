
using UserCompany.Model.Models;
using UserCompany.Model.ModelsDto;
using UserCompany.Model.ViewModels;

namespace UserCompany.BusinessLogic.Services.Contracts
{
    public interface IAuthService
    {
        TokenDto Token(LoginDto loginDto);
        TokenDto GetToken(User user);
        TokenDto Refresh(RefreshTokenDto model);
    }
}
