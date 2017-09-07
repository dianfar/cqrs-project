using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Application.ViewModels
{
    public class CreateNewProjectViewModel
    {
        private IEnumerable<ClientViewModel> clientList;

        public CreateNewProjectViewModel()
        {
            clientList = new List<ClientViewModel>();
        }

        public IEnumerable<ClientViewModel> Clients
        {
            get { return clientList; }
            set { clientList = value; }
        }
    }
}
