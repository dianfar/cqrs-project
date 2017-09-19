using MyApp.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Application.Interfaces
{
    public interface IEntryLogAppService : IDisposable
    {
        IEnumerable<CreateUpdateEntryLogViewModel> GetByUser();
        EntryLogViewModel GetById(Guid id);
        void Create(EntryLogViewModel entryLogViewModel);
        void Update(EntryLogViewModel entryLogViewModel);
        void Remove(Guid id);
    }
}
