using Excellerent.SharedModules.Seed;
using Excellerent.Timesheet.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Excellerent.Timesheet.Domain.Entities
{
    public class TimeSheetEntity : BaseEntity<TimeSheet>
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int? TotalHours { get; set; }
        public int Status { get; set; }
        public Guid EmployeeId { get; set; }
        public List<TimeEntryEntity> TimeEntry { get; set; }
        public TimeSheetEntity()
        {
            TimeEntry = new List<TimeEntryEntity>();

        }

        public TimeSheetEntity(TimeSheet timeSheet) : base(timeSheet)
        {
            FromDate = timeSheet.FromDate;
            ToDate = timeSheet.ToDate;
            TotalHours = timeSheet.TotalHours;
            Status = timeSheet.Status;
            EmployeeId = timeSheet.EmployeeId;
            TimeEntry = timeSheet.TimeEntry?.Select(x => new TimeEntryEntity(x)).ToList();

        }
        public override TimeSheet MapToModel()
        {
            TimeSheet timeSheet = new TimeSheet();
            timeSheet.FromDate = FromDate;
            timeSheet.ToDate = ToDate;
            timeSheet.TotalHours = TotalHours;
            timeSheet.Status = Status;
            timeSheet.EmployeeId = EmployeeId;
            timeSheet.TimeEntry = TimeEntry?.Select(x => x.MapToModel()).ToList();

            return timeSheet;
        }

        public override TimeSheet MapToModel(TimeSheet ts)
        {
            TimeSheet tsToUpdate = ts;
            tsToUpdate.FromDate = FromDate;
            tsToUpdate.ToDate = ToDate;
            tsToUpdate.TotalHours = TotalHours;
            tsToUpdate.Status = Status;
            tsToUpdate.EmployeeId = EmployeeId;
            tsToUpdate.TimeEntry = TimeEntry?.Select(x => x.MapToModel()).ToList();
            return tsToUpdate;
        }

    }
}
