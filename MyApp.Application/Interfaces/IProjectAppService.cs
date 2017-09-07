using MyApp.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace MyApp.Application.Interfaces
{
    public interface IProjectAppService : IDisposable
    {
        IEnumerable<ProjectViewModel> GetAll();
        ProjectViewModel GetById(Guid id);
        void Create(ProjectViewModel productViewModel);
        void Update(ProjectViewModel productViewModel);
        void Remove(Guid id);
        CreateNewProjectViewModel GetCreateNewProjectData();
    }
}
