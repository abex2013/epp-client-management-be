using Excellerent.SharedModules.DTO;
using Excellerent.SharedModules.Services;
using Excellerent.Timesheet.Domain.Entities;
using Excellerent.Timesheet.Domain.Interfaces.Repository;
using Excellerent.Timesheet.Domain.Interfaces.Service;
using Excellerent.Timesheet.Domain.Mapping;
using Excellerent.Timesheet.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excellerent.Timesheet.Domain.Services
{
    public class TimeSheetConfigService : CRUD<ConfigurationEntity, Configuration>, ITimeSheetConfigService
    {
        private readonly ITimeSheetConfigRepository _timeSheetConfigRepository;

        public TimeSheetConfigService(ITimeSheetConfigRepository repository) : base(repository)
        {
            _timeSheetConfigRepository = repository;
        }

        public async Task<ResponseDTO> GetTimeSheetConfiguration()
        {
            try
            {
                List<Configuration> configurations = (await _timeSheetConfigRepository.GetTimeSheetConfiguration()).ToList();
                List<ConfigurationEntity> configurationEntities = configurations.Select(config => new ConfigurationEntity(config)).ToList();

                return new ResponseDTO(ResponseStatus.Success, "TimeSheet Configuration", configurationEntities.MapToDto());
            }
            catch (Exception ex) 
            {
                return new ResponseDTO(ResponseStatus.Error, ex.Message, null);
            }
        }
    }
}
