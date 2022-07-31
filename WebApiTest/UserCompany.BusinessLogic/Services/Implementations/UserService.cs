
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UserCompany.BusinessLogic.Helpers.Cryptography;
using UserCompany.BusinessLogic.Services.Contracts;
using UserCompany.Model.DataBaseContext;
using UserCompany.Model.Models;
using UserCompany.Model.ViewModels;

namespace UserCompany.BusinessLogic.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly ApplicationDataBaseContext _context;
        private readonly IMapper _mapper;
        public UserService(ApplicationDataBaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool Register(RegisterDto registerDto)
        {
            var user = _mapper.Map<RegisterDto, User>(registerDto);
            PasswordHasher.HashPassword(registerDto.Password, out byte[] passwordHash,
                out byte[] passwordSalt);
            user.PasswordSalt = passwordSalt;
            user.PasswordHash = passwordHash;
            _context.Users.Add(user);
            return _context.SaveChanges() > 0;

        }

        public bool UserExists(string login)
        {
            return _context.Users
                .AsNoTracking()
                .Any(x => x.Login == login.ToLower());
        }
    }
}
