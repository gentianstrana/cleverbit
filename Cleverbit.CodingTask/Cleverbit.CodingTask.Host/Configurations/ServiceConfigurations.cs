using Cleverbit.CodingTask.Host.Services;
using Cleverbit.CodingTask.Host.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Host.Configurations
{
    public static class ServiceConfigurations
    {
        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IMatchService, MatchService>();
        }
    }
}
