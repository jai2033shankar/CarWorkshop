using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using CarWorkshop.Infrastructure.Repositories;
using CarWorkshop.Core.Repositories;
using CarWorkshop.Infrastructure.Services;
using CarWorkshop.Core.Models;
using Microsoft.AspNetCore.Http;
using CarWorkshop.Infrastructure.AutoMapper;

namespace CarWorkshop.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IClientService, ClientService>();

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddSingleton(AutoMapperConfig.Configure());
            // Add framework services.
            services.AddMvc();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("TestPolicy", policy => policy.RequireRole("Admin"));
            });

            services.AddDbContext<CarWorkshopContext>(options => options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationScheme = "CookieAuthMiddleware",
                LoginPath = new PathString(Configuration["Authentication:LoginPath"]),
                AccessDeniedPath = new PathString(Configuration["Authentication:AccessDeniedPath"]),
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                ClaimsIssuer = "http://localhost:5000",
                ExpireTimeSpan = TimeSpan.FromMinutes(10)
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
