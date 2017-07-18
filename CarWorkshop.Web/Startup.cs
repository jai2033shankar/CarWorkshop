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

using SimpleInjector;
using SimpleInjector.Integration.AspNetCore;
using SimpleInjector.Integration.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using SimpleInjector.Lifestyles;
using AutoMapper;
using CarWorkshop.Infrastructure.Commands;
using System.Reflection;
using CarWorkshop.Infrastructure.IoC;
using System.Security.Claims;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace CarWorkshop.Web
{
    public class Startup
    {
        private Container container = new Container();
        private CommandConfig config = new CommandConfig();

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
            // Add framework services.
            services.AddMvc( config => 
            {
                var policy = new AuthorizationPolicyBuilder()
                                 .RequireAuthenticatedUser()
                                 .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("TestPolicy", policy => policy.RequireClaim(ClaimTypes.Name, "TestClaim"));
            });

            services.AddDbContext<CarWorkshopContext>(options => options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]), ServiceLifetime.Scoped);

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(15);
                options.CookieHttpOnly = true;
            });

            services.AddSingleton<IControllerActivator>(
                new SimpleInjectorControllerActivator(container));
            services.AddSingleton<IViewComponentActivator>(
                new SimpleInjectorViewComponentActivator(container));

            services.UseSimpleInjectorAspNetRequestScoping(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, 
                                IApplicationLifetime lifeTime)
        {
            InitializeContainer(app);

            // Register custom middleware here

            container.Verify();

            // Add custom middleware

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
                ClaimsIssuer = "http://localhost:61357",
                ExpireTimeSpan = TimeSpan.FromMinutes(10)
            });

            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            lifeTime.ApplicationStopped.Register(() => container.Dispose());
        }

        private void InitializeContainer(IApplicationBuilder app)
        {
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            // Add application presentation components.
            container.RegisterMvcControllers(app);
            container.RegisterMvcViewComponents(app);

            // Add application services.

            // Cross-wire asp.net service - docs advise to minimize this - check later.
            container.Register(app.ApplicationServices.GetService<CarWorkshopContext>, Lifestyle.Singleton);

            container.Register<IClientRepository, ClientRepository>(Lifestyle.Scoped);
            container.Register<IClientService, ClientService>(Lifestyle.Scoped);

            container.Register<IEmployeeRepository, EmployeeRepository>(Lifestyle.Scoped);
            container.Register<IEmployeeService, EmployeeService>(Lifestyle.Scoped);

            container.RegisterSingleton<IMapper>(AutoMapperConfig.Configure());


            config.RegisterServices(container);


        }
    }
}
