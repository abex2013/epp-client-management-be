using Excellerent.APIModularization;
using Excellerent.ApplicantTracking.Presentation;
using Excellerent.ClientManagement.Presentation;
using Excellerent.ProjectManagement.Presentation;

using Excellerent.ResourceManagement.Presentation.Config;
using Excellerent.Timesheet.Presentation;
using Excellerent.UserManagement.API;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace excellerent_epp_be
{
    public partial class Startup
    {
        private IList<IModuleStartup> modules = new List<IModuleStartup>();

        public void AddModules(IServiceCollection services)
        {
            modules.Add(new UserManagementModule());
            modules.Add(new ApplicantModuleRegistration());
            modules.Add(new TimesheetModuleRegistration());
            modules.Add(new ProjectManagementModuleRegistration());
            modules.Add(new ResourceManagementModuleRegistration());
            modules.Add(new ClientManagementModuleRegistration());
            ConfigureModules(services);
        }

        public void ConfigureModules(IServiceCollection services)
        {
            // find all controllers
            var Controllers = from a in AppDomain.CurrentDomain.GetAssemblies().AsParallel()
                              from t in a.GetTypes()
                              let attributes = t.GetCustomAttributes(typeof(ControllerAttribute), true)
                              where attributes?.Length > 0
                              select new { Type = t };
            var ControllersList = Controllers.ToList();

            // register them
            foreach (var Controller in ControllersList)
            {
                services
                    .AddMvc()
                    .AddApplicationPart(Controller.Type.Assembly);
            }

            // configuring services for all modules
            foreach (var module in modules)
            {
                module.Startup(Configuration);
                module.ConfigureServices(services);
            }
        }
    }
}
