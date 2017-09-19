using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Application.ViewModels
{
    public class CreateUpdateEntryLogViewModel
    {
        private IEnumerable<EntryLogViewModel> entryLogList;
        private IEnumerable<UserViewModel> userList;
        private IEnumerable<ProjectViewModel> projectList;

        public CreateUpdateEntryLogViewModel()
        {
            entryLogList = new List<EntryLogViewModel>();
            userList = new List<UserViewModel>();
            projectList = new List<ProjectViewModel>();
        }

        public IEnumerable<EntryLogViewModel> EntryLogs
        {
            get { return entryLogList; }
            set { entryLogList = value; }
        }

        public IEnumerable<UserViewModel> Users
        {
            get { return userList; }
            set { userList = value; }
        }

        public IEnumerable<ProjectViewModel> Projects
        {
            get { return projectList; }
            set { projectList = value; }
        }
    }
}
