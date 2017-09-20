using MyApp.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Models
{
    public class EntryLog : Entity
    {
        public EntryLog() { }

        public EntryLog(Guid id, DateTime entryDate, decimal Hours, string description)
        {
            this.Id = id;
            this.EntryDate = entryDate;
            this.Hours = Hours;
            this.Description = description;
        }

        public User User { get; set; }
        public Project Project { get; set; }
        public DateTime EntryDate { get; set; }
        public decimal Hours { get; set; }
        public string Description { get; set; }
    }
}
