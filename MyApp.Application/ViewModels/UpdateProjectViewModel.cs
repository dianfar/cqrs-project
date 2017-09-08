using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Application.ViewModels
{
    public class UpdateProjectViewModel
    {
        private IEnumerable<ClientViewModel> clientList;

        public UpdateProjectViewModel()
        {
            clientList = new List<ClientViewModel>();
        }

        public ProjectViewModel SelectedProject { get; set; }

        public IEnumerable<ClientViewModel> Clients
        {
            get { return clientList; }
            set { clientList = value; }
        }
    }
}
