using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Application.ViewModels
{
    public class UserFormViewModel : UserViewModel
    {
        private IEnumerable<RoleViewModel> roles;

        public UserFormViewModel()
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
