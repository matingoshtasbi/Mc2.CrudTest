using Mc2.CrudTest.Application.Contract.Abstractions.CustomerManagement;
using Mc2.CrudTest.Application.Contract.DTOs.CustomerManagement;
using Mc2.CrudTest.Application.Contract.Queries.CustomerManagement;
using Mc2.CrudTest.Application.Core.Abstractions;
using Mc2.CrudTest.Application.Core.Exceptions.ErrorHandling;
using Mc2.CrudTest.Application.DependencyInjectionExtensions;
using Mc2.CrudTest.Application.Services.CustomerManagement;
using Mc2.CrudTest.Domain.CustomerManagement.Aggregates;
using Mc2.CrudTest.Domain.CustomerManagement.Services;
using Mc2.CrudTest.Infrastructure.Persistence.DbContexts;
using Mc2.CrudTest.Infrastructure.Persistence.Repositories.CustomerManagement;
using Mc2.CrudTest.Infrastructure.Persistence.SqlServer.DbContexts;
using Mc2.CrudTest.Infrastructure.Persistence.UnitofWork;
using Mc2.CrudTest.Infrastructure.ReadModules.DbContexts;
using Mc2.CrudTest.Infrastructure.ReadModules.Repositories.CustomerManagement;
using Mc2.CrudTest.Shared;
using Mc2.CrudTest.Shared.AutoMapper;
using Mc2.CrudTest.Shared.ErrorHandling;
using Mc2.CrudTest.Shared.Swagger;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

namespace Mc2.CrudTest.Presentation.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CommandDbContext, SqlServerCommandDbContext>(options =>
                options.UseLazyLoadingProxies()
                .UseSqlServer(Configuration.GetConnectionString("MainConnection")));

            services.AddDbContext<QueryDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MainConnection")));

            services.AddTransient<IUnitOfWork, MainUnitOfWork>();

            services.AddTransient<IExceptionHandler, ExceptionHandler>();
            services.AddAutoMapper(typeof(CustomerProfile));
            services.AddControllersWithViews();
            services.AddControllers();

            // This Package Added in .Net 6 for minimal Api that Unfortunately We haven't here :)
            // services.AddEndpointsApiExplorer();

            services.AddLocalization();

            services.AddRequestLocalization(x =>
            {
                x.DefaultRequestCulture = new RequestCulture("en");
                x.ApplyCurrentCultureToResponseHeaders = true;
                x.SupportedCultures = new List<CultureInfo> { new("fa"), new("en") };
                x.SupportedUICultures = new List<CultureInfo> { new("fa"), new("en") };
            });

            var assembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(assembly);

            services.AddCustomerManagementModules();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddSwaggerGen(config => config.OperationFilter<HeaderFilter>());

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                    c.RoutePrefix = "";
                });
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRequestLocalization();
            app.UseMiddleware<ApplicationExceptionMiddleware>();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
            app.UseStaticFiles();
        }
    }
}
