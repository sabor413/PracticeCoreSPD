using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PracticeCoreSPD.Core;

namespace PracticeCoreSPD
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

            AppSettings.Title = Configuration.GetValue<string>("AppSettings:Title");
            AppSettings.ConnectionString = Configuration.GetValue<string>("Data:DefaultConnection:ConnectionString");
            AppSettings.LogFileFolder = Path.Combine(Environment.CurrentDirectory, "wwwroot\\errorlogs");
            AppSettings.MenuFilePath = Path.Combine(Environment.CurrentDirectory, "wwwroot\\xml\\Menu.xml");

            // For Proxy Example
            AppSettings.ServiceBaseAddress = Configuration.GetValue<string>("AppSettings:ServiceBaseAddress");
            AppSettings.ServiceUrl = Configuration.GetValue<string>("AppSettings:ServiceUrl");
            AppSettings.LogFilePath = Path.Combine(Environment.CurrentDirectory, "wwwroot\\" +
                Configuration.GetValue<string>("AppSettings:LogFilePath"));
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            services.AddSession();
            //services.AddCaching();
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
            //app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "adminArea",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "default",
                    template: "{area=Home}/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
