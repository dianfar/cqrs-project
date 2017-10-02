using MyApp.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces
{
    public interface IProjectAppService : IDisposable
    {
        Task<IEnumerable<ProjectViewModel>> GetAll();
        Task<ProjectViewModel> GetById(Guid id);
        void Create(ProjectViewModel productViewModel);
        void Update(ProjectViewModel productViewModel);
        void Remove(Guid id);
        CreateNewProjectViewModel GetCreateNewProjectData();
        UpdateProjectViewModel GetUpdateProjectData(Guid id);
    }
}
