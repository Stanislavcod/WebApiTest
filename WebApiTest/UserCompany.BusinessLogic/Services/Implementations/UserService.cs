
using AutoMapper;
using UserCompany.BusinessLogic.Services.Contracts;
using UserCompany.Model.DataBaseContext;
using UserCompany.Model.Models;
using UserCompany.Model.ViewModels;

namespace UserCompany.BusinessLogic.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly ApplicationDataBaseContext _userContext;
        private readonly IMapper _mapper;
        public UserService(ApplicationDataBaseContext userContext, IMapper mapper)
        {
            _userContext = userContext;
            _mapper = mapper;
        }
        public IEnumerable<User> GetUsers()
        {
            return _userContext.Users.ToList();
        }
        public IQueryable<User> GetUser(int id)
        {
            return _userContext.Users.Where(x => x.Id == id);
        }
        public void Delete(int id)
        {
            _userContext.Users.Remove(GetUser(id).FirstOrDefault());
            _userContext.SaveChanges();
        }
        public void Create(CreateUserViewModel userViewModel)
        {
            if (_userContext.Users.Any(x => x.Email == userViewModel.Email))
                throw new Exception($"Данный пользователь {userViewModel.Email} уже зарегестрирован.");
            var user = _mapper.Map<CreateUserViewModel, User>(userViewModel);
            user.Name = userViewModel.Name;
            user.Email = userViewModel.Email;
            user.Password = userViewModel.Password;
            _userContext.Users.Add(user);
            _userContext.SaveChanges();
        }
        public void Update(UpdateUserViewModel userViewModel)
        {
            var user = _mapper.Map<UpdateUserViewModel, User>(userViewModel);
            user.Name = userViewModel.Name;
            user.PhoneNumber = userViewModel.PhoneNumber;
            user.Email = userViewModel.Email;
            user.Password = userViewModel.Password;
            _userContext.Update(user);
            _userContext.SaveChanges();
        }
    }
}
