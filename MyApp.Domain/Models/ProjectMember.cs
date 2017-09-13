using MyApp.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Models
{
    public class ProjectMember : Entity
    {
        public Project Project { get; set; }
        public User User { get; set; }
    }
}
