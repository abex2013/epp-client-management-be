﻿using Excellerent.APIModularization.Controllers;
using Excellerent.APIModularization.Logging;
using Excellerent.SharedModules.DTO;
using Excellerent.Timesheet.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Excellerent.Timesheet.Presentation.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/TimeSheet/[controller]")]
    [ApiController]
    public class TimeSheetConfigController : AuthorizedController
    {
        private readonly ITimeSheetConfigService _timeSheetConfigService;
        private readonly static string _feature = "TimeSheetConfig";

        public TimeSheetConfigController(ITimeSheetConfigService timeSheetConfigService, IHttpContextAccessor htttpContextAccessor, IConfiguration configuration, IBusinessLog _businessLog) 
            : base(htttpContextAccessor, configuration, _businessLog, _feature)
        {
            _timeSheetConfigService = timeSheetConfigService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ResponseDTO> GetTimeSheetConfiguration() 
        {
            return await _timeSheetConfigService.GetTimeSheetConfiguration();
        }
    }
}
