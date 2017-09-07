using MyApp.Application.Interfaces;
using System;
using MyApp.Application.ViewModels;
using MyApp.Domain.Core.Bus;
using AutoMapper;
using MyApp.Domain.Interfaces;
using MyApp.Domain.Commands;
using System.Collections.Generic;
using AutoMapper.QueryableExtensions;

namespace MyApp.Application.Services
{
    public class ProjectAppService : IProjectAppService
    {
        private readonly IMapper mapper;
        private readonly IProjectRepository projectRepository;
        private readonly IClientRepository clientRepository;
        private readonly IMediatorHandler mediatorHandler;

        public ProjectAppService(IMapper mapper,
                                IProjectRepository projectRepository,
                                IClientRepository clientRepository,
                                IMediatorHandler mediatorHandler)
        {
            this.mapper = mapper;
            this.projectRepository = projectRepository;
            this.clientRepository = clientRepository;
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

        public CreateNewProjectViewModel GetCreateNewProjectData()
        {
            var clients = clientRepository.GetAll().ProjectTo<ClientViewModel>();
            return new CreateNewProjectViewModel
            {
                Clients = clients
            };
        }

        public IEnumerable<ProjectViewModel> GetAll()
        {
            return projectRepository.GetAll().ProjectTo<ProjectViewModel>();
        }

        public ProjectViewModel GetById(Guid id)
        {
            return mapper.Map<ProjectViewModel>(projectRepository.GetById(id));
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveProductCommand(id);
            mediatorHandler.SendCommand(removeCommand);
        }

        public void Update(ProjectViewModel productViewModel)
        {
            var updateCommand = mapper.Map<UpdateProjectCommand>(productViewModel);
            mediatorHandler.SendCommand(updateCommand);
        }
    }
}
