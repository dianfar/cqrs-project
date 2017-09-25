using MyApp.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Application.Interfaces
{
    public interface IAccountAppService : IDisposable
    {
        void Login(LoginViewModel viewModel);
    }
}
