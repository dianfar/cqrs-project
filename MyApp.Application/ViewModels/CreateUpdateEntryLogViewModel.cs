using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Application.ViewModels
{
    public class CreateUpdateEntryLogViewModel
    {
        private IEnumerable<EntryLogViewModel> entryLogList;
        private IEnumerable<ProjectViewModel> projectList;

        public CreateUpdateEntryLogViewModel()
        {
            entryLogList = new List<EntryLogViewModel>();
            projectList = new List<ProjectViewModel>();
        }

        public IEnumerable<EntryLogViewModel> EntryLogs
        {
            get { return entryLogList; }
            set { entryLogList = value; }
        }

        public IEnumerable<ProjectViewModel> Projects
        {
            get { return projectList; }
            set { projectList = value; }
        }
    }
}
