using MyApp.Application.ViewModels;
using System;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces
{
    public interface IAccountAppService : IDisposable
    {
        Task<UserViewModel> Login(LoginViewModel viewModel);
    }
}
