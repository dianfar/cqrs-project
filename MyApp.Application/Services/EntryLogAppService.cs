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
        private readonly IUserRepository userRepository;
        private readonly IProjectRepository projectRepository;

        public EntryLogAppService(IMapper mapper,
                               IEntryLogRepository entryLogRepository,
                               IUserRepository userRepository,
                               IProjectRepository projectRepository)
        {
            this.mapper = mapper;
            this.entryLogRepository = entryLogRepository;
            this.userRepository = userRepository;
            this.projectRepository = projectRepository;
        }

        public void Create(EntryLogViewModel entryLogViewModel)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public EntryLogViewModel GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public CreateUpdateEntryLogViewModel GetByUser()
        {
            var entryLogs = entryLogRepository.GetAll().ProjectTo<EntryLogViewModel>();
            var users = userRepository.GetAll().ProjectTo<UserViewModel>();
            var projects = projectRepository.GetAll().ProjectTo<ProjectViewModel>();

            return new CreateUpdateEntryLogViewModel
            {
                EntryLogs = entryLogs,
                Users = users,
                Projects = projects
            };
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(EntryLogViewModel entryLogViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
