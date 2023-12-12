using Excellerent.APIModularization.Controllers;
using Excellerent.APIModularization.Logging;
using Excellerent.SharedModules.DTO;
using Excellerent.Timesheet.Domain.Dtos;
using Excellerent.Timesheet.Domain.Interfaces.Service;
using Excellerent.Timesheet.Domain.Mapping;
using Excellerent.Timesheet.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Excellerent.Timesheet.Presentation.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class TimeSheetController : AuthorizedController
    {
        private readonly ITimeSheetService _timeSheetService;
        private readonly ITimeEntryService _timeEntryService;
        private readonly ITimesheetApprovalService _timesheetApprovalService;
        private readonly static string _feature = "Timesheet";

        public TimeSheetController(IHttpContextAccessor htttpContextAccessor, IConfiguration configuration, IBusinessLog _businessLog, ITimeSheetService timeSheetService, ITimeEntryService timeEntryService, ITimesheetApprovalService timesheetAprovalService) : base(htttpContextAccessor, configuration, _businessLog, _feature)
        {
            _timeSheetService = timeSheetService;
            _timeEntryService = timeEntryService;
            _timesheetApprovalService = timesheetAprovalService;
        }

        #region Timesheet

        [AllowAnonymous]
        [HttpGet("Timesheets/{id}")]
        public Task<ResponseDTO> GetTimesheet(Guid id)
        {
            return _timeSheetService.GetTimeSheet(id);
        }

        [AllowAnonymous]
        [HttpGet("Timesheets")]
        public Task<ResponseDTO> GetTimesheet(Guid employeeId, DateTime? date)
        {
            return _timeSheetService.GetTimeSheet(employeeId, date);
        }

        #endregion

        #region Time Entry

        [AllowAnonymous]
        [HttpGet("TimeEntries/{id}")]
        public Task<ResponseDTO> GetTimeEntry(Guid id)
        {
            return _timeEntryService.GetTimeEntry(id);
        }

        [AllowAnonymous]
        [HttpGet("TimeEntries")]
        public Task<ResponseDTO> GetTimeEntries(Guid timeSheetId, DateTime? date, Guid? projectId)
        {
            return _timeEntryService.GetTimeEntries(timeSheetId, date, projectId);
        }
        
        [AllowAnonymous]
        [HttpPost("TimeEntries")]
        public Task<ResponseDTO> AddTimeEntry([FromQuery]Guid employeeId, [FromBody]TimeEntryDto timeEntryDto)
        {
            return _timeEntryService.AddTimeEntry(employeeId, timeEntryDto);
        }

        [AllowAnonymous]
        [HttpPut("TimeEntries")]
        public Task<ResponseDTO> UpdateTimeEntry(TimeEntryDto timeEntryDto)
        {
            return _timeEntryService.UpdateTimeEntry(timeEntryDto);
        }
        [AllowAnonymous]
        [HttpPost("TimeEntriesForRange")]
        public Task<ResponseDTO> AddTimeEntry([FromQuery] Guid employeeId, [FromBody] TimeEntryDto[] entries)
        {
            return _timeEntryService.AddTImeEntryForRangeOfDays(employeeId, entries);
        }
        [HttpDelete("DeleteTimeEntry")]
        [AllowAnonymous]
        public async Task<ResponseDTO> DeleteTimeEntry(Guid timeEntryId)
        {
            try
            {
                return await _timeEntryService.RemoveTimeEntryById(timeEntryId);
            }
            catch (Exception ex)
            {
                return new ResponseDTO(ResponseStatus.Error, ex.Message, null);
            }
        }

        #endregion

        #region TimesheetApproval

        [HttpGet("TimesheetAproval")]
        [AllowAnonymous]
        public async Task<ResponseDTO> GetApprovalStatus(Guid timesheetGuid)
        {
            try
            {
                var timesheetApprovalEntities = await _timesheetApprovalService.GetTimesheetApprovalStatus(timesheetGuid);

                if (timesheetApprovalEntities == null || timesheetApprovalEntities.Count() == 0)
                {
                    return new ResponseDTO(ResponseStatus.Success, "No Timesheet Approval status for this Timesheet.", null);
                }
                else
                {
                    return new ResponseDTO(ResponseStatus.Success, "List of Timesheet Approval Status for this Timesheet", timesheetApprovalEntities.Select(tsa => tsa.MapToDto()));
                }
            }
            catch (Exception ex)
            {
                return new ResponseDTO(ResponseStatus.Error, ex.Message, null);
            }
        }

        [HttpPost("TimesheetAproval")]
        [AllowAnonymous]
        public async Task<ResponseDTO> AddApprovalStatus(Guid timesheetGuid)
        {
            try
            {
            
                return  await _timeEntryService.ApproveTimeSheet(timesheetGuid);
            }
            catch (Exception ex)
            {
                return new ResponseDTO(ResponseStatus.Error, ex.Message, null);
            }
        }
                 #endregion
    }
}
