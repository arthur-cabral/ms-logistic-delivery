using Application.Interfaces;
using Application.Mapping;
using Application.Services;
using Domain.Interfaces;
using Infrastructure.Context;
using Infrastructure.Persistence.EventProcessor;
using Infrastructure.Persistence.RabbitMqClient;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            var defaultConnection = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseMySql(
                    defaultConnection,
                    new MySqlServerVersion(new Version(8, 0, 33)),
                    b => b.MigrationsAssembly("API")
                );

            });

            services.AddScoped<ITransportService, TransportService>();
            services.AddScoped<ITransportRepository, TransportRepository>();

            services.AddHostedService<RabbitMqSubscriber>();
            services.AddSingleton<IEventProcessor, EventProcessor>();

            

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;
        }
    }
}
