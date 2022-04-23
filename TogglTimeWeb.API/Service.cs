using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace TogglTimeWeb.API
{
    public static class Service
    {
        public static IServiceCollection AddToggleRestClient(this IServiceCollection services)
        {
            return services.AddLogging().AddTransient<TogglRestClient>();
        }
    }
}
