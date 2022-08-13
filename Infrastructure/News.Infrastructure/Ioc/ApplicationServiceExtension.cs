using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using News.Application.Automapper;
using News.Application.Interfaces;
using News.Application.New.Commands;
using News.Application.New.Commands.CreateNewsCommands;
using News.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Infrastructure.Ioc
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddCustomeServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IDataContext>(provider => provider.GetRequiredService<DataContext>());
            services.AddAutoMapper(typeof(AutomapperProfile));
            services.AddMediatR(typeof(CreateNewsCommandHandler).Assembly);
            return services;
        }
    }
}
