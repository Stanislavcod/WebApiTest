using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using UserCompany.BusinessLogic.Helpers.Cryptography;
using UserCompany.BusinessLogic.Services.Contracts;
using UserCompany.Model.DataBaseContext;
using UserCompany.Model.Models;
using UserCompany.Model.ModelsDto;
using UserCompany.Model.ViewModels;

namespace UserCompany.BusinessLogic.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDataBaseContext _context;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AuthService(ApplicationDataBaseContext context, ITokenService tokenService, IMapper mapper)
        {
            _context = context;
            _tokenService = tokenService;
            _mapper = mapper;
        }
        public TokenDto GetToken(User user)
        {
            var token = _tokenService.CreateToken(user);
            var tokenHandler = new JwtSecurityTokenHandler();
            var encodedJwt = tokenHandler.WriteToken(token);
            var refreshToken = AddRefreshToken(user);

            var mappedUser = _mapper.Map<User, UserDto>(user);
            return new TokenDto
            {
                UserId = user.Id,
                Token = encodedJwt,
                RefreshToken = refreshToken.Id,
                UserName = user.Login,
                User = mappedUser,
                ValidFrom = token.ValidFrom,
                ValidTo = token.ValidTo
            };
        }

        private RefreshToken AddRefreshToken(User user)
        {
            var now = DateTime.UtcNow;
            var token = new RefreshToken
            {
                Id = new JwtSecurityTokenHandler().WriteToken(_tokenService.CreateToken(user)),
                UserId = user.Id,
                ValidTo = now.AddDays(1),
                ValidFrom = now
            };
            _context.RefreshTokens.Add(token);
            _context.SaveChanges();
            return token;
        }

        public TokenDto Token(LoginDto loginDto)
        {
            var user = AuthUser(loginDto);
            return GetToken(user);
        }
        //аутентификация
        public User AuthUser(LoginDto loginDto)
        {
            var user = _context.Users
                .SingleOrDefault(x => x.Login == loginDto.Login);

            if (user == null) throw new Exception("Пользователь не найден.");

            if (PasswordHasher.VerifyPassword(
                user.PasswordSalt,
                user.PasswordHash,
                loginDto.Password))
            {
                return user;
            }
            throw new Exception("Неверный пароль.");
        }

        public TokenDto Refresh(RefreshTokenDto model)
        {
            var refreshToken = _context.RefreshTokens
                .FirstOrDefault(x => x.Id == model.RefreshToken);

            if (refreshToken == null) throw new Exception("refreshIsExpired");
            if (refreshToken.ValidTo < DateTime.UtcNow) throw new Exception("refreshIsExpired");

            var user = _context.Users.FirstOrDefault(x => x.Login == model.Login);
            if (user == null) throw new Exception("Пользователь не найден");
            _context.RefreshTokens.Remove(refreshToken);

            return GetToken(user);
        }
    }
}
