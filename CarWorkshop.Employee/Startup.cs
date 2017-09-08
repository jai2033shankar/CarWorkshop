using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using CarWorkshop.Infrastructure.Services;
using CarWorkshop.Core.Repositories;
using CarWorkshop.Infrastructure.Repositories;
using CarWorkshop.Core.Models;

using Microsoft.EntityFrameworkCore;
using AutoMapper;
using CarWorkshop.Infrastructure.AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using System.Security.Claims;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using Microsoft.AspNetCore.Mvc.Controllers;
using SimpleInjector.Integration.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace CarWorkshop.Employee
{
    public class Startup
    {
        private Container container = new Container();

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
            services.AddDbContext<CarWorkshopContext>(options => options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]), ServiceLifetime.Scoped);

            // Add framework services.
            services.AddMvc(config => 
            {
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireClaim(ClaimTypes.Name, "EmployeeAuthClaim")
                .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.CookieHttpOnly = true;
            });

            services.AddSingleton<IControllerActivator>(
                new SimpleInjectorControllerActivator(container));

            services.AddSingleton<IViewComponentActivator>(
                new SimpleInjectorViewComponentActivator(container));

            services.UseSimpleInjectorAspNetRequestScoping(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            InitializeContainer(app);

            container.Verify();

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
                AuthenticationScheme = "EmployeeAuthCookieMiddleware",
                LoginPath = new PathString("/Home/Index"),
                AccessDeniedPath = new PathString("/Home/Forbidden"),
                AutomaticAuthenticate = true,
                AutomaticChallenge = true
            });

            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "areaRoute",
                    template: "{area:exists}/{controller=Home}/{action=Index}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private void InitializeContainer(IApplicationBuilder app)
        {
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            // Add aplication presentation components.
            container.RegisterMvcControllers(app);
            container.RegisterMvcViewComponents(app);

            // Cross-wire DbContext.
            container.Register(app.ApplicationServices.GetService<CarWorkshopContext>, Lifestyle.Singleton);

            container.Register<IEmployeeRepository, EmployeeRepository>(Lifestyle.Scoped);
            container.Register<IEmployeeService, EmployeeService>(Lifestyle.Scoped);

            container.Register<IClientRepository, ClientRepository>(Lifestyle.Scoped);
            container.Register<IClientService, ClientService>(Lifestyle.Scoped);

            container.Register<ICarRepository, CarRepository>(Lifestyle.Scoped);
            container.Register<ICarService, CarService>(Lifestyle.Scoped);

            container.Register<IRepairRepository, RepairRepository>(Lifestyle.Scoped);
            container.Register<IRepairService, RepairService>(Lifestyle.Scoped);

            container.Register<IValidationService, ValidationService>(Lifestyle.Scoped);

            container.RegisterSingleton<IMapper>(AutoMapperConfig.Configure());

        }
    }
}
