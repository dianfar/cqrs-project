using MyApp.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces
{
    public interface IEntryLogAppService : IDisposable
    {
        Task<CreateUpdateEntryLogViewModel> GetByUser(Guid userId);
        Task<CreateUpdateEntryLogViewModel> GetUpdatedData(Guid userId, Guid id);
        Task<IEnumerable<EntryLogViewModel>> GetEntryLogsByUser(Guid userId);
        void Create(EntryLogViewModel entryLogViewModel);
        void Update(EntryLogViewModel entryLogViewModel);
        void Remove(Guid id);
    }
}
