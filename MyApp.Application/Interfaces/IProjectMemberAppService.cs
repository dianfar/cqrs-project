using MyApp.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Application.Interfaces
{
    public interface IProjectMemberAppService : IDisposable
    {
        void Add(ProjectMemberViewModel viewModel);
        void Remove(Guid id);
    }
}
