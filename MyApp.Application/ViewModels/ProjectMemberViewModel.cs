using System;

namespace MyApp.Application.ViewModels
{
    public class ProjectMemberViewModel
    {
        public Guid Id { get; set; }

        public Guid ProjectId { get; set; }

        public Guid UserId { get; set; }

        public string UserName { get; set; }
    }
}
