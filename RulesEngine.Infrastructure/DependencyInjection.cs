using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RuleEngine.Contract;
using RuleEngine.Infrastructure.Data;
using RuleEngine.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine.Infrastructure
{
    public static class DependencyInjection
    {

            //  private readonly IConfiguration configuration;
            public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
            {
                services.AddDbContext<RuleDbContext>(options =>
                {
                    options.UseSqlServer("Server=DESKTOP-7GMUUO3\\SQLEXPRESS;Initial Catalog=DBAuth;User ID=sa;Password=Debarshi01@;Trusted_Connection=False;TrustServerCertificate=True;");// configuration.GetConnectionString("ConnectionStrings:DefaultConnection"));
                });

                services.AddScoped<IWorkFlows, WorkflowRepository>();
                return services;

            }
        }
    }

