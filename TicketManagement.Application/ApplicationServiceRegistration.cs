using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagement.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            var executingAssembly = Assembly.GetExecutingAssembly();

            services.AddAutoMapper(executingAssembly);
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(executingAssembly);
            });

            return services;
        }
    }
}
