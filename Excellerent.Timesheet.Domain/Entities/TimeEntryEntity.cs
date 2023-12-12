using Excellerent.SharedModules.Seed;
using Excellerent.Timesheet.Domain.Models;
using System;

namespace Excellerent.Timesheet.Domain.Entities
{
    public class TimeEntryEntity : BaseEntity<TimeEntry>
    {
        public TimeEntryEntity(TimeEntry model) : base(model)
        {
            Note = model.Note;
            Date = model.Date;
            Index = model.Index;
            Hour = model.Hour;
            ProjectId = model.ProjectId;
            TimesheetGuid = model.TimesheetGuid;
        }
        public TimeEntryEntity()
        {

        }
        public string Note { get; set; }
        public DateTime Date { get; set; }
        public int Index { get; set; }
        public int Hour { get; set; }
        public Guid ProjectId { get; set; }
        public Guid TimesheetGuid { get; set; }
        public override TimeEntry MapToModel()
        {
            TimeEntry timeEntry = new TimeEntry(Note, Date, Index, Hour, ProjectId, TimesheetGuid);
            return timeEntry;
        }

        public override TimeEntry MapToModel(TimeEntry entry)
        {
            throw new NotImplementedException();
        }
    }
}
