using Excellerent.SharedModules.Services;
using Excellerent.Timesheet.Domain.Entities;
using Excellerent.Timesheet.Domain.Interfaces.Repository;
using Excellerent.Timesheet.Domain.Interfaces.Service;
using Excellerent.Timesheet.Domain.Mapping;
using Excellerent.Timesheet.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Excellerent.Timesheet.Domain.Services
{
    public class TimesheetApprovalService : CRUD<TimesheetApprovalEntity, TimesheetApproval>, ITimesheetApprovalService
    {
        private readonly ITimesheetApprovalRepository _repository;

        public TimesheetApprovalService(ITimesheetApprovalRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TimesheetApprovalEntity>> GetTimesheetApprovalStatus(Guid tsGuid)
        {
            var timesheetApprovals = (await _repository.FindAsync(x => x.TimesheetId == tsGuid)).ToList();

            return timesheetApprovals.Select(tsa => new TimesheetApprovalEntity(tsa));
        }
    }
}
