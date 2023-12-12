using Excellerent.ResourceManagement.Domain.Interfaces.Services;
using Excellerent.ResourceManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excellerent.ResourceManagement.Domain.Services
{
    public class DeviceClassificationService : IDeviceClassificationService
    {
        List<DeviceClassification> deviceClassifications = new List<DeviceClassification>();
        public DeviceClassificationService()
        {
            deviceClassifications.AddRange(
                new List<DeviceClassification> {
                    new DeviceClassification {
                        Guid = Guid.NewGuid(),
                        Name = "Business Unit",
                        Description ="business unit desc",
                    },
                    new DeviceClassification {
                        Guid = Guid.NewGuid(),
                        Name = "Department",
                        Description = "department desc"
                    },
                    new DeviceClassification {
                        Guid = Guid.NewGuid(),
                        Name = "Employee",
                        Description = "employee desc"
                    }
                }
            );
        }
        public List<DeviceClassification> GetDeviceClassifications()
        {
            return deviceClassifications;
        }

        public List<DeviceClassification> GetDeviceClassificationById(Guid id)
        {
            return id == null ? deviceClassifications : deviceClassifications.Where(x => x.Guid == id).ToList();
        }
    }
}
