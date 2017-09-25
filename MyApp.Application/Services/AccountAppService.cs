using MyApp.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using MyApp.Application.ViewModels;

namespace MyApp.Application.Services
{
    public class AccountAppService : IAccountAppService
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Login(LoginViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
