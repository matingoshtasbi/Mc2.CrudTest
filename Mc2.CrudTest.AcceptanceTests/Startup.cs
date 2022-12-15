using Mc2.CrudTest.Application.Core.Abstractions;
using Mc2.CrudTest.Application.Core.Exceptions.ErrorHandling;
using Mc2.CrudTest.Application.DependencyInjectionExtensions;
using Mc2.CrudTest.Infrastructure.Persistence.DbContexts;
using Mc2.CrudTest.Infrastructure.Persistence.Sqlite.DbContexts;
using Mc2.CrudTest.Infrastructure.Persistence.UnitofWork;
using Mc2.CrudTest.Infrastructure.ReadModules.DbContexts;
using Mc2.CrudTest.Shared.AutoMapper;
using Mc2.CrudTest.Shared.ErrorHandling;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.AcceptanceTests
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var keepAliveConnection = new SqliteConnection("Data Source=:memory:");
            keepAliveConnection.Open();

            services.AddDbContext<CommandDbContext, SqliteCommandDbContext>(options =>
                options.UseLazyLoadingProxies()
                .UseSqlite(keepAliveConnection));

            services.AddDbContext<QueryDbContext>(options =>
                options.UseSqlite(keepAliveConnection), ServiceLifetime.Scoped);

            services.AddScoped<IUnitOfWork, MainUnitOfWork>();

            services.AddTransient<IExceptionHandler, ExceptionHandler>();
            services.AddAutoMapper(typeof(CustomerProfile));
            services.AddControllersWithViews();
            services.AddControllers();

            services.AddLocalization();

            services.AddRequestLocalization(x =>
            {
                x.DefaultRequestCulture = new RequestCulture("en");
                x.ApplyCurrentCultureToResponseHeaders = true;
                x.SupportedCultures = new List<CultureInfo> { new("fa"), new("en") };
                x.SupportedUICultures = new List<CultureInfo> { new("fa"), new("en") };
            });

            services.AddCustomerManagementModules();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<CommandDbContext>();
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
            app.UseMiddleware<ApplicationExceptionMiddleware>();
            app.UseStaticFiles();

        }
    }
}
