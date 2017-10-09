using MyApp.Application.Interfaces;
using System;
using MyApp.Application.ViewModels;
using MyApp.Domain.Core.Bus;
using AutoMapper;
using MyApp.Domain.Queries;
using AutoMapper.QueryableExtensions;
using System.Threading.Tasks;

namespace MyApp.Application.Services
{
    public class EntryLogAppService : IEntryLogAppService
    {
        private readonly IMapper mapper;
        private readonly IMediatorHandler mediatorHandler;

        public EntryLogAppService(IMapper mapper,
                               IMediatorHandler mediatorHandler)
        {
            this.mapper = mapper;
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

        public async Task<CreateUpdateEntryLogViewModel> GetUpdatedData(Guid userId, Guid id)
        {
            var entryLogs = await mediatorHandler.GetResult(new GetEntryLogByUserQuery(userId));
            var projects = await mediatorHandler.GetResult(new GetProjectsByUserQuery(userId));
            var entryLog = await mediatorHandler.GetResult(new GetEntryLogByIdQuery(id));

            return new CreateUpdateEntryLogViewModel
            {
                Id = entryLog.Id,
                EntryDate = entryLog.EntryDate,
                Hours = entryLog.Hours,
                Description = entryLog.Description,
                UserId = entryLog.User.Id,
                ProjectId = entryLog.Project.Id,
                EntryLogs = entryLogs.ProjectTo<EntryLogViewModel>(),
                Projects = projects.ProjectTo<ProjectViewModel>()
        };
        }

        public async Task<CreateUpdateEntryLogViewModel> GetByUser(Guid userId)
        {
            var entryLogs = await mediatorHandler.GetResult(new GetEntryLogByUserQuery(userId));
            var projects = await mediatorHandler.GetResult(new GetProjectsByUserQuery(userId));

            return new CreateUpdateEntryLogViewModel
            {
                EntryLogs = entryLogs.ProjectTo<EntryLogViewModel>(),
                Projects = projects.ProjectTo<ProjectViewModel>()
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
