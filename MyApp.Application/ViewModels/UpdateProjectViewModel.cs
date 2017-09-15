using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Application.ViewModels
{
    public class UpdateProjectViewModel : ProjectViewModel
    {
        private IEnumerable<ClientViewModel> clientList;
        private IEnumerable<UserViewModel> userList;

        public UpdateProjectViewModel()
        {
            clientList = new List<ClientViewModel>();
            userList = new List<UserViewModel>();
        }

        public IEnumerable<ClientViewModel> Clients
        {
            get { return clientList; }
            set { clientList = value; }
        }

        public IEnumerable<UserViewModel> Users
        {
            get { return userList; }
            set { userList = value; }
        }
    }
}
