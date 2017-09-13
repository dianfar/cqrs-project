using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Application.ViewModels
{
    public class UpdateUserViewModel : UserViewModel
    {
        private IEnumerable<RoleViewModel> roles;

        public UpdateUserViewModel()
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
