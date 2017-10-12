using MyApp.Application.Interfaces;
using System;
using MyApp.Application.ViewModels;
using MyApp.Domain.Core.Bus;
using AutoMapper;
using MyApp.Domain.Queries;
using MyApp.Domain.Commands;
using System.Collections.Generic;
using AutoMapper.QueryableExtensions;
using System.Threading.Tasks;

namespace MyApp.Application.Services
{
    public class ProjectAppService : IProjectAppService
    {
        private readonly IMapper mapper;
        private readonly IMediatorHandler mediatorHandler;

        public ProjectAppService(IMapper mapper,
                                IMediatorHandler mediatorHandler)
        {
            this.mapper = mapper;
            this.mediatorHandler = mediatorHandler;
        }

        public void Create(ProjectViewModel productViewModel)
        {
            var createCommand = mapper.Map<CreateNewProjectCommand>(productViewModel);
            mediatorHandler.SendCommand(createCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<CreateNewProjectViewModel> GetCreateNewProjectData()
        {
            var clients = await mediatorHandler.GetResult(new GetAllClientQuery());
            return new CreateNewProjectViewModel
            {
                Clients = clients.ProjectTo<ClientViewModel>()
            };
        }

        public async Task<IEnumerable<ProjectViewModel>> GetAll()
        {
            var projects = await mediatorHandler.GetResult(new GetAllProjectQuery());
            return projects.ProjectTo<ProjectViewModel>();
        }

        public async Task<ProjectViewModel> GetById(Guid id)
        {
            var project = await mediatorHandler.GetResult(new GetProjectByIdQuery(id));
            return mapper.Map<ProjectViewModel>(project);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveProjectCommand(id);
            mediatorHandler.SendCommand(removeCommand);
        }

        public void Update(ProjectViewModel productViewModel)
        {
            var updateCommand = mapper.Map<UpdateProjectCommand>(productViewModel);
            mediatorHandler.SendCommand(updateCommand);
        }

        public async Task<UpdateProjectViewModel> GetUpdateProjectData(Guid id)
        {
            var clients = await mediatorHandler.GetResult(new GetAllClientQuery());
            var users = await mediatorHandler.GetResult(new GetAllUserQuery());
            var project = await mediatorHandler.GetResult(new GetProjectByIdQuery(id));
            var result = mapper.Map<UpdateProjectViewModel>(project);
            result.Clients = clients.ProjectTo<ClientViewModel>();
            result.Users = users.ProjectTo<UserViewModel>();

            return result;
        }
    }
}
