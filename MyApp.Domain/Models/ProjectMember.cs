using MyApp.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Models
{
    public class ProjectMember : Entity
    {
        public ProjectMember() { }

        public ProjectMember(Guid id)
        {
            Id = id;
        }

        public Project Project { get; set; }
        public User User { get; set; }
    }
}
