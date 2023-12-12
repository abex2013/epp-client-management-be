using Excellerent.SharedInfrastructure.Context;
using Excellerent.SharedInfrastructure.Repository;
using Excellerent.Timesheet.Domain.Interfaces.Repository;
using Excellerent.Timesheet.Domain.Models;
using Excellerent.Timesheet.Domain.Services;
using System;

namespace Excellerent.Timesheet.Infrastructure.Repositories
{
    public class TimesheetApprovalRepository : AsyncRepository<TimesheetApproval>, ITimesheetApprovalRepository
    {
        private readonly EPPContext _context;

        public TimesheetApprovalRepository(EPPContext context) : base(context)
        {
            _context = context;
        }
    }
}
