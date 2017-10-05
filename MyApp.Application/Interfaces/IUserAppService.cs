using MyApp.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces
{
    public interface IUserAppService : IDisposable
    {
        Task<UserFormViewModel> GetRegisterNewUserData();
        Task<IEnumerable<UserViewModel>> GetAll();
        Task<UserViewModel> GetById(Guid id);
        Task<UserFormViewModel> GetUpdateUserData(Guid id);
        void Create(UserViewModel userViewModel);
        void Update(UserViewModel userViewModel);
        void Remove(Guid id);
    }
}
