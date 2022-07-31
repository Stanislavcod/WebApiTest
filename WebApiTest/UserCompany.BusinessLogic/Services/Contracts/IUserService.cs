

using UserCompany.Model.Models;
using UserCompany.Model.ViewModels;

namespace UserCompany.BusinessLogic.Services.Contracts
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        IQueryable<User> GetUser(int id);
        void Delete(int id);
        void Create(CreateUserViewModel model);
        void Update(UpdateUserViewModel model);
    }
}
