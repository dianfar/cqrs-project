using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Application.ViewModels
{
    public class RegisterNewUserViewModel
    {
        private IEnumerable<RoleViewModel> roles;

        public RegisterNewUserViewModel()
        {
            roles = new List<RoleViewModel>();
        }

        public IEnumerable<RoleViewModel> Roles
        {
            get { return roles; }
            set { roles = value; }
        }
    }
}
