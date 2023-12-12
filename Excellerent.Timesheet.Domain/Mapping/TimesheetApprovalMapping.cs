using Excellerent.Timesheet.Domain.Dtos;
using Excellerent.Timesheet.Domain.Entities;
using Excellerent.Timesheet.Domain.Models;

namespace Excellerent.Timesheet.Domain.Mapping
{
    public static class TimesheetApprovalMapping
    {
        public static TimesheetApprovalEntity MapToEntity(this TimesheetApprovalDto timesheetAprovalDto)
        {
            TimesheetApprovalEntity timesheetApprovalEntity = new TimesheetApprovalEntity();

            timesheetApprovalEntity.TimesheetId = timesheetAprovalDto.TimesheetId;
            timesheetApprovalEntity.ProjectId = timesheetAprovalDto.ProjectId;
            timesheetApprovalEntity.Status = timesheetAprovalDto.Status;
            return timesheetApprovalEntity;
        }
        public static TimesheetApprovalDto MapToDto(this TimesheetApprovalEntity timesheetApprovalEntity)
        {
            TimesheetApprovalDto timesheetAprovalDto = new TimesheetApprovalDto();

            timesheetAprovalDto.TimesheetId = timesheetApprovalEntity.TimesheetId;
            timesheetAprovalDto.ProjectId = timesheetApprovalEntity.ProjectId;
            timesheetAprovalDto.Status = timesheetApprovalEntity.Status;

            return timesheetAprovalDto;
        }
    }

}
