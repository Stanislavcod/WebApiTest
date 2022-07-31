using System.IdentityModel.Tokens.Jwt;
using UserCompany.Model.Models;

namespace UserCompany.BusinessLogic.Services.Contracts
{
    public interface ITokenService
    {
        JwtSecurityToken CreateToken(User user);
    }
}
