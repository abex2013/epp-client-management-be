using Excellerent.SharedModules.Seed;
using System;
using System.ComponentModel.DataAnnotations;

namespace Excellerent.Timesheet.Domain.Models
{
    public enum ApprovalStatus
    {
        Requested,
        Approved,
        Rejected
    }
    public class TimesheetApproval : BaseAuditModel
    {
        public Guid TimesheetId { get; set; }
        public virtual TimeSheet Timesheet { get; set; }
        public Guid ProjectId { get; set; }
        public ApprovalStatus Status { get; set; }
    }
}
