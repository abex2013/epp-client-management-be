using Excellerent.Timesheet.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excellerent.Timesheet.Domain.Dtos
{
    public class TimesheetApprovalDto
    {
        public Guid TimesheetId { get; set; }
        public Guid ProjectId { get; set; }
        public ApprovalStatus Status { get; set; }
    }
}
