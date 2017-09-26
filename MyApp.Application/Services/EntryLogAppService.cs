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
    public class EntryLogAppService : IEntryLogAppService
    {
        private readonly IMapper mapper;
        private readonly IEntryLogRepository entryLogRepository;
        private readonly IProjectRepository projectRepository;
        private readonly IMediatorHandler mediatorHandler;

        public EntryLogAppService(IMapper mapper,
                               IEntryLogRepository entryLogRepository,
                               IProjectRepository projectRepository,
                               IMediatorHandler mediatorHandler)
        {
            this.mapper = mapper;
            this.entryLogRepository = entryLogRepository;
            this.projectRepository = projectRepository;
            this.mediatorHandler = mediatorHandler;
        }

        public void Create(EntryLogViewModel entryLogViewModel)
        {
            var addCommand = mapper.Map<AddEntryLogCommand>(entryLogViewModel);
            mediatorHandler.SendCommand(addCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public CreateUpdateEntryLogViewModel GetUpdatedData(Guid id)
        {
            var entryLogs = entryLogRepository.GetAll().ProjectTo<EntryLogViewModel>();
            var projects = projectRepository.GetAll().ProjectTo<ProjectViewModel>();
            var entryLog = entryLogRepository.GetById(id);

            return new CreateUpdateEntryLogViewModel
            {
                Id = entryLog.Id,
                EntryDate = entryLog.EntryDate,
                Hours = entryLog.Hours,
                Description = entryLog.Description,
                UserId = entryLog.User.Id,
                ProjectId = entryLog.Project.Id,
                EntryLogs = entryLogs,
                Projects = projects
            };
        }

        public CreateUpdateEntryLogViewModel GetByUser(Guid userId)
        {
            var entryLogs = entryLogRepository.GetByUser(userId).ProjectTo<EntryLogViewModel>();
            var projects = projectRepository.GetAll().ProjectTo<ProjectViewModel>();

            return new CreateUpdateEntryLogViewModel
            {
                EntryLogs = entryLogs,
                Projects = projects
            };
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveEntryLogCommand(id);
            mediatorHandler.SendCommand(removeCommand);
        }

        public void Update(EntryLogViewModel entryLogViewModel)
        {
            var addCommand = mapper.Map<UpdateEntryLogCommand>(entryLogViewModel);
            mediatorHandler.SendCommand(addCommand);
        }
    }
}
