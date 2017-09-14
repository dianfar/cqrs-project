using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Application.ViewModels
{
    public class ProjectMemberViewModel
    {
        public Guid Id { get; set; }

        public UserViewModel User { get; set; }
    }
}
