using Excellerent.SharedModules.Interface.Service;
using Excellerent.Timesheet.Domain.Entities;
using Excellerent.Timesheet.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Excellerent.Timesheet.Domain.Interfaces.Service
{
    public interface ITimesheetApprovalService : ICRUD<TimesheetApprovalEntity, TimesheetApproval>
    {
        Task<IEnumerable<TimesheetApprovalEntity>> GetTimesheetApprovalStatus(Guid tsGuid);
    }
}
