using Excellerent.Timesheet.Domain.Interfaces.Repository;
using Excellerent.Timesheet.Domain.Interfaces.Service;
using Excellerent.Timesheet.Domain.Models;
using Excellerent.Timesheet.Domain.Services;
using Excellerent.Timesheet.Domain.Mapping;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using System.Linq;
using Excellerent.Timesheet.Domain.Dtos;
using Excellerent.Timesheet.Domain.Entities;

namespace Excellerent.Timesheet.Unittests
{
    public class TimeSheetApprovalTests
    {
        private readonly TimeEntryService _timeEntryService;
        private readonly TimesheetApprovalService _timesheetAprovalService;
        private readonly Mock<ITimeEntryRepository> _timeEntryRepo = new Mock<ITimeEntryRepository>();
        private readonly Mock<ITimeSheetService> _itimesheetService = new Mock<ITimeSheetService>();
        private readonly Mock<ITimesheetApprovalService> _itimesheetApprovalService = new Mock<ITimesheetApprovalService>();
        private readonly Mock<ITimesheetApprovalRepository> _itimesheetApprovalRepo = new Mock<ITimesheetApprovalRepository>();
        private readonly Mock<ITimeSheetConfigService> _itimeSheetConfigService = new Mock<ITimeSheetConfigService>();

        public TimeSheetApprovalTests()
        {
            _timeEntryService = new TimeEntryService(_timeEntryRepo.Object, _itimesheetService.Object, _itimesheetApprovalService.Object, _itimeSheetConfigService.Object);
            _timesheetAprovalService = new TimesheetApprovalService(_itimesheetApprovalRepo.Object);
        }

        [Fact]
        public async Task ApproveTimeSheet_WithExistingTimeSheet_ReturnTimeEntry()
        {
            // Arrange TimeEntry
            var Note = "Some Note";
            var Date = DateTime.Now;
            var Index = 0;
            var Hour = 1;
            var ProjectId = Guid.NewGuid();
            var TimesheetGuid = Guid.NewGuid();

            List<TimeEntry> timeEntry = new List<TimeEntry>
                {
                    new TimeEntry
                    {
                        Note = Note,
                        Date = Date,
                        Index = Index,
                        Hour = Hour,
                        ProjectId = ProjectId,
                        TimesheetGuid = TimesheetGuid
                    }

                };

            _timeEntryRepo.Setup(repo => repo.FindAsync(x => x.TimesheetGuid == TimesheetGuid).Result).Returns(timeEntry);

            // Arrang Timesheet Approval Entity

            List<TimesheetApprovalDto> timesheetApprovalDtos = new List<TimesheetApprovalDto>
            {
                new TimesheetApprovalDto {
                    TimesheetId = TimesheetGuid,
                    ProjectId = ProjectId,
                    Status = (int)ApprovalStatus.Requested
                }
            };

            // Act
            List<TimesheetApprovalEntity> timesheetApprovalEntities = await _timeEntryService.ApproveTimeSheet(TimesheetGuid).Result.Data;

            List<TimesheetApprovalDto> result = timesheetApprovalEntities.Select(tsa => tsa.MapToDto()).ToList();

            // Assert
            Assert.Equal(timesheetApprovalDtos[0].TimesheetId, result[0].TimesheetId);
            Assert.Equal(timesheetApprovalDtos[0].ProjectId, result[0].ProjectId);
            Assert.Equal(timesheetApprovalDtos[0].Status, result[0].Status);
        }

        [Fact]
        public async Task ApproveTimeSheet_WithUnexistingTimeSheet_ReturnNoContent()
        {

            // Arrange
            var Note = "Some Note";
            var Date = DateTime.Now;
            var Index = 0;
            var Hour = 1;
            var ProjectId = Guid.NewGuid();
            var TimesheetGuid = Guid.NewGuid();

            List<TimeEntry> timeEntry = new List<TimeEntry>
            {
                new TimeEntry
                {
                    Note = Note,
                    Date = Date,
                    Index = Index,
                    Hour = Hour,
                    ProjectId = ProjectId,
                    TimesheetGuid = TimesheetGuid
                }
            };

            _timeEntryRepo.Setup(repo => repo.FindAsync(x => x.TimesheetGuid == It.IsAny<Guid>()).Result).Returns(timeEntry);
            
            // Act
            List<TimesheetApprovalEntity> result = await _timeEntryService.ApproveTimeSheet(TimesheetGuid).Result.Data;

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetTimesheetApprovalStatus_WithExistingTimeSheetStatus_TimesheetAproval()
        {

            // Arrange Timesheet Approval Model
            var timesheetId = Guid.NewGuid();
            var projectId = Guid.NewGuid();
            var status = ApprovalStatus.Requested;

            List<TimesheetApproval> timesheetApproval = new List<TimesheetApproval>
            {
                new TimesheetApproval
                {
                    TimesheetId = timesheetId,
                    ProjectId = projectId,
                    Status = status
                }
            };

            _itimesheetApprovalRepo.Setup(repo => repo.FindAsync(x => x.TimesheetId == timesheetId)).ReturnsAsync(timesheetApproval);

            // Arrange Timesheet Approval Dto

            List<TimesheetApprovalDto> timesheetApprovalDtos = new List<TimesheetApprovalDto>
            {
                new TimesheetApprovalDto
                {
                    TimesheetId = timesheetId,
                    ProjectId = projectId,
                    Status = ApprovalStatus.Requested
                }
            };

            // Act
            List<TimesheetApprovalDto> result = (await _timesheetAprovalService.GetTimesheetApprovalStatus(timesheetId)).Select(tsa => tsa.MapToDto()).ToList();

            // Assert
            Assert.Equal(timesheetApprovalDtos[0].TimesheetId, result[0].TimesheetId);
            Assert.Equal(timesheetApprovalDtos[0].ProjectId, result[0].ProjectId);
            Assert.Equal(timesheetApprovalDtos[0].Status, result[0].Status);
        }
    }
}
