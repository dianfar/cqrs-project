using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Application.ViewModels
{
    public class UserFormViewModel : UserViewModel
    {
        private IEnumerable<RoleViewModel> roles;

        public IEnumerable<string> ErrorMessages { get; set; }

        public bool EditMode { get; set; }

        public UserFormViewModel()
        {
            roles = new List<RoleViewModel>();
            ErrorMessages = new List<string>();
        }

        public IEnumerable<RoleViewModel> Roles
        {
            get { return roles; }
            set { roles = value; }
        }
    }
}
