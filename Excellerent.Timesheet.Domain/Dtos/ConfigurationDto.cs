using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excellerent.Timesheet.Domain.Dtos
{
    public class ConfigurationDto
    {
        public List<string> WorkingDays { get; set; }
        public int WorkingHour { get; set; }
    }
}
