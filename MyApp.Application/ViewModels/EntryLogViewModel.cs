using System;

namespace MyApp.Application.ViewModels
{
    public class EntryLogViewModel
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid ProjectId { get; set; }

        public DateTime EntryDate { get; set; }

        public decimal Hours { get; set; }

        public string Description { get; set; }
    }
}
