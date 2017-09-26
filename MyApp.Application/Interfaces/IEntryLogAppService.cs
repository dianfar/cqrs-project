using MyApp.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Application.Interfaces
{
    public interface IEntryLogAppService : IDisposable
    {
        CreateUpdateEntryLogViewModel GetByUser(Guid userId);
        CreateUpdateEntryLogViewModel GetUpdatedData(Guid id);
        void Create(EntryLogViewModel entryLogViewModel);
        void Update(EntryLogViewModel entryLogViewModel);
        void Remove(Guid id);
    }
}
