using Excellerent.Timesheet.Domain.Dtos;
using Excellerent.Timesheet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Excellerent.Timesheet.Domain.Mapping
{
    public static class ConfigurationMapping
    {
        public static object Intiger { get; private set; }

        public static List<ConfigurationEntity> MapToEntity(this ConfigurationDto configurationDto) 
        {
            List<ConfigurationEntity> configurationEntities = new List<ConfigurationEntity>();

            PropertyInfo[] properties = configurationDto.GetType().GetProperties();

            foreach (PropertyInfo property in properties) 
            {
                configurationEntities.Add(new ConfigurationEntity
                {
                    Key = property.Name,
                    Value = property.GetValue(configurationDto, null).ToString(),
                    DataType = property.PropertyType.ToString()
                });
            }

            return configurationEntities;
        }

        public static ConfigurationDto MapToDto(this List<ConfigurationEntity> configurationEntities) 
        {
            ConfigurationDto configurationDto = new ConfigurationDto();

            PropertyInfo[] properties = configurationDto.GetType().GetProperties();

            foreach (PropertyInfo property in properties) 
            {
                var configEntity = configurationEntities.Find(config => config.Key == property.Name);

                if (!property.PropertyType.ToString().Equals(configEntity?.DataType))
                {
                    property.SetValue(configurationDto, configEntity?.Value);
                    continue;
                }

                if (property.PropertyType.Equals(typeof(List<string>)))
                {
                    property.SetValue(configurationDto,  configEntity?.Value.Split(",").Select(x => x.Trim()).ToList());
                }
                else if(property.PropertyType.Equals(typeof(int)))
                {
                    int number;

                    if (Int32.TryParse(configEntity?.Value, out number))
                    {
                        property.SetValue(configurationDto, number);
                    }
                    else 
                    {
                        property.SetValue(configurationDto, null);
                    }
                }                
            }

            return configurationDto;
        }
    }
}
