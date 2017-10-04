using MyApp.Application.Interfaces;
using System;
using MyApp.Application.ViewModels;
using AutoMapper;
using MyApp.Domain.Interfaces;
using MyApp.Domain.Core.Bus;
using MyApp.Domain.Queries;

namespace MyApp.Application.Services
{
    public class ProjectMemberAppService : IProjectMemberAppService
    {
        private readonly IMapper mapper;
        private readonly IMediatorHandler mediatorHandler;

        public ProjectMemberAppService(IMapper mapper,
                                  IMediatorHandler bus)
        {
            this.mapper = mapper;
            this.mediatorHandler = bus;
        }

        public void Add(ProjectMemberViewModel viewModel)
        {
            var addCommand = mapper.Map<AddProjectMemberCommand>(viewModel);
            mediatorHandler.SendCommand(addCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveProjectMemberCommand(id);
            mediatorHandler.SendCommand(removeCommand);
        }
    }
}
